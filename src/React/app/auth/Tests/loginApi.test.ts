import axios from 'axios';
jest.mock('axios');
const mockedAxios = axios as jest.Mocked<typeof axios>;

// Mock process.env at the module level
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
  
// Mock console methods
beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => { });
  jest.spyOn(console, 'error').mockImplementation(() => { });
});

// Import the functions AFTER environment is mocked
import { LoginValidaUsernameApi, RequestNewPasswordApi, MustChangePassword } from '../api/authApi';

describe('loginApi', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  describe('LoginValidaUsernameApi', () => {
    it('should validate username successfully', async () => {
      const setMessage = jest.fn();

      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 1, Username: 'test@email.com', Uri: 'test-uri' }
      });

      const result = await LoginValidaUsernameApi('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(true);
      expect(mockedAxios.post).toHaveBeenCalled();
      // Don't assert on exact URL since it might be constructed differently
      const postCall = mockedAxios.post.mock.calls[0];
      expect(postCall[0]).toContain('users/validausername');
    });

    it('should handle unknown user', async () => {
      const setMessage = jest.fn();

      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      const result = await LoginValidaUsernameApi('unknown@email.com', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith('Usuário desconhecido!');
    });

    it('should handle network errors', async () => {
      const setMessage = jest.fn();

      mockedAxios.post.mockRejectedValue(new Error('Network Error'));

      const result = await LoginValidaUsernameApi('test@email.com', 'test-uri', setMessage);

      expect(result).toBe(false);
      expect(setMessage).toHaveBeenCalledWith('Erro de conectividade');
    });
  });

  describe('RequestNewPasswordApi', () => {
    it('should request new password successfully', async () => {
      const setMessage = jest.fn();

      mockedAxios.post.mockResolvedValue({
        status: 200,
        data: { Id: 0 }
      });

      const dataItem = {
        email: 'test@email.com',
        password: '',
        passwordNew: '',
        passwordConfirm: '',
      };

      await RequestNewPasswordApi(dataItem, 'test-uri', setMessage);

      expect(mockedAxios.post).toHaveBeenCalled();
      const postCall = mockedAxios.post.mock.calls[0];
      expect(postCall[0]).toContain('users/resetpassword');
      expect(setMessage).toHaveBeenCalledWith(
        'A senha temporária será enviada em alguns instantes para o seu e-mail!'
      );
    });
 
    it('should handle request password reset errors', async () => {
      const setMessage = jest.fn();
      mockedAxios.post.mockRejectedValue(new Error('Network Error'));
      const dataItem = {
        email: 'test@email.com',
        password: '',
        passwordNew: '',
        passwordConfirm: '',
      };      

      await RequestNewPasswordApi(dataItem, 'test-uri', setMessage);      
       expect(setMessage).toHaveBeenCalledWith('Erro de conectividade');
      
    });

  });

  describe('MustChangePassword', () => {
    it('should return true when password change is required', async () => {
      const mockUser = {
        Id: 1,
        Uri: 'test-uri',
        Token: 'dGVzdC10b2tlbg==', // base64 encoded 'test-token'
      };

      // Mock the response to indicate password change is required
      mockedAxios.get.mockResolvedValue({
        status: 200,
        data: 'reset'
      });

      const result = await MustChangePassword(mockUser as any);

      expect(result).toBe(true);
      expect(mockedAxios.get).toHaveBeenCalled();
      const getCall = mockedAxios.get.mock.calls[0];
      expect(getCall[0]).toContain('users/reset');
    });

    it('should return false when password change is not required', async () => {
      const mockUser = {
        Id: 1,
        Uri: 'test-uri',
        Token: 'dGVzdC10b2tlbg==',
      };

      // Mock the response to NOT require password change
      mockedAxios.get.mockResolvedValue({
        status: 200,
        data: 'different-value'
      });

      const result = await MustChangePassword(mockUser as any);

      expect(result).toBe(false);
    });

    it('should handle API errors gracefully', async () => {
      const mockUser = {
        Id: 1,
        Uri: 'test-uri',
        Token: 'dGVzdC10b2tlbg==',
      };

      mockedAxios.get.mockRejectedValue(new Error('Network Error'));

      const result = await MustChangePassword(mockUser as any);

      // Should default to false on error to avoid blocking user
      expect(result).toBe(false);
    });
  });
});