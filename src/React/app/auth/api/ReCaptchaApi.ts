import axios, { AxiosError } from 'axios';
import { ResultApi } from '../../models/ResultApi';

interface ReCaptchaRequest {
  captchaValue: string;
}

interface ReCaptchaResponse {
  success: boolean;
  challenge_ts: string;
  hostname: string;
  'error-codes'?: string[];
}

enum CircuitState {
  CLOSED = 'CLOSED',
  OPEN = 'OPEN',
  HALF_OPEN = 'HALF_OPEN',
}

class CircuitBreaker {
  private state: CircuitState = CircuitState.CLOSED;
  private failureCount: number = 0;
  private successCount: number = 0;
  private lastFailureTime: number = 0;
  private readonly failureThreshold: number = 5;
  private readonly successThreshold: number = 2;
  private readonly timeout: number = 60000; // 60 seconds

  async execute<T>(fn: () => Promise<T>): Promise<T> {
    if (this.state === CircuitState.OPEN) {
      if (Date.now() - this.lastFailureTime > this.timeout) {
        this.state = CircuitState.HALF_OPEN;
        this.successCount = 0;
        console.info('Circuit breaker: OPEN -> HALF_OPEN');
      } else {
        throw new Error('Circuit breaker is OPEN');
      }
    }

    try {
      const result = await fn();
      this.onSuccess();
      return result;
    } catch (error) {
      this.onFailure();
      throw error;
    }
  }

  private onSuccess(): void {
    this.failureCount = 0;

    if (this.state === CircuitState.HALF_OPEN) {
      this.successCount++;
      if (this.successCount >= this.successThreshold) {
        this.state = CircuitState.CLOSED;
        console.info('Circuit breaker: HALF_OPEN -> CLOSED');
      }
    }
  }

  private onFailure(): void {
    this.failureCount++;
    this.lastFailureTime = Date.now();

    if (this.failureCount >= this.failureThreshold) {
      this.state = CircuitState.OPEN;
      console.warn(`Circuit breaker: ${this.state} -> OPEN (failures: ${this.failureCount})`);
    }
  }

  getState(): CircuitState {
    return this.state;
  }

  reset(): void {
    this.state = CircuitState.CLOSED;
    this.failureCount = 0;
    this.successCount = 0;
    this.lastFailureTime = 0;
  }
}

class RateLimiter {
  private requests: number[] = [];
  private readonly maxRequests: number = 10;
  private readonly timeWindow: number = 60000; // 1 minute

  canMakeRequest(): boolean {
    const now = Date.now();
    this.requests = this.requests.filter((time) => now - time < this.timeWindow);

    if (this.requests.length >= this.maxRequests) {
      console.warn('Rate limit exceeded');
      return false;
    }

    this.requests.push(now);
    return true;
  }

  getRemainingRequests(): number {
    const now = Date.now();
    this.requests = this.requests.filter((time) => now - time < this.timeWindow);
    return Math.max(0, this.maxRequests - this.requests.length);
  }
}

enum ErrorType {
  NETWORK = 'NETWORK',
  TIMEOUT = 'TIMEOUT',
  SERVER = 'SERVER',
  CLIENT = 'CLIENT',
  CIRCUIT_OPEN = 'CIRCUIT_OPEN',
  RATE_LIMIT = 'RATE_LIMIT',
  UNKNOWN = 'UNKNOWN',
}

interface CaptchaError {
  type: ErrorType;
  message: string;
  originalError?: Error;
  retryable: boolean;
}

const circuitBreaker = new CircuitBreaker();
const rateLimiter = new RateLimiter();

const delay = (ms: number) => new Promise((resolve) => setTimeout(resolve, ms));

