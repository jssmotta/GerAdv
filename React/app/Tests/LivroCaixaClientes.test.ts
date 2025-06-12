// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useLivroCaixaClientesForm, useLivroCaixaClientesList, useValidationsLivroCaixaClientes } from '../GerAdv_TS/LivroCaixaClientes/Hooks/hookLivroCaixaClientes';
import { ILivroCaixaClientes } from '../GerAdv_TS/LivroCaixaClientes/Interfaces/interface.LivroCaixaClientes';
import { ILivroCaixaClientesService } from '../GerAdv_TS/LivroCaixaClientes/Services/LivroCaixaClientes.service';
import { LivroCaixaClientesTestEmpty } from '../GerAdv_TS/Models/LivroCaixaClientes';


// Mock do serviço
const mockLivroCaixaClientesService: jest.Mocked<ILivroCaixaClientesService> = {
  fetchLivroCaixaClientesById: jest.fn(),
  saveLivroCaixaClientes: jest.fn(),
  
  getAll: jest.fn(),
  deleteLivroCaixaClientes: jest.fn(),
  validateLivroCaixaClientes: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialLivroCaixaClientes: ILivroCaixaClientes = { ...LivroCaixaClientesTestEmpty() };

describe('useLivroCaixaClientesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    expect(result.current.data).toEqual(initialLivroCaixaClientes);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Livro Caixa Clientes',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Livro Caixa Clientes');
  });

   test('deve carregar Livro Caixa Clientes por ID', async () => {
    const mockLivroCaixaClientes = { ...initialLivroCaixaClientes, id: 1, campo: 'Livro Caixa Clientes Teste' };
    mockLivroCaixaClientesService.fetchLivroCaixaClientesById.mockResolvedValue(mockLivroCaixaClientes);

    const { result } = renderHook(() => 
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    await act(async () => {
      await result.current.loadLivroCaixaClientes(1);
    });

    expect(mockLivroCaixaClientesService.fetchLivroCaixaClientesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockLivroCaixaClientes);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Livro Caixa Clientes', async () => {
    const errorMessage = 'Erro ao carregar Livro Caixa Clientes';
    mockLivroCaixaClientesService.fetchLivroCaixaClientesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    await act(async () => {
      await result.current.loadLivroCaixaClientes(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialLivroCaixaClientes, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialLivroCaixaClientes);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    await act(async () => {
      await result.current.loadLivroCaixaClientes(0);
    });

    expect(mockLivroCaixaClientesService.fetchLivroCaixaClientesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialLivroCaixaClientes);
  });
});

describe('useLivroCaixaClientesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useLivroCaixaClientesList(mockLivroCaixaClientesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialLivroCaixaClientes, id: 1, campo: 'Livro Caixa Clientes 1' },
      { ...initialLivroCaixaClientes, id: 2, campo: 'Livro Caixa Clientes 2' }
    ];
    mockLivroCaixaClientesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useLivroCaixaClientesList(mockLivroCaixaClientesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockLivroCaixaClientesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockLivroCaixaClientesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useLivroCaixaClientesList(mockLivroCaixaClientesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialLivroCaixaClientes, id: 1, campo: 'Livro Caixa Clientes Filtrado' }];
    const filtro = { campo: 'Livro Caixa Clientes' };
    mockLivroCaixaClientesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useLivroCaixaClientesList(mockLivroCaixaClientesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockLivroCaixaClientesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsLivroCaixaClientes', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsLivroCaixaClientes());

    const validData = { ...initialLivroCaixaClientes, campo: 'Livro Caixa Clientes Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsLivroCaixaClientes());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialLivroCaixaClientes, id: 1, campo: 'Livro Caixa Clientes Teste' }];
    mockLivroCaixaClientesService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useLivroCaixaClientesList(mockLivroCaixaClientesService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsLivroCaixaClientes()
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
      useLivroCaixaClientesForm(initialLivroCaixaClientes, mockLivroCaixaClientesService)
    );

    const mockEvent = {
      target: {
        name: 'lancado',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.lancado).toBe(true);
  });


