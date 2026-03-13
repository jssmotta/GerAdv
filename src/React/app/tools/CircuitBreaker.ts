// Circuit Breaker Pattern for Frontend APIs
// Part of Source Genesys WebApi Front & Back Creator
// copyright (c) 2000-2025 Menphis - Sistemas Inteligentes

export enum CircuitBreakerState {
  CLOSED = 'CLOSED',     // Normal operation - requests flow through
  OPEN = 'OPEN',         // Circuit is open - requests fail fast
  HALF_OPEN = 'HALF_OPEN' // Testing if service recovered
}

export interface CircuitBreakerConfig {
  /** Number of failures before opening the circuit */
  failureThreshold: number;
  /** Time in milliseconds to wait before trying again (half-open state) */
  resetTimeout: number;
  /** Number of successful requests needed in half-open state to close circuit */
  successThreshold: number;
  /** Timeout for individual requests in milliseconds */
  requestTimeout: number;
  /** Optional callback when state changes */
  onStateChange?: (state: CircuitBreakerState, entityName: string) => void;
}

export interface CircuitBreakerStats {
  state: CircuitBreakerState;
  failures: number;
  successes: number;
  lastFailureTime: number | null;
  totalRequests: number;
  totalFailures: number;
  totalSuccesses: number;
}

const DEFAULT_CONFIG: CircuitBreakerConfig = {
  failureThreshold: 5,
  resetTimeout: 30000, // 30 seconds
  successThreshold: 2,
  requestTimeout: 30000, // 30 seconds
};

/**
 * Circuit Breaker implementation for frontend API calls
 * Prevents cascading failures by failing fast when a service is unavailable
 */
export class CircuitBreaker {
  private state: CircuitBreakerState = CircuitBreakerState.CLOSED;
  private failures: number = 0;
  private successes: number = 0;
  private lastFailureTime: number | null = null;
  private totalRequests: number = 0;
  private totalFailures: number = 0;
  private totalSuccesses: number = 0;
  private config: CircuitBreakerConfig;
  private entityName: string;

  constructor(entityName: string, config: Partial<CircuitBreakerConfig> = {}) {
    this.entityName = entityName;
    this.config = { ...DEFAULT_CONFIG, ...config };
  }

  /**
   * Execute a request through the circuit breaker
   */
  async execute<T>(request: () => Promise<T>): Promise<T> {
    this.totalRequests++;

    // Check if circuit should transition from OPEN to HALF_OPEN
    if (this.state === CircuitBreakerState.OPEN) {
      if (this.shouldAttemptReset()) {
        this.transitionTo(CircuitBreakerState.HALF_OPEN);
      } else {
        throw new CircuitBreakerOpenError(
          `Circuit breaker is OPEN for ${this.entityName}. Service temporarily unavailable.`,
          this.getTimeUntilReset()
        );
      }
    }

    try {
      // Add timeout to the request
      const result = await this.withTimeout(request(), this.config.requestTimeout);
      this.onSuccess();
      return result;
    } catch (error) {
      this.onFailure();
      throw error;
    }
  }

  /**
   * Check if request can proceed (for pre-flight checks)
   */
  canExecute(): boolean {
    if (this.state === CircuitBreakerState.CLOSED) {
      return true;
    }
    if (this.state === CircuitBreakerState.HALF_OPEN) {
      return true;
    }
    if (this.state === CircuitBreakerState.OPEN && this.shouldAttemptReset()) {
      return true;
    }
    return false;
  }

  /**
   * Get current circuit breaker statistics
   */
  getStats(): CircuitBreakerStats {
    return {
      state: this.state,
      failures: this.failures,
      successes: this.successes,
      lastFailureTime: this.lastFailureTime,
      totalRequests: this.totalRequests,
      totalFailures: this.totalFailures,
      totalSuccesses: this.totalSuccesses,
    };
  }

  /**
   * Get current state
   */
  getState(): CircuitBreakerState {
    return this.state;
  }

  /**
   * Manually reset the circuit breaker
   */
  reset(): void {
    this.failures = 0;
    this.successes = 0;
    this.lastFailureTime = null;
    this.transitionTo(CircuitBreakerState.CLOSED);
  }

  /**
   * Get time remaining until circuit breaker attempts reset (in ms)
   */
  getTimeUntilReset(): number {
    if (this.state !== CircuitBreakerState.OPEN || !this.lastFailureTime) {
      return 0;
    }
    const elapsed = Date.now() - this.lastFailureTime;
    return Math.max(0, this.config.resetTimeout - elapsed);
  }