const categorizeError = (error: any): CaptchaError => {
  const axiosError = error as AxiosError;

  if (error.message === 'Circuit breaker is OPEN') {
    return {
      type: ErrorType.CIRCUIT_OPEN,
      message: 'Service temporarily unavailable due to multiple failures',
      originalError: error,
      retryable: false,
    };
  }

  if (axiosError.code === 'ECONNABORTED') {
    return {
      type: ErrorType.TIMEOUT,
      message: 'Request timeout',
      originalError: error,
      retryable: true,
    };
  }

  if (axiosError.code === 'ERR_NETWORK' || !axiosError.response) {
    return {
      type: ErrorType.NETWORK,
      message: 'Network error',
      originalError: error,
      retryable: true,
    };
  }

  if (axiosError.response) {
    const status = axiosError.response.status;
    if (status >= 500) {
      return {
        type: ErrorType.SERVER,
        message: `Server error: ${status}`,
        originalError: error,
        retryable: true,
      };
    }
    if (status >= 400) {
      return {
        type: ErrorType.CLIENT,
        message: `Client error: ${status}`,
        originalError: error,
        retryable: false,
      };
    }
  }

  return {
    type: ErrorType.UNKNOWN,
    message: 'Unknown error',
    originalError: error,
    retryable: false,
  };
};

const verifyReCaptcha = async (
  captchaValue: string,
  maxRetries: number = 3,
  baseDelayMs: number = 1000
): Promise<ResultApi<ReCaptchaResponse>> => {
  // Check rate limiting
  if (!rateLimiter.canMakeRequest()) {
   // console.error('Rate limit exceeded, blocking request');
    throw new Error('Too many requests. Please wait a moment and try again.');
  }

  const apiUrl = process.env.NEXT_PUBLIC_URL_API_CUSTOM;
  if (!apiUrl) {
    //console.error('NEXT_PUBLIC_URL_API_CUSTOM is not defined');
    throw new Error('Configuration error: API URL not defined');
  }

  // 🔥 Cache-busting: adicionar timestamp para evitar cache do servidor/CDN
  const timestamp = Date.now();
  const url = `${apiUrl}/recaptcha/verify?_t=${timestamp}`;
  const requestData: ReCaptchaRequest = { captchaValue };

  let lastCaptchaError: CaptchaError | null = null;

  for (let attempt = 0; attempt <= maxRetries; attempt++) {
    try {
      const response = await circuitBreaker.execute(async () => {
        return await axios.post<ResultApi<ReCaptchaResponse>>(url, requestData, {
          timeout: 10000,
          headers: {
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache, no-store, must-revalidate',
            'Pragma': 'no-cache',
            'Expires': '0',
          },
        });
      });

      //console.info(`reCAPTCHA verification successful (attempt ${attempt + 1})`);
      return response.data;
    } catch (error) {
      lastCaptchaError = categorizeError(error);
 

      // Don't retry if circuit is open or error is not retryable
      if (
        lastCaptchaError.type === ErrorType.CIRCUIT_OPEN ||
        !lastCaptchaError.retryable ||
        attempt >= maxRetries
      ) {
        break;
      }

      // Exponential backoff with jitter
      const jitter = Math.random() * 1000;
      const delayMs = baseDelayMs * Math.pow(2, attempt) + jitter;
      
      await delay(delayMs);
    }
  }

  // Handle specific error types with appropriate messages
  if (lastCaptchaError) {
    switch (lastCaptchaError.type) {
      case ErrorType.CIRCUIT_OPEN:
        throw new Error('Service temporarily unavailable. Please try again in a moment.');
      case ErrorType.RATE_LIMIT:
        throw new Error('Too many requests. Please wait before trying again.');
      case ErrorType.NETWORK:
        throw new Error('Network error. Please check your connection and try again.');
      case ErrorType.TIMEOUT:
        throw new Error('Request timeout. Please try again.');
      case ErrorType.CLIENT:
        throw new Error('Invalid request. Please refresh the page and try again.');
      default:
        throw new Error('Error verifying reCAPTCHA. Please try again.');
    }
  }

  throw new Error('Error verifying reCAPTCHA. Please try again.');
};

// Export additional utilities for monitoring and testing
export const getCircuitBreakerState = () => circuitBreaker.getState();
export const resetCircuitBreaker = () => circuitBreaker.reset();
export const getRemainingRateLimit = () => rateLimiter.getRemainingRequests();

export default verifyReCaptcha;
