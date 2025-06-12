// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useGUTAtividadesMatrizForm, useGUTAtividadesMatrizList, useValidationsGUTAtividadesMatriz } from '../GerAdv_TS/GUTAtividadesMatriz/Hooks/hookGUTAtividadesMatriz';
import { IGUTAtividadesMatriz } from '../GerAdv_TS/GUTAtividadesMatriz/Interfaces/interface.GUTAtividadesMatriz';
import { IGUTAtividadesMatrizService } from '../GerAdv_TS/GUTAtividadesMatriz/Services/GUTAtividadesMatriz.service';
import { GUTAtividadesMatrizTestEmpty } from '../GerAdv_TS/Models/GUTAtividadesMatriz';


// Mock do serviço
const mockGUTAtividadesMatrizService: jest.Mocked<IGUTAtividadesMatrizService> = {
  fetchGUTAtividadesMatrizById: jest.fn(),
  saveGUTAtividadesMatriz: jest.fn(),
  
  getAll: jest.fn(),
  deleteGUTAtividadesMatriz: jest.fn(),
  validateGUTAtividadesMatriz: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialGUTAtividadesMatriz: IGUTAtividadesMatriz = { ...GUTAtividadesMatrizTestEmpty() };

describe('useGUTAtividadesMatrizForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesMatrizForm(initialGUTAtividadesMatriz, mockGUTAtividadesMatrizService)
    );

    expect(result.current.data).toEqual(initialGUTAtividadesMatriz);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesMatrizForm(initialGUTAtividadesMatriz, mockGUTAtividadesMatrizService)
    );

    const mockEvent = {
      target: {
        name: 'guid',
        value: 'Novo G U T Atividades Matriz',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.guid).toBe('Novo G U T Atividades Matriz');
  });

   test('deve carregar G U T Atividades Matriz por ID', async () => {
    const mockGUTAtividadesMatriz = { ...initialGUTAtividadesMatriz, id: 1, guid: 'G U T Atividades Matriz Teste' };
    mockGUTAtividadesMatrizService.fetchGUTAtividadesMatrizById.mockResolvedValue(mockGUTAtividadesMatriz);

    const { result } = renderHook(() => 
      useGUTAtividadesMatrizForm(initialGUTAtividadesMatriz, mockGUTAtividadesMatrizService)
    );

    await act(async () => {
      await result.current.loadGUTAtividadesMatriz(1);
    });

    expect(mockGUTAtividadesMatrizService.fetchGUTAtividadesMatrizById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockGUTAtividadesMatriz);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar G U T Atividades Matriz', async () => {
    const errorMessage = 'Erro ao carregar G U T Atividades Matriz';
    mockGUTAtividadesMatrizService.fetchGUTAtividadesMatrizById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTAtividadesMatrizForm(initialGUTAtividadesMatriz, mockGUTAtividadesMatrizService)
    );

    await act(async () => {
      await result.current.loadGUTAtividadesMatriz(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesMatrizForm(initialGUTAtividadesMatriz, mockGUTAtividadesMatrizService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialGUTAtividadesMatriz, guid: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialGUTAtividadesMatriz);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useGUTAtividadesMatrizForm(initialGUTAtividadesMatriz, mockGUTAtividadesMatrizService)
    );

    await act(async () => {
      await result.current.loadGUTAtividadesMatriz(0);
    });

    expect(mockGUTAtividadesMatrizService.fetchGUTAtividadesMatrizById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialGUTAtividadesMatriz);
  });
});

describe('useGUTAtividadesMatrizList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesMatrizList(mockGUTAtividadesMatrizService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialGUTAtividadesMatriz, id: 1, guid: 'G U T Atividades Matriz 1' },
      { ...initialGUTAtividadesMatriz, id: 2, guid: 'G U T Atividades Matriz 2' }
    ];
    mockGUTAtividadesMatrizService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTAtividadesMatrizList(mockGUTAtividadesMatrizService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockGUTAtividadesMatrizService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockGUTAtividadesMatrizService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTAtividadesMatrizList(mockGUTAtividadesMatrizService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialGUTAtividadesMatriz, id: 1, guid: 'G U T Atividades Matriz Filtrado' }];
    const filtro = { guid: 'G U T Atividades Matriz' };
    mockGUTAtividadesMatrizService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTAtividadesMatrizList(mockGUTAtividadesMatrizService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockGUTAtividadesMatrizService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsGUTAtividadesMatriz', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsGUTAtividadesMatriz());

    const validData = { ...initialGUTAtividadesMatriz, guid: 'G U T Atividades Matriz Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsGUTAtividadesMatriz());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialGUTAtividadesMatriz, id: 1, guid: 'G U T Atividades Matriz Teste' }];
    mockGUTAtividadesMatrizService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useGUTAtividadesMatrizList(mockGUTAtividadesMatrizService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsGUTAtividadesMatriz()
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