  private onSuccess(): void {
    this.totalSuccesses++;

    if (this.state === CircuitBreakerState.HALF_OPEN) {
      this.successes++;
      if (this.successes >= this.config.successThreshold) {
        this.failures = 0;
        this.successes = 0;
        this.transitionTo(CircuitBreakerState.CLOSED);
      }
    } else {
      // Reset failure count on success in CLOSED state
      this.failures = 0;
    }
  }

  private onFailure(): void {
    this.totalFailures++;
    this.failures++;
    this.lastFailureTime = Date.now();

    if (this.state === CircuitBreakerState.HALF_OPEN) {
      // Any failure in half-open state opens the circuit again
      this.successes = 0;
      this.transitionTo(CircuitBreakerState.OPEN);
    } else if (this.failures >= this.config.failureThreshold) {
      this.transitionTo(CircuitBreakerState.OPEN);
    }
  }

  private shouldAttemptReset(): boolean {
    if (!this.lastFailureTime) return true;
    return Date.now() - this.lastFailureTime >= this.config.resetTimeout;
  }

  private transitionTo(newState: CircuitBreakerState): void {
    if (this.state !== newState) {
      const oldState = this.state;
      this.state = newState;
      
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.log(
          `[CircuitBreaker] ${this.entityName}: ${oldState} -> ${newState}`
        );
      }

      this.config.onStateChange?.(newState, this.entityName);
    }
  }

  private withTimeout<T>(promise: Promise<T>, timeoutMs: number): Promise<T> {
    return new Promise((resolve, reject) => {
      const timer = setTimeout(() => {
        reject(new CircuitBreakerTimeoutError(
          `Request timeout after ${timeoutMs}ms for ${this.entityName}`
        ));
      }, timeoutMs);

      promise
        .then((result) => {
          clearTimeout(timer);
          resolve(result);
        })
        .catch((error) => {
          clearTimeout(timer);
          reject(error);
        });
    });
  }
}

/**
 * Error thrown when circuit breaker is open
 */
export class CircuitBreakerOpenError extends Error {
  readonly retryAfter: number;

  constructor(message: string, retryAfter: number) {
    super(message);
    this.name = 'CircuitBreakerOpenError';
    this.retryAfter = retryAfter;
  }
}

/**
 * Error thrown when request times out
 */
export class CircuitBreakerTimeoutError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'CircuitBreakerTimeoutError';
  }
}

/**
 * Registry to manage multiple circuit breakers (one per entity/service)
 */
class CircuitBreakerRegistry {
  private static instance: CircuitBreakerRegistry;
  private breakers: Map<string, CircuitBreaker> = new Map();
  private globalConfig: Partial<CircuitBreakerConfig> = {};

  private constructor() {}

  static getInstance(): CircuitBreakerRegistry {
    if (!CircuitBreakerRegistry.instance) {
      CircuitBreakerRegistry.instance = new CircuitBreakerRegistry();
    }
    return CircuitBreakerRegistry.instance;
  }

  /**
   * Set global configuration for all circuit breakers
   */
  setGlobalConfig(config: Partial<CircuitBreakerConfig>): void {
    this.globalConfig = config;
  }

  /**
   * Get or create a circuit breaker for an entity
   */
  getBreaker(entityName: string, config?: Partial<CircuitBreakerConfig>): CircuitBreaker {
    if (!this.breakers.has(entityName)) {
      this.breakers.set(
        entityName,
        new CircuitBreaker(entityName, { ...this.globalConfig, ...config })
      );
    }
    return this.breakers.get(entityName)!;
  }

  /**
   * Get all circuit breakers statistics
   */
  getAllStats(): Record<string, CircuitBreakerStats> {
    const stats: Record<string, CircuitBreakerStats> = {};
    this.breakers.forEach((breaker, name) => {
      stats[name] = breaker.getStats();
    });
    return stats;
  }

  /**
   * Reset all circuit breakers
   */
  resetAll(): void {
    this.breakers.forEach((breaker) => breaker.reset());
  }

  /**
   * Remove a specific circuit breaker
   */
  remove(entityName: string): void {
    this.breakers.delete(entityName);
  }

  /**
   * Clear all circuit breakers
   */
  clear(): void {
    this.breakers.clear();
  }
}

// Export singleton registry
export const circuitBreakerRegistry = CircuitBreakerRegistry.getInstance();

/**
 * Helper function to check if an error is a transient error that should trip the circuit breaker
 */
export function isTransientError(error: any): boolean {
  if (!error) return false;

  // Network errors
  if (error.code === 'ECONNABORTED' || error.code === 'ETIMEDOUT') return true;
  if (error.message?.includes('Network Error')) return true;

  // HTTP status codes that indicate transient errors
  const status = error.response?.status;
  if (status) {
    return [408, 429, 500, 502, 503, 504].includes(status);
  }

  // Circuit breaker specific errors
  if (error instanceof CircuitBreakerTimeoutError) return true;

  return false;
}
