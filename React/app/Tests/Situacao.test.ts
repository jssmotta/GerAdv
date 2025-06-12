// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useSituacaoForm, useSituacaoList, useValidationsSituacao } from '../GerAdv_TS/Situacao/Hooks/hookSituacao';
import { ISituacao } from '../GerAdv_TS/Situacao/Interfaces/interface.Situacao';
import { ISituacaoService } from '../GerAdv_TS/Situacao/Services/Situacao.service';
import { SituacaoTestEmpty } from '../GerAdv_TS/Models/Situacao';


// Mock do serviço
const mockSituacaoService: jest.Mocked<ISituacaoService> = {
  fetchSituacaoById: jest.fn(),
  saveSituacao: jest.fn(),
  
  getAll: jest.fn(),
  deleteSituacao: jest.fn(),
  validateSituacao: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialSituacao: ISituacao = { ...SituacaoTestEmpty() };

describe('useSituacaoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    expect(result.current.data).toEqual(initialSituacao);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    const mockEvent = {
      target: {
        name: 'parte_int',
        value: 'Novo Situacao',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.parte_int).toBe('Novo Situacao');
  });

   test('deve carregar Situacao por ID', async () => {
    const mockSituacao = { ...initialSituacao, id: 1, parte_int: 'Situacao Teste' };
    mockSituacaoService.fetchSituacaoById.mockResolvedValue(mockSituacao);

    const { result } = renderHook(() => 
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    await act(async () => {
      await result.current.loadSituacao(1);
    });

    expect(mockSituacaoService.fetchSituacaoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockSituacao);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Situacao', async () => {
    const errorMessage = 'Erro ao carregar Situacao';
    mockSituacaoService.fetchSituacaoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    await act(async () => {
      await result.current.loadSituacao(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialSituacao, parte_int: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialSituacao);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    await act(async () => {
      await result.current.loadSituacao(0);
    });

    expect(mockSituacaoService.fetchSituacaoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialSituacao);
  });
});

describe('useSituacaoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useSituacaoList(mockSituacaoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialSituacao, id: 1, parte_int: 'Situacao 1' },
      { ...initialSituacao, id: 2, parte_int: 'Situacao 2' }
    ];
    mockSituacaoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useSituacaoList(mockSituacaoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockSituacaoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockSituacaoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useSituacaoList(mockSituacaoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialSituacao, id: 1, parte_int: 'Situacao Filtrado' }];
    const filtro = { parte_int: 'Situacao' };
    mockSituacaoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useSituacaoList(mockSituacaoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockSituacaoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsSituacao', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsSituacao());

    const validData = { ...initialSituacao, parte_int: 'Situacao Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsSituacao());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialSituacao, id: 1, parte_int: 'Situacao Teste' }];
    mockSituacaoService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useSituacaoList(mockSituacaoService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsSituacao()
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
      useSituacaoForm(initialSituacao, mockSituacaoService)
    );

    const mockEvent = {
      target: {
        name: 'top',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.top).toBe(true);
  });


