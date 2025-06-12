// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useContatoCRMOperadorForm, useContatoCRMOperadorList, useValidationsContatoCRMOperador } from '../GerAdv_TS/ContatoCRMOperador/Hooks/hookContatoCRMOperador';
import { IContatoCRMOperador } from '../GerAdv_TS/ContatoCRMOperador/Interfaces/interface.ContatoCRMOperador';
import { IContatoCRMOperadorService } from '../GerAdv_TS/ContatoCRMOperador/Services/ContatoCRMOperador.service';
import { ContatoCRMOperadorTestEmpty } from '../GerAdv_TS/Models/ContatoCRMOperador';


// Mock do serviço
const mockContatoCRMOperadorService: jest.Mocked<IContatoCRMOperadorService> = {
  fetchContatoCRMOperadorById: jest.fn(),
  saveContatoCRMOperador: jest.fn(),
  
  getAll: jest.fn(),
  deleteContatoCRMOperador: jest.fn(),
  validateContatoCRMOperador: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialContatoCRMOperador: IContatoCRMOperador = { ...ContatoCRMOperadorTestEmpty() };

describe('useContatoCRMOperadorForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useContatoCRMOperadorForm(initialContatoCRMOperador, mockContatoCRMOperadorService)
    );

    expect(result.current.data).toEqual(initialContatoCRMOperador);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useContatoCRMOperadorForm(initialContatoCRMOperador, mockContatoCRMOperadorService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Contato C R M Operador',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Contato C R M Operador');
  });

   test('deve carregar Contato C R M Operador por ID', async () => {
    const mockContatoCRMOperador = { ...initialContatoCRMOperador, id: 1, campo: 'Contato C R M Operador Teste' };
    mockContatoCRMOperadorService.fetchContatoCRMOperadorById.mockResolvedValue(mockContatoCRMOperador);

    const { result } = renderHook(() => 
      useContatoCRMOperadorForm(initialContatoCRMOperador, mockContatoCRMOperadorService)
    );

    await act(async () => {
      await result.current.loadContatoCRMOperador(1);
    });

    expect(mockContatoCRMOperadorService.fetchContatoCRMOperadorById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockContatoCRMOperador);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Contato C R M Operador', async () => {
    const errorMessage = 'Erro ao carregar Contato C R M Operador';
    mockContatoCRMOperadorService.fetchContatoCRMOperadorById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useContatoCRMOperadorForm(initialContatoCRMOperador, mockContatoCRMOperadorService)
    );

    await act(async () => {
      await result.current.loadContatoCRMOperador(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useContatoCRMOperadorForm(initialContatoCRMOperador, mockContatoCRMOperadorService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialContatoCRMOperador, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialContatoCRMOperador);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useContatoCRMOperadorForm(initialContatoCRMOperador, mockContatoCRMOperadorService)
    );

    await act(async () => {
      await result.current.loadContatoCRMOperador(0);
    });

    expect(mockContatoCRMOperadorService.fetchContatoCRMOperadorById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialContatoCRMOperador);
  });
});

describe('useContatoCRMOperadorList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useContatoCRMOperadorList(mockContatoCRMOperadorService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialContatoCRMOperador, id: 1, campo: 'Contato C R M Operador 1' },
      { ...initialContatoCRMOperador, id: 2, campo: 'Contato C R M Operador 2' }
    ];
    mockContatoCRMOperadorService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useContatoCRMOperadorList(mockContatoCRMOperadorService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockContatoCRMOperadorService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockContatoCRMOperadorService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useContatoCRMOperadorList(mockContatoCRMOperadorService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialContatoCRMOperador, id: 1, campo: 'Contato C R M Operador Filtrado' }];
    const filtro = { campo: 'Contato C R M Operador' };
    mockContatoCRMOperadorService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useContatoCRMOperadorList(mockContatoCRMOperadorService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockContatoCRMOperadorService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsContatoCRMOperador', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsContatoCRMOperador());

    const validData = { ...initialContatoCRMOperador, campo: 'Contato C R M Operador Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsContatoCRMOperador());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialContatoCRMOperador, id: 1, campo: 'Contato C R M Operador Teste' }];
    mockContatoCRMOperadorService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useContatoCRMOperadorList(mockContatoCRMOperadorService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsContatoCRMOperador()
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