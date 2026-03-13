// __tests__/AuthServiceAdapter.test.ts

const mockEnv = {
  ...process.env,
  NEXT_PUBLIC_API_BASE_URL: 'https://api.test.com',
  NEXT_PUBLIC_URL_API_LOGIN: 'https://api.test.com',
  NEXT_PUBLIC_BEARER: 'test-bearer-token',
  NEXT_PUBLIC_RESET_KEY: 'reset'
};

// Replace process.env completely
Object.defineProperty(process, 'env', {
  value: mockEnv,
  writable: false,
});

// Set up environment BEFORE any imports
beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => { });
  jest.spyOn(console, 'error').mockImplementation(() => { });
});

afterAll(() => {
  delete process.env.NEXT_PUBLIC_API_BASE_URL;
});

// Import AFTER environment is set
import { AuthServiceAdapter } from '../AuthServiceAdapter';
import axios from 'axios';
jest.mock('axios');
const mockedAxios = axios as jest.Mocked<typeof axios>;

describe('AuthServiceAdapter', () => {
  let adapter: AuthServiceAdapter;
  let setMessage: jest.Mock;

  beforeEach(() => {
    adapter = new AuthServiceAdapter();
    setMessage = jest.fn();
    jest.clearAllMocks();
  });

  describe('validateUsername', () => {
    it('should validate username successfully', async () => {
      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 1, Username: 'test@email.com' }
      });

      const result = await adapter.validateUsername('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(true);
      expect(mockedAxios.post).toHaveBeenCalledWith(
        'https://api.test.com/test-uri/users/validausername',    
        expect.objectContaining({
          username: expect.any(String),
        }),
        expect.any(Object)
      );
    });

    it('should return false and call setMessage if Id is 0', async () => {
      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      const result = await adapter.validateUsername('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith('Usuário desconhecido!');
    });

    it('should handle empty email and call setMessage', async () => {
      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      const result = await adapter.validateUsername('', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalled();
    });

    it('should handle network error and call setMessage', async () => {
      mockedAxios.post.mockRejectedValue({
        message: 'Network Error',
        code: 'ERR_CONNECTION_REFUSED'
      });

      const result = await adapter.validateUsername('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith(expect.stringContaining('Erro de conectividade'));
    });

    it('should handle HTTP error response and call setMessage', async () => {
      mockedAxios.post.mockRejectedValue({
        response: {
          status: 500,
          statusText: 'Internal Server Error'
        }
      });

      const result = await adapter.validateUsername('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith('Erro no servidor: 500 - Internal Server Error');
    });

    it('should handle unexpected error shape and call setMessage', async () => {
      mockedAxios.post.mockRejectedValue('Some unknown error');

      const result = await adapter.validateUsername('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith('Erro desconhecido');
    });

    it('should not throw if setMessage is undefined', async () => {
      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      await expect(
        adapter.validateUsername('test@email.com', 'test-uri', undefined as any)
      ).resolves.toBe(false);
    });

    it('should call validateUsername with correct arguments', async () => {
      const spy = jest.spyOn(adapter, 'validateUsername');
      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 1, Username: 'test@email.com' }
      });

      await adapter.validateUsername('test@email.com', 'test-uri', setMessage);

      expect(spy).toHaveBeenCalledWith('test@email.com', 'test-uri', setMessage);
      spy.mockRestore();
    });
  });

  describe('login', () => {
    it('should login successfully', async () => {
      const mockUser = { Id: 1, Username: 'test@email.com', Token: 'token123' };
      const setSystemContext = jest.fn();
      const setWrongPassword = jest.fn();

      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: mockUser
      });

      const result = await adapter.login(
        { email: 'test@email.com', password: 'password123' },
        'test-uri',
        setSystemContext,
        setWrongPassword,
        setMessage
      );

      expect(result).toBe(true);
      expect(setSystemContext).toHaveBeenCalledWith(mockUser);
      expect(mockedAxios.post).toHaveBeenCalledWith(
        'https://api.test.com/test-uri/users/authenticate3',
        expect.objectContaining({
          username: expect.any(String),
          password: expect.any(String),
        }),
  expect.any(Object)
      );
    });

    it('should handle login failure', async () => {
      const setSystemContext = jest.fn();
      const setWrongPassword = jest.fn();

      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      const result = await adapter.login(
        { email: 'test@email.com', password: 'wrongpassword' },
        'test-uri',
        setSystemContext,
        setWrongPassword,
        setMessage
      );

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith('Senha incorreta!');
      expect(setWrongPassword).toHaveBeenCalledWith(true);
    });

    it('should handle network errors during login', async () => {
      const setSystemContext = jest.fn();
      const setWrongPassword = jest.fn();

      mockedAxios.post.mockRejectedValue({
        message: 'Network Error',
        code: 'ERR_CONNECTION_REFUSED'
      });

      const result = await adapter.login(
        { email: 'test@email.com', password: 'password123' },
        'test-uri',
        setSystemContext,
        setWrongPassword,
        setMessage
      );

      expect(result).toBe(false);
        expect(setMessage).toHaveBeenCalledWith(expect.stringContaining('Erro de conectividade'));
    });

    it('should handle unexpected error shape during login', async () => {
      const setSystemContext = jest.fn();
      const setWrongPassword = jest.fn();

      mockedAxios.post.mockRejectedValue('Some unknown error');

      const result = await adapter.login(
        { email: 'test@email.com', password: 'password123' },
        'test-uri',
        setSystemContext,
        setWrongPassword,
        setMessage
      );

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith(expect.stringContaining('autentic'));
    });
  });

  describe('requestPasswordReset', () => {
    it('should request password reset successfully', async () => {
      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      await adapter.requestPasswordReset('test@email.com', 'test-uri', setMessage);

      expect(mockedAxios.post).toHaveBeenCalledWith(
        'https://api.test.com/test-uri/users/resetpassword',
        expect.objectContaining({
          username: expect.any(String),
          password: '',
        }),
  expect.any(Object)
      );
      expect(setMessage).toHaveBeenCalledWith(
        'A senha temporária será enviada em alguns instantes para o seu e-mail!'
      );
    });

    it('should handle password reset request errors', async () => {
      mockedAxios.post.mockRejectedValue({
        message: 'Network Error',
        code: 'ERR_CONNECTION_REFUSED'
      });

      await adapter.requestPasswordReset('test@email.com', 'test-uri', setMessage);

      expect(setMessage).toHaveBeenCalledWith(expect.stringContaining('Erro de conectividade'));
    });

  });  
});