// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useProDespesasForm, useProDespesasList, useValidationsProDespesas } from '../GerAdv_TS/ProDespesas/Hooks/hookProDespesas';
import { IProDespesas } from '../GerAdv_TS/ProDespesas/Interfaces/interface.ProDespesas';
import { IProDespesasService } from '../GerAdv_TS/ProDespesas/Services/ProDespesas.service';
import { ProDespesasTestEmpty } from '../GerAdv_TS/Models/ProDespesas';


// Mock do serviço
const mockProDespesasService: jest.Mocked<IProDespesasService> = {
  fetchProDespesasById: jest.fn(),
  saveProDespesas: jest.fn(),
  
  getAll: jest.fn(),
  deleteProDespesas: jest.fn(),
  validateProDespesas: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialProDespesas: IProDespesas = { ...ProDespesasTestEmpty() };

describe('useProDespesasForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    expect(result.current.data).toEqual(initialProDespesas);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    const mockEvent = {
      target: {
        name: 'historico',
        value: 'Novo Pro Despesas',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.historico).toBe('Novo Pro Despesas');
  });

   test('deve carregar Pro Despesas por ID', async () => {
    const mockProDespesas = { ...initialProDespesas, id: 1, historico: 'Pro Despesas Teste' };
    mockProDespesasService.fetchProDespesasById.mockResolvedValue(mockProDespesas);

    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    await act(async () => {
      await result.current.loadProDespesas(1);
    });

    expect(mockProDespesasService.fetchProDespesasById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockProDespesas);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Pro Despesas', async () => {
    const errorMessage = 'Erro ao carregar Pro Despesas';
    mockProDespesasService.fetchProDespesasById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    await act(async () => {
      await result.current.loadProDespesas(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialProDespesas, historico: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialProDespesas);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    await act(async () => {
      await result.current.loadProDespesas(0);
    });

    expect(mockProDespesasService.fetchProDespesasById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialProDespesas);
  });
});

describe('useProDespesasList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProDespesasList(mockProDespesasService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialProDespesas, id: 1, historico: 'Pro Despesas 1' },
      { ...initialProDespesas, id: 2, historico: 'Pro Despesas 2' }
    ];
    mockProDespesasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProDespesasList(mockProDespesasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockProDespesasService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockProDespesasService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProDespesasList(mockProDespesasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialProDespesas, id: 1, historico: 'Pro Despesas Filtrado' }];
    const filtro = { historico: 'Pro Despesas' };
    mockProDespesasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProDespesasList(mockProDespesasService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockProDespesasService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsProDespesas', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsProDespesas());

    const validData = { ...initialProDespesas, historico: 'Pro Despesas Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsProDespesas());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialProDespesas, id: 1, historico: 'Pro Despesas Teste' }];
    mockProDespesasService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useProDespesasList(mockProDespesasService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsProDespesas()
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
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useProDespesasForm(initialProDespesas, mockProDespesasService)
    );

    const mockEvent = {
      target: {
        name: 'corrigido',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.corrigido).toBe(true);
  });


