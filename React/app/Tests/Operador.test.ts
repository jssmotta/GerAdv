// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useOperadorForm, useOperadorList, useValidationsOperador } from '../GerAdv_TS/Operador/Hooks/hookOperador';
import { IOperador } from '../GerAdv_TS/Operador/Interfaces/interface.Operador';
import { IOperadorService } from '../GerAdv_TS/Operador/Services/Operador.service';
import { OperadorTestEmpty } from '../GerAdv_TS/Models/Operador';
import { useOperadorComboBox } from '../GerAdv_TS/Operador/Hooks/hookOperador';

// Mock do serviço
const mockOperadorService: jest.Mocked<IOperadorService> = {
  fetchOperadorById: jest.fn(),
  saveOperador: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteOperador: jest.fn(),
  validateOperador: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialOperador: IOperador = { ...OperadorTestEmpty() };

describe('useOperadorForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    expect(result.current.data).toEqual(initialOperador);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Operador',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Operador');
  });

   test('deve carregar Operador por ID', async () => {
    const mockOperador = { ...initialOperador, id: 1, nome: 'Operador Teste' };
    mockOperadorService.fetchOperadorById.mockResolvedValue(mockOperador);

    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    await act(async () => {
      await result.current.loadOperador(1);
    });

    expect(mockOperadorService.fetchOperadorById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockOperador);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Operador', async () => {
    const errorMessage = 'Erro ao carregar Operador';
    mockOperadorService.fetchOperadorById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    await act(async () => {
      await result.current.loadOperador(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialOperador, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialOperador);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    await act(async () => {
      await result.current.loadOperador(0);
    });

    expect(mockOperadorService.fetchOperadorById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialOperador);
  });
});

describe('useOperadorList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadorList(mockOperadorService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialOperador, id: 1, nome: 'Operador 1' },
      { ...initialOperador, id: 2, nome: 'Operador 2' }
    ];
    mockOperadorService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadorList(mockOperadorService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockOperadorService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockOperadorService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadorList(mockOperadorService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialOperador, id: 1, nome: 'Operador Filtrado' }];
    const filtro = { nome: 'Operador' };
    mockOperadorService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadorList(mockOperadorService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockOperadorService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsOperador', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsOperador());

    const validData = { ...initialOperador, nome: 'Operador Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsOperador());

    const invalidData = { ...initialOperador, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsOperador());

    const invalidData = { 
      ...initialOperador, 
      nome: 'a'.repeat(40+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 40 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsOperador());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialOperador, id: 1, nome: 'Operador Teste' }];
    mockOperadorService.getAll.mockResolvedValue(mockData);
    mockOperadorService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useOperadorList(mockOperadorService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useOperadorComboBox(mockOperadorService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsOperador()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Operador Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Operador Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useOperadorForm(initialOperador, mockOperadorService)
    );

    const mockEvent = {
      target: {
        name: 'telefonista',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.telefonista).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador 1' },
      { id: 2, nome: 'Operador 2' }
    ];
    mockOperadorService.getList.mockResolvedValue(mockOptions as IOperador[]);


    const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador 1' },
        { id: 2, nome: 'Operador 2' }
      ]);
    });

    expect(mockOperadorService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador ABC' },
      { id: 2, nome: 'Operador XYZ' }
    ];
    mockOperadorService.getList.mockResolvedValue(mockOptions as IOperador[]);   


 const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador ABC' },
        { id: 2, nome: 'Operador XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Operador ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador ABC' },
      { id: 2, nome: 'Operador XYZ' }
    ];
    mockOperadorService.getList.mockResolvedValue(mockOptions as IOperador[]);
  


    const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador ABC' },
        { id: 2, nome: 'Operador XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    // Remove filtro
    act(() => {
      result.current.handleFilter('');
    });
 

     expect(result.current.options).toEqual([
          {id: 1, nome: 'Operador ABC' },
          {id: 2, nome: 'Operador XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService)
    );

    const newValue = { id: 1, nome: 'Operador Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Operador Inicial' };
    
    const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useOperadorComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Operador Inicial' };
    
    const { result } = renderHook(() => 
      useOperadorComboBox(mockOperadorService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






