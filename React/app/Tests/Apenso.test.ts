// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useApensoForm, useApensoList, useValidationsApenso } from '../GerAdv_TS/Apenso/Hooks/hookApenso';
import { IApenso } from '../GerAdv_TS/Apenso/Interfaces/interface.Apenso';
import { IApensoService } from '../GerAdv_TS/Apenso/Services/Apenso.service';
import { ApensoTestEmpty } from '../GerAdv_TS/Models/Apenso';


// Mock do serviço
const mockApensoService: jest.Mocked<IApensoService> = {
  fetchApensoById: jest.fn(),
  saveApenso: jest.fn(),
  
  getAll: jest.fn(),
  deleteApenso: jest.fn(),
  validateApenso: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialApenso: IApenso = { ...ApensoTestEmpty() };

describe('useApensoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useApensoForm(initialApenso, mockApensoService)
    );

    expect(result.current.data).toEqual(initialApenso);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useApensoForm(initialApenso, mockApensoService)
    );

    const mockEvent = {
      target: {
        name: 'apensox',
        value: 'Novo Apenso',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.apensox).toBe('Novo Apenso');
  });

   test('deve carregar Apenso por ID', async () => {
    const mockApenso = { ...initialApenso, id: 1, apensox: 'Apenso Teste' };
    mockApensoService.fetchApensoById.mockResolvedValue(mockApenso);

    const { result } = renderHook(() => 
      useApensoForm(initialApenso, mockApensoService)
    );

    await act(async () => {
      await result.current.loadApenso(1);
    });

    expect(mockApensoService.fetchApensoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockApenso);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Apenso', async () => {
    const errorMessage = 'Erro ao carregar Apenso';
    mockApensoService.fetchApensoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useApensoForm(initialApenso, mockApensoService)
    );

    await act(async () => {
      await result.current.loadApenso(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useApensoForm(initialApenso, mockApensoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialApenso, apensox: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialApenso);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useApensoForm(initialApenso, mockApensoService)
    );

    await act(async () => {
      await result.current.loadApenso(0);
    });

    expect(mockApensoService.fetchApensoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialApenso);
  });
});

describe('useApensoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useApensoList(mockApensoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialApenso, id: 1, apensox: 'Apenso 1' },
      { ...initialApenso, id: 2, apensox: 'Apenso 2' }
    ];
    mockApensoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useApensoList(mockApensoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockApensoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockApensoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useApensoList(mockApensoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialApenso, id: 1, apensox: 'Apenso Filtrado' }];
    const filtro = { apensox: 'Apenso' };
    mockApensoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useApensoList(mockApensoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockApensoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsApenso', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsApenso());

    const validData = { ...initialApenso, apensox: 'Apenso Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsApenso());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialApenso, id: 1, apensox: 'Apenso Teste' }];
    mockApensoService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useApensoList(mockApensoService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsApenso()
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