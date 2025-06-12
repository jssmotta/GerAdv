// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useGraphForm, useGraphList, useValidationsGraph } from '../GerAdv_TS/Graph/Hooks/hookGraph';
import { IGraph } from '../GerAdv_TS/Graph/Interfaces/interface.Graph';
import { IGraphService } from '../GerAdv_TS/Graph/Services/Graph.service';
import { GraphTestEmpty } from '../GerAdv_TS/Models/Graph';


// Mock do serviço
const mockGraphService: jest.Mocked<IGraphService> = {
  fetchGraphById: jest.fn(),
  saveGraph: jest.fn(),
  
  getAll: jest.fn(),
  deleteGraph: jest.fn(),
  validateGraph: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialGraph: IGraph = { ...GraphTestEmpty() };

describe('useGraphForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useGraphForm(initialGraph, mockGraphService)
    );

    expect(result.current.data).toEqual(initialGraph);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useGraphForm(initialGraph, mockGraphService)
    );

    const mockEvent = {
      target: {
        name: 'tabela',
        value: 'Novo Graph',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.tabela).toBe('Novo Graph');
  });

   test('deve carregar Graph por ID', async () => {
    const mockGraph = { ...initialGraph, id: 1, tabela: 'Graph Teste' };
    mockGraphService.fetchGraphById.mockResolvedValue(mockGraph);

    const { result } = renderHook(() => 
      useGraphForm(initialGraph, mockGraphService)
    );

    await act(async () => {
      await result.current.loadGraph(1);
    });

    expect(mockGraphService.fetchGraphById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockGraph);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Graph', async () => {
    const errorMessage = 'Erro ao carregar Graph';
    mockGraphService.fetchGraphById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGraphForm(initialGraph, mockGraphService)
    );

    await act(async () => {
      await result.current.loadGraph(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useGraphForm(initialGraph, mockGraphService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialGraph, tabela: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialGraph);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useGraphForm(initialGraph, mockGraphService)
    );

    await act(async () => {
      await result.current.loadGraph(0);
    });

    expect(mockGraphService.fetchGraphById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialGraph);
  });
});

describe('useGraphList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGraphList(mockGraphService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialGraph, id: 1, tabela: 'Graph 1' },
      { ...initialGraph, id: 2, tabela: 'Graph 2' }
    ];
    mockGraphService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGraphList(mockGraphService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockGraphService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockGraphService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGraphList(mockGraphService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialGraph, id: 1, tabela: 'Graph Filtrado' }];
    const filtro = { tabela: 'Graph' };
    mockGraphService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGraphList(mockGraphService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockGraphService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsGraph', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsGraph());

    const validData = { ...initialGraph, tabela: 'Graph Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsGraph());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialGraph, id: 1, tabela: 'Graph Teste' }];
    mockGraphService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useGraphList(mockGraphService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsGraph()
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