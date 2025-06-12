// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useProcessosParadosForm, useProcessosParadosList, useValidationsProcessosParados } from '../GerAdv_TS/ProcessosParados/Hooks/hookProcessosParados';
import { IProcessosParados } from '../GerAdv_TS/ProcessosParados/Interfaces/interface.ProcessosParados';
import { IProcessosParadosService } from '../GerAdv_TS/ProcessosParados/Services/ProcessosParados.service';
import { ProcessosParadosTestEmpty } from '../GerAdv_TS/Models/ProcessosParados';


// Mock do serviço
const mockProcessosParadosService: jest.Mocked<IProcessosParadosService> = {
  fetchProcessosParadosById: jest.fn(),
  saveProcessosParados: jest.fn(),
  
  getAll: jest.fn(),
  deleteProcessosParados: jest.fn(),
  validateProcessosParados: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialProcessosParados: IProcessosParados = { ...ProcessosParadosTestEmpty() };

describe('useProcessosParadosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useProcessosParadosForm(initialProcessosParados, mockProcessosParadosService)
    );

    expect(result.current.data).toEqual(initialProcessosParados);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useProcessosParadosForm(initialProcessosParados, mockProcessosParadosService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Processos Parados',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Processos Parados');
  });

   test('deve carregar Processos Parados por ID', async () => {
    const mockProcessosParados = { ...initialProcessosParados, id: 1, campo: 'Processos Parados Teste' };
    mockProcessosParadosService.fetchProcessosParadosById.mockResolvedValue(mockProcessosParados);

    const { result } = renderHook(() => 
      useProcessosParadosForm(initialProcessosParados, mockProcessosParadosService)
    );

    await act(async () => {
      await result.current.loadProcessosParados(1);
    });

    expect(mockProcessosParadosService.fetchProcessosParadosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockProcessosParados);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Processos Parados', async () => {
    const errorMessage = 'Erro ao carregar Processos Parados';
    mockProcessosParadosService.fetchProcessosParadosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessosParadosForm(initialProcessosParados, mockProcessosParadosService)
    );

    await act(async () => {
      await result.current.loadProcessosParados(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useProcessosParadosForm(initialProcessosParados, mockProcessosParadosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialProcessosParados, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialProcessosParados);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useProcessosParadosForm(initialProcessosParados, mockProcessosParadosService)
    );

    await act(async () => {
      await result.current.loadProcessosParados(0);
    });

    expect(mockProcessosParadosService.fetchProcessosParadosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialProcessosParados);
  });
});

describe('useProcessosParadosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessosParadosList(mockProcessosParadosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialProcessosParados, id: 1, campo: 'Processos Parados 1' },
      { ...initialProcessosParados, id: 2, campo: 'Processos Parados 2' }
    ];
    mockProcessosParadosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessosParadosList(mockProcessosParadosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockProcessosParadosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockProcessosParadosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessosParadosList(mockProcessosParadosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialProcessosParados, id: 1, campo: 'Processos Parados Filtrado' }];
    const filtro = { campo: 'Processos Parados' };
    mockProcessosParadosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessosParadosList(mockProcessosParadosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockProcessosParadosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsProcessosParados', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsProcessosParados());

    const validData = { ...initialProcessosParados, campo: 'Processos Parados Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsProcessosParados());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialProcessosParados, id: 1, campo: 'Processos Parados Teste' }];
    mockProcessosParadosService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useProcessosParadosList(mockProcessosParadosService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsProcessosParados()
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