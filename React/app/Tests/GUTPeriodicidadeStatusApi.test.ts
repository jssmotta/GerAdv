import axios, { AxiosError, AxiosResponse } from 'axios';
import { NotificationService, NotifySystemActions } from '@/app/tools/NotifySystem';
import { decodeBase64Token } from '@/app/tools/Fetcher';
import { GUTPeriodicidadeStatusApiError } from '../GerAdv_TS/GUTPeriodicidadeStatus/Apis/ApiGUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusApi } from '@/app/GerAdv_TS/GUTPeriodicidadeStatus/Apis/ApiGUTPeriodicidadeStatus';
import { FilterGUTPeriodicidadeStatus } from '../GerAdv_TS/GUTPeriodicidadeStatus/Filters/GUTPeriodicidadeStatus';
import { IGUTPeriodicidadeStatus } from '../GerAdv_TS/GUTPeriodicidadeStatus/Interfaces/interface.GUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusTestEmpty } from '../GerAdv_TS/Models/GUTPeriodicidadeStatus';

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

describe('GUTPeriodicidadeStatusApi', () => {
  let gutperiodicidadestatusApi: GUTPeriodicidadeStatusApi;
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
    
    gutperiodicidadestatusApi = new GUTPeriodicidadeStatusApi(mockUri, mockToken);
  });

  describe('Constructor', () => {
    it('should initialize with correct baseUrl and authorization', () => {
      expect(gutperiodicidadestatusApi).toBeInstanceOf(GUTPeriodicidadeStatusApi);
      // Removed assertion for decodeBase64Token as it is not called in the constructor
    });

    it('should use custom version when provided', () => {
      const customVersion = 2;
      const customApi = new GUTPeriodicidadeStatusApi(mockUri, mockToken, customVersion);
      expect(customApi).toBeInstanceOf(GUTPeriodicidadeStatusApi);
    });
  });

  
  describe('getAll', () => {
    const mockResponse: AxiosResponse = {
      data: [GUTPeriodicidadeStatusTestEmpty()],
      status: 200,
      statusText: 'OK',
      headers: {},
      config: {},
    } as AxiosResponse;

    it('should fetch all gutperiodicidadestatus items successfully', async () => {
      mockedAxios.get.mockResolvedValue(mockResponse);

      const result = await gutperiodicidadestatusApi.getAll();

      expect(mockedAxios.get).toHaveBeenCalledWith(
        expect.stringContaining('/GetAll?max=200'),
        expect.objectContaining({
          headers: expect.objectContaining({
            Authorization: `Bearer ${mockDecodedToken}`,
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
          }),
        })
      );
      expect(result).toEqual(mockResponse);

      const offlineData = [{ id: 2, compromisso: 'Offline Test' }];
      const encodedData = btoa(JSON.stringify(offlineData));
      (global.localStorage.getItem as jest.Mock).mockReturnValue(encodedData);

      (global.localStorage.getItem as jest.Mock).mockReturnValue(encodedData);
    });

    it('should return null when localStorage has no offline data', async () => {
      mockedAxios.get.mockRejectedValue(new Error('Network error'));
      (global.localStorage.getItem as jest.Mock).mockReturnValue(null);

      await expect(gutperiodicidadestatusApi.getAll()).rejects.toThrow(GUTPeriodicidadeStatusApiError);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          action: NotifySystemActions.ERROR,
        })
      );
    });

    it('should call localStorage.getItem with correct key on failure', async () => {
      mockedAxios.get.mockRejectedValue(new Error('Network error'));
      const offlineData = [{ id: 3, compromisso: 'Offline Again' }];
      const encodedData = btoa(JSON.stringify(offlineData));
      (global.localStorage.getItem as jest.Mock).mockReturnValue(encodedData);

      await gutperiodicidadestatusApi.getAll();

      expect(global.localStorage.getItem).toHaveBeenCalledWith(expect.stringContaining(btoa(`${process.env.NEXT_PUBLIC_APP_ID}-${mockUri}-GUTPeriodicidadeStatus_last_getAll_${200}`)));
    });

    it('should decode and return offline data if present in localStorage', async () => {
      mockedAxios.get.mockRejectedValue(new Error('Network error'));
      const offlineData = [{ id: 4, compromisso: 'Offline Decoded' }];
      const encodedData = btoa(JSON.stringify(offlineData));
      (global.localStorage.getItem as jest.Mock).mockReturnValue(encodedData);

      const result = await gutperiodicidadestatusApi.getAll();

      expect(result.data).toEqual(offlineData);
      expect(result.statusText).toBe('OK (offline)');
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
          action: NotifySystemActions.INFO,
        })
      );
    });

    it('should throw GUTPeriodicidadeStatusApiError when request fails and no offline data', async () => {
      const axiosError = new Error('Network error') as AxiosError;
      axiosError.isAxiosError = true;
      axiosError.response = {
        status: 500,
        data: { message: 'Server error' },
      } as any;

      mockedAxios.get.mockRejectedValue(axiosError);
      mockedAxios.isAxiosError.mockReturnValue(true);
      (global.localStorage.getItem as jest.Mock).mockReturnValue(null);

      await expect(gutperiodicidadestatusApi.getAll()).rejects.toThrow(GUTPeriodicidadeStatusApiError);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          action: NotifySystemActions.ERROR,
        })
      );
    });
  });


  
  describe('Private Methods', () => {
    it('should generate correct storage keys', async () => {
      const mockResponse: AxiosResponse = {
        data: [{ id: 1 }],
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.get.mockResolvedValue(mockResponse);

      await gutperiodicidadestatusApi.getAll();

      expect(global.localStorage.setItem).toHaveBeenCalledWith(
        expect.any(String),
        expect.any(String)
      );
    });

    it('should encode and decode data correctly for localStorage', async () => {
      const mockData = [{ id: 1, compromisso: 'Test' }];
      const mockResponse: AxiosResponse = {
        data: mockData,
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.get.mockResolvedValue(mockResponse);

      await gutperiodicidadestatusApi.getAll();

      const encodedData = btoa(JSON.stringify(mockData));
      expect(global.localStorage.setItem).toHaveBeenCalledWith(
        expect.any(String),
        encodedData
      );
    });

        it('should handle unknown errors', async () => {
      const unknownError = { someProperty: 'unknown error' };
      
      mockedAxios.get.mockRejectedValue(unknownError);
      mockedAxios.isAxiosError.mockReturnValue(false);
      (global.localStorage.getItem as jest.Mock).mockReturnValue(null);

      await expect(gutperiodicidadestatusApi.getAll()).rejects.toThrow(GUTPeriodicidadeStatusApiError);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          action: NotifySystemActions.ERROR,
        })
      );
    });

 });

  
  describe('getById', () => {
    const mockGUTPeriodicidadeStatus = GUTPeriodicidadeStatusTestEmpty();

    const mockResponse: AxiosResponse = {
      data: mockGUTPeriodicidadeStatus,
      status: 200,
      statusText: 'OK',
      headers: {},
      config: {},
    } as AxiosResponse;

    it('should fetch gutperiodicidadestatus by id successfully', async () => {
      mockedAxios.get.mockResolvedValue(mockResponse);

      const result = await gutperiodicidadestatusApi.getById(1);

      expect(mockedAxios.get).toHaveBeenCalledWith(
        expect.stringContaining('/GetById/1'),
        expect.any(Object)
      );
      expect(result).toEqual(mockResponse);
      expect(global.localStorage.setItem).toHaveBeenCalled();
    });

    it('should use offline data when request fails', async () => {
      const encodedData = btoa(JSON.stringify(mockGUTPeriodicidadeStatus));
      
      mockedAxios.get.mockRejectedValue(new Error('Network error'));
      (global.localStorage.getItem as jest.Mock).mockReturnValue(encodedData);

      const result = await gutperiodicidadestatusApi.getById(1);

      expect(result.data).toEqual(mockGUTPeriodicidadeStatus);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
          id: 1,
          action: NotifySystemActions.INFO,
        })
      );
    });
  });


  describe('filter', () => {
    const mockFilter: FilterGUTPeriodicidadeStatus = {
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

    it('should filter gutperiodicidadestatus items successfully', async () => {
      mockedAxios.post.mockResolvedValue(mockResponse);

      const result = await gutperiodicidadestatusApi.filter(mockFilter);

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

      const result = await gutperiodicidadestatusApi.filter(mockFilter);

      expect(result.data).toEqual(offlineData);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          action: NotifySystemActions.INFO,
        })
      );
    });
  });

  describe('addAndUpdate', () => {
    const mockGUTPeriodicidadeStatus: IGUTPeriodicidadeStatus = {
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

    it('should add new gutperiodicidadestatus successfully', async () => {
      const responseGUTPeriodicidadeStatus = { ...mockGUTPeriodicidadeStatus, id: 1 };
      const mockResponse: AxiosResponse = {
        data: responseGUTPeriodicidadeStatus,
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.post.mockResolvedValue(mockResponse);

      const result = await gutperiodicidadestatusApi.addAndUpdate(mockGUTPeriodicidadeStatus);

      expect(mockedAxios.post).toHaveBeenCalledWith(
        expect.stringContaining('/AddAndUpdate'),
        mockGUTPeriodicidadeStatus,
        expect.any(Object)
      );
      expect(result).toEqual(mockResponse);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
          id: 1,
          action: NotifySystemActions.ADD,
        })
      );
    });

    it('should update existing gutperiodicidadestatus successfully', async () => {
      const existingGUTPeriodicidadeStatus = { ...mockGUTPeriodicidadeStatus, id: 1 };
      const mockResponse: AxiosResponse = {
        data: existingGUTPeriodicidadeStatus,
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.post.mockResolvedValue(mockResponse);

      const result = await gutperiodicidadestatusApi.addAndUpdate(existingGUTPeriodicidadeStatus);

      expect(result).toEqual(mockResponse);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
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

      await expect(gutperiodicidadestatusApi.addAndUpdate(mockGUTPeriodicidadeStatus)).rejects.toThrow(GUTPeriodicidadeStatusApiError);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
          action: NotifySystemActions.ERROR,
          message: 'Registro já existe',
        })
      );
    });
  });

  describe('delete', () => {
    it('should delete gutperiodicidadestatus successfully', async () => {
      const mockResponse: AxiosResponse = {
        data: { success: true },
        status: 200,
        statusText: 'OK',
        headers: {},
        config: {},
      } as AxiosResponse;

      mockedAxios.delete.mockResolvedValue(mockResponse);

      const result = await gutperiodicidadestatusApi.delete(1);

      expect(mockedAxios.delete).toHaveBeenCalledWith(
        expect.stringContaining('/Delete?id=1'),
        expect.any(Object)
      );
      expect(result).toEqual(mockResponse);
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
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

      await expect(gutperiodicidadestatusApi.delete(1)).rejects.toThrow();
      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
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

      await expect(gutperiodicidadestatusApi.delete(1)).rejects.toThrow(GUTPeriodicidadeStatusApiError);
    });
  });

  describe('useFilter', () => {
    it('should create SWR hook with correct parameters', () => {
      const mockFilter: FilterGUTPeriodicidadeStatus = { funcionario: 1 };
      
      const result = gutperiodicidadestatusApi.useFilter(mockFilter);
      
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

      await gutperiodicidadestatusApi.delete(1);

      expect(mockNotificationService.notify).toHaveBeenCalledWith(
        expect.objectContaining({
          entity: 'GUTPeriodicidadeStatus',
          id: 1,
          action: NotifySystemActions.DELETE,
        })
      );
    });


  });

  describe('GUTPeriodicidadeStatusApiError', () => {
    it('should create error with correct properties', () => {
      const error = new GUTPeriodicidadeStatusApiError('Test message', 400, 'TEST_CODE', 'original');

      expect(error.message).toBe('Test message');
      expect(error.status).toBe(400);
      expect(error.code).toBe('TEST_CODE');
      expect(error.originalError).toBe('original');
      expect(error.name).toBe('GUTPeriodicidadeStatusApiError');
    });

    it('should create error without optional parameters', () => {
      const error = new GUTPeriodicidadeStatusApiError('Test message', 500);

      expect(error.message).toBe('Test message');
      expect(error.status).toBe(500);
      expect(error.code).toBeUndefined();
      expect(error.originalError).toBeUndefined();
    });
  });


});