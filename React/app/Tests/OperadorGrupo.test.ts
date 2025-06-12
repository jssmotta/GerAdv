// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useOperadorGrupoForm, useOperadorGrupoList, useValidationsOperadorGrupo } from '../GerAdv_TS/OperadorGrupo/Hooks/hookOperadorGrupo';
import { IOperadorGrupo } from '../GerAdv_TS/OperadorGrupo/Interfaces/interface.OperadorGrupo';
import { IOperadorGrupoService } from '../GerAdv_TS/OperadorGrupo/Services/OperadorGrupo.service';
import { OperadorGrupoTestEmpty } from '../GerAdv_TS/Models/OperadorGrupo';


// Mock do serviço
const mockOperadorGrupoService: jest.Mocked<IOperadorGrupoService> = {
  fetchOperadorGrupoById: jest.fn(),
  saveOperadorGrupo: jest.fn(),
  
  getAll: jest.fn(),
  deleteOperadorGrupo: jest.fn(),
  validateOperadorGrupo: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialOperadorGrupo: IOperadorGrupo = { ...OperadorGrupoTestEmpty() };

describe('useOperadorGrupoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    expect(result.current.data).toEqual(initialOperadorGrupo);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Operador Grupo',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Operador Grupo');
  });

   test('deve carregar Operador Grupo por ID', async () => {
    const mockOperadorGrupo = { ...initialOperadorGrupo, id: 1, campo: 'Operador Grupo Teste' };
    mockOperadorGrupoService.fetchOperadorGrupoById.mockResolvedValue(mockOperadorGrupo);

    const { result } = renderHook(() => 
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    await act(async () => {
      await result.current.loadOperadorGrupo(1);
    });

    expect(mockOperadorGrupoService.fetchOperadorGrupoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockOperadorGrupo);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Operador Grupo', async () => {
    const errorMessage = 'Erro ao carregar Operador Grupo';
    mockOperadorGrupoService.fetchOperadorGrupoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    await act(async () => {
      await result.current.loadOperadorGrupo(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialOperadorGrupo, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialOperadorGrupo);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    await act(async () => {
      await result.current.loadOperadorGrupo(0);
    });

    expect(mockOperadorGrupoService.fetchOperadorGrupoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialOperadorGrupo);
  });
});

describe('useOperadorGrupoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadorGrupoList(mockOperadorGrupoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialOperadorGrupo, id: 1, campo: 'Operador Grupo 1' },
      { ...initialOperadorGrupo, id: 2, campo: 'Operador Grupo 2' }
    ];
    mockOperadorGrupoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadorGrupoList(mockOperadorGrupoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockOperadorGrupoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockOperadorGrupoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadorGrupoList(mockOperadorGrupoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialOperadorGrupo, id: 1, campo: 'Operador Grupo Filtrado' }];
    const filtro = { campo: 'Operador Grupo' };
    mockOperadorGrupoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadorGrupoList(mockOperadorGrupoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockOperadorGrupoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsOperadorGrupo', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsOperadorGrupo());

    const validData = { ...initialOperadorGrupo, campo: 'Operador Grupo Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsOperadorGrupo());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialOperadorGrupo, id: 1, campo: 'Operador Grupo Teste' }];
    mockOperadorGrupoService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useOperadorGrupoList(mockOperadorGrupoService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsOperadorGrupo()
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
      useOperadorGrupoForm(initialOperadorGrupo, mockOperadorGrupoService)
    );

    const mockEvent = {
      target: {
        name: 'inativo',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.inativo).toBe(true);
  });


