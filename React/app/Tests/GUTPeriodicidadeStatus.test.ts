// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useGUTPeriodicidadeStatusForm, useGUTPeriodicidadeStatusList, useValidationsGUTPeriodicidadeStatus } from '../GerAdv_TS/GUTPeriodicidadeStatus/Hooks/hookGUTPeriodicidadeStatus';
import { IGUTPeriodicidadeStatus } from '../GerAdv_TS/GUTPeriodicidadeStatus/Interfaces/interface.GUTPeriodicidadeStatus';
import { IGUTPeriodicidadeStatusService } from '../GerAdv_TS/GUTPeriodicidadeStatus/Services/GUTPeriodicidadeStatus.service';
import { GUTPeriodicidadeStatusTestEmpty } from '../GerAdv_TS/Models/GUTPeriodicidadeStatus';


// Mock do serviço
const mockGUTPeriodicidadeStatusService: jest.Mocked<IGUTPeriodicidadeStatusService> = {
  fetchGUTPeriodicidadeStatusById: jest.fn(),
  saveGUTPeriodicidadeStatus: jest.fn(),
  
  getAll: jest.fn(),
  deleteGUTPeriodicidadeStatus: jest.fn(),
  validateGUTPeriodicidadeStatus: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialGUTPeriodicidadeStatus: IGUTPeriodicidadeStatus = { ...GUTPeriodicidadeStatusTestEmpty() };

describe('useGUTPeriodicidadeStatusForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusForm(initialGUTPeriodicidadeStatus, mockGUTPeriodicidadeStatusService)
    );

    expect(result.current.data).toEqual(initialGUTPeriodicidadeStatus);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusForm(initialGUTPeriodicidadeStatus, mockGUTPeriodicidadeStatusService)
    );

    const mockEvent = {
      target: {
        name: 'guid',
        value: 'Novo G U T Periodicidade Status',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.guid).toBe('Novo G U T Periodicidade Status');
  });

   test('deve carregar G U T Periodicidade Status por ID', async () => {
    const mockGUTPeriodicidadeStatus = { ...initialGUTPeriodicidadeStatus, id: 1, guid: 'G U T Periodicidade Status Teste' };
    mockGUTPeriodicidadeStatusService.fetchGUTPeriodicidadeStatusById.mockResolvedValue(mockGUTPeriodicidadeStatus);

    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusForm(initialGUTPeriodicidadeStatus, mockGUTPeriodicidadeStatusService)
    );

    await act(async () => {
      await result.current.loadGUTPeriodicidadeStatus(1);
    });

    expect(mockGUTPeriodicidadeStatusService.fetchGUTPeriodicidadeStatusById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockGUTPeriodicidadeStatus);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar G U T Periodicidade Status', async () => {
    const errorMessage = 'Erro ao carregar G U T Periodicidade Status';
    mockGUTPeriodicidadeStatusService.fetchGUTPeriodicidadeStatusById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusForm(initialGUTPeriodicidadeStatus, mockGUTPeriodicidadeStatusService)
    );

    await act(async () => {
      await result.current.loadGUTPeriodicidadeStatus(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusForm(initialGUTPeriodicidadeStatus, mockGUTPeriodicidadeStatusService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialGUTPeriodicidadeStatus, guid: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialGUTPeriodicidadeStatus);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusForm(initialGUTPeriodicidadeStatus, mockGUTPeriodicidadeStatusService)
    );

    await act(async () => {
      await result.current.loadGUTPeriodicidadeStatus(0);
    });

    expect(mockGUTPeriodicidadeStatusService.fetchGUTPeriodicidadeStatusById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialGUTPeriodicidadeStatus);
  });
});

describe('useGUTPeriodicidadeStatusList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusList(mockGUTPeriodicidadeStatusService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialGUTPeriodicidadeStatus, id: 1, guid: 'G U T Periodicidade Status 1' },
      { ...initialGUTPeriodicidadeStatus, id: 2, guid: 'G U T Periodicidade Status 2' }
    ];
    mockGUTPeriodicidadeStatusService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusList(mockGUTPeriodicidadeStatusService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockGUTPeriodicidadeStatusService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockGUTPeriodicidadeStatusService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusList(mockGUTPeriodicidadeStatusService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialGUTPeriodicidadeStatus, id: 1, guid: 'G U T Periodicidade Status Filtrado' }];
    const filtro = { guid: 'G U T Periodicidade Status' };
    mockGUTPeriodicidadeStatusService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTPeriodicidadeStatusList(mockGUTPeriodicidadeStatusService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockGUTPeriodicidadeStatusService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsGUTPeriodicidadeStatus', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsGUTPeriodicidadeStatus());

    const validData = { ...initialGUTPeriodicidadeStatus, guid: 'G U T Periodicidade Status Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsGUTPeriodicidadeStatus());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialGUTPeriodicidadeStatus, id: 1, guid: 'G U T Periodicidade Status Teste' }];
    mockGUTPeriodicidadeStatusService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useGUTPeriodicidadeStatusList(mockGUTPeriodicidadeStatusService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsGUTPeriodicidadeStatus()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
    
  
    expect(validation.isValid).toBe(true);
  });
});