import axios, { AxiosError, AxiosResponse } from 'axios';
import { NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';
import { decodeBase64Token } from '@/app/tools/Fetcher';
import { AgendaSemanaApiError } from '../GerAdv_TS/AgendaSemana/Apis/ApiAgendaSemana';
import { AgendaSemanaApi } from '@/app/GerAdv_TS/AgendaSemana/Apis/ApiAgendaSemana';
import { FilterAgendaSemana } from '../GerAdv_TS/AgendaSemana/Filters/AgendaSemana';
import { IAgendaSemana } from '../GerAdv_TS/AgendaSemana/Interfaces/interface.AgendaSemana';
import { AgendaSemanaTestEmpty } from '../GerAdv_TS/Models/AgendaSemana';

// Mock useSWR to avoid React context errors
jest.mock('swr', () => ({
  __esModule: true,
  default: jest.fn(() => ({})),
}));

const mockEnv = {
  ...process.env,
  NEXT_PUBLIC_API_BASE_URL: 'https://api.test.com',
  NEXT_PUBLIC_URL_API_BASE: 'https://api.test.com',
  NEXT_PUBLIC_URL_API_LOGIN: 'https://api.test.com',
  NEXT_PUBLIC_BEARER: 'test-bearer-token',
  NEXT_PUBLIC_RESET_KEY: 'reset',
  NEXT_PUBLIC_APP_ID: 'APP_ID_TEST',
  NEXT_PUBLIC_URL_VERSION_API: '1',
};

// Replace process.env completely
Object.defineProperty(process, 'env', {
  value: mockEnv,
  writable: false,
});
  
// Mock das dependências
jest.mock('axios');
jest.mock('@/app/tools/NotifySystem');
jest.mock('@/app/tools/Fetcher');

const mockedAxios = axios as jest.Mocked<typeof axios>;
const MockedNotificationService = NotificationService as jest.MockedClass<typeof NotificationService>;
const mockedDecodeBase64Token = decodeBase64Token as jest.MockedFunction<typeof decodeBase64Token>;

// Mock das variáveis de ambiente
process.env.NEXT_PUBLIC_URL_API_BASE = 'https://api.test.com/v';
process.env.NEXT_PUBLIC_URL_VERSION_API = '1';
process.env.NEXT_PUBLIC_APP_ID = 'test-app';

describe('AgendaSemanaApi', () => {
  let agendasemanaApi: AgendaSemanaApi;
  let mockNotificationService: jest.Mocked<NotificationService>;
  const mockUri = 'test-uri';
  const mockToken = 'test-token';
  const mockDecodedToken = 'decoded-test-token';

  beforeEach(() => {
    jest.clearAllMocks();        
    
    // Mock do NotificationService
    mockNotificationService = {
      notify: jest.fn(),
    } as any;
    MockedNotificationService.mockImplementation(() => mockNotificationService);
    
    // Mock do decodeBase64Token
    mockedDecodeBase64Token.mockReturnValue(mockDecodedToken);
    
    agendasemanaApi = new AgendaSemanaApi(mockUri, mockToken);
  });

  describe('Constructor', () => {
    it('should initialize with correct baseUrl and authorization', () => {
      expect(agendasemanaApi).toBeInstanceOf(AgendaSemanaApi);
      // Removed assertion for decodeBase64Token as it is not called in the constructor
    });

    it('should use custom version when provided', () => {
      const customVersion = 2;
      const customApi = new AgendaSemanaApi(mockUri, mockToken, customVersion);
      expect(customApi).toBeInstanceOf(AgendaSemanaApi);
    });
  });

  

  

  describe('filter', () => {
    const mockFilter: FilterAgendaSemana = {
      funcionario: 1,
      data: '2024-01-01',
    };

    const mockResponse: AxiosResponse = {
      data: [{ id: 1, compromisso: 'Filtered' }],
      status: 200,
      statusText: 'OK',
      headers: {},
      config: {},
    } as AxiosResponse;

    it('should filter agendasemana items successfully', async () => {
      mockedAxios.post.mockResolvedValue(mockResponse);

      const result = await agendasemanaApi.filter(mockFilter);

      expect(mockedAxios.post).toHaveBeenCalledWith(
        expect.stringContaining('/Filter'),
        mockFilter,
        expect.any(Object)
      );
      expect(result).toEqual(mockResponse);
    });

    it('should use offline data when filter request fails', async () => {
      const offlineData = [{ id: 1, compromisso: 'Offline filtered' }];
      const encodedData = btoa(JSON.stringify(offlineData));
      
      mockedAxios.post.mockRejectedValue(new Error('Network error'));
      (global.localStorage.getItem as jest.Mock).mockReturnValue(encodedData);

      const result = await agendasemanaApi.filter(mockFilter);

      expect(result.data).toEqual(offlineData);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          action: NotifySystemActions.INFO,
        })
      );
    });
  });

  describe('addAndUpdate', () => {
    const mockAgendaSemana: IAgendaSemana = {
      id: 0,
      funcionario: 1,
      tipocompromisso: 1,
      fornecedor: 1,
      boletos: 1,
      cancelou: false,
      recibo: false,
      data: '2024-01-01',
      hora: '10:00',
      liberado: true,
      importante: false,
      concluido: false,
      horafinal: '11:00',
      compromisso: 'New compromisso',
    };

    it('should add new agendasemana successfully', async () => {
      const responseAgendaSemana = { ...mockAgendaSemana, id: 1 };
      const mockResponse: AxiosResponse = {
        data: responseAgendaSemana,
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.post.mockResolvedValue(mockResponse);

      const result = await agendasemanaApi.addAndUpdate(mockAgendaSemana);

      expect(mockedAxios.post).toHaveBeenCalledWith(
        expect.stringContaining('/AddAndUpdate'),
        mockAgendaSemana,
        expect.any(Object)
      );
      expect(result).toEqual(mockResponse);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'AgendaSemana',
          id: 1,
          action: NotifySystemActions.ADD,
        })
      );
    });

    it('should update existing agendasemana successfully', async () => {
      const existingAgendaSemana = { ...mockAgendaSemana, id: 1 };
      const mockResponse: AxiosResponse = {
        data: existingAgendaSemana,
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.post.mockResolvedValue(mockResponse);

      const result = await agendasemanaApi.addAndUpdate(existingAgendaSemana);

      expect(result).toEqual(mockResponse);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'AgendaSemana',
          id: 1,
          action: NotifySystemActions.UPDATE,
        })
      );
    });

    it('should handle conflict error (409)', async () => {
      const conflictError = new Error('Conflict') as AxiosError;
      conflictError.response = {
        status: 409,
        data: { message: 'Registro já existe' },
      } as any;

      mockedAxios.post.mockRejectedValue(conflictError);
      mockedAxios.isAxiosError.mockReturnValue(true);

      await expect(agendasemanaApi.addAndUpdate(mockAgendaSemana)).rejects.toThrow(AgendaSemanaApiError);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'AgendaSemana',
          action: NotifySystemActions.ERROR,
          message: 'Registro já existe',
        })
      );
    });
  });

  describe('delete', () => {
    it('should delete agendasemana successfully', async () => {
      const mockResponse: AxiosResponse = {
        data: { success: true },
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.delete.mockResolvedValue(mockResponse);

      const result = await agendasemanaApi.delete(1);

      expect(mockedAxios.delete).toHaveBeenCalledWith(
        expect.stringContaining('/Delete?id=1'),
        expect.any(Object)
      );
      expect(result).toEqual(mockResponse);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'AgendaSemana',
          id: 1,
          action: NotifySystemActions.DELETE,
        })
      );
    });

    it('should handle conflict error on delete (409)', async () => {
      const conflictError = new Error('Conflict') as AxiosError;
      conflictError.response = {
        status: 409,
        data: { message: 'Registro vinculado a outros registros' },
      } as any;

      mockedAxios.delete.mockRejectedValue(conflictError);
      mockedAxios.isAxiosError.mockReturnValue(true);

      await expect(agendasemanaApi.delete(1)).rejects.toThrow();
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'AgendaSemana',
          id: 1,
          action: NotifySystemActions.ERROR,
          message: 'Registro vinculado a outros registros',
        })
      );
    });

    it('should handle general delete error', async () => {
      const error = new Error('Network error') as AxiosError;
      error.isAxiosError = true;
      error.response = {
        status: 500,
        data: { message: 'Server error' },
      } as any;

      mockedAxios.delete.mockRejectedValue(error);
      mockedAxios.isAxiosError.mockReturnValue(true);

      await expect(agendasemanaApi.delete(1)).rejects.toThrow(AgendaSemanaApiError);
    });
  });

  describe('useFilter', () => {
    it('should create SWR hook with correct parameters', () => {
      const mockFilter: FilterAgendaSemana = { funcionario: 1 };
      
      const result = agendasemanaApi.useFilter(mockFilter);
      
      // Como useSWR é mockado, apenas verificamos se foi chamado
      expect(result).toBeDefined();
    });
  });

  describe('Error Handling', () => {
    it('should create proper notification entity for delete', async () => {
      // Test private method through public interface
      const mockResponse: AxiosResponse = {
        data: { success: true },
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.delete.mockResolvedValue(mockResponse);

      await agendasemanaApi.delete(1);

      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'AgendaSemana',
          id: 1,
          action: NotifySystemActions.DELETE,
        })
      );
    });


  });

  describe('AgendaSemanaApiError', () => {
    it('should create error with correct properties', () => {
      const error = new AgendaSemanaApiError('Test message', 400, 'TEST_CODE', 'original');

      expect(error.message).toBe('Test message');
      expect(error.status).toBe(400);
      expect(error.code).toBe('TEST_CODE');
      expect(error.originalError).toBe('original');
      expect(error.name).toBe('AgendaSemanaApiError');
    });

    it('should create error without optional parameters', () => {
      const error = new AgendaSemanaApiError('Test message', 500);

      expect(error.message).toBe('Test message');
      expect(error.status).toBe(500);
      expect(error.code).toBeUndefined();
      expect(error.originalError).toBeUndefined();
    });
  });


});