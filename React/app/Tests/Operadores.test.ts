// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useOperadoresForm, useOperadoresList, useValidationsOperadores } from '../GerAdv_TS/Operadores/Hooks/hookOperadores';
import { IOperadores } from '../GerAdv_TS/Operadores/Interfaces/interface.Operadores';
import { IOperadoresService } from '../GerAdv_TS/Operadores/Services/Operadores.service';
import { OperadoresTestEmpty } from '../GerAdv_TS/Models/Operadores';
import { useOperadoresComboBox } from '../GerAdv_TS/Operadores/Hooks/hookOperadores';

// Mock do serviço
const mockOperadoresService: jest.Mocked<IOperadoresService> = {
  fetchOperadoresById: jest.fn(),
  saveOperadores: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteOperadores: jest.fn(),
  validateOperadores: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialOperadores: IOperadores = { ...OperadoresTestEmpty() };

describe('useOperadoresForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useOperadoresForm(initialOperadores, mockOperadoresService)
    );

    expect(result.current.data).toEqual(initialOperadores);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useOperadoresForm(initialOperadores, mockOperadoresService)
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
    const mockOperadores = { ...initialOperadores, id: 1, nome: 'Operador Teste' };
    mockOperadoresService.fetchOperadoresById.mockResolvedValue(mockOperadores);

    const { result } = renderHook(() => 
      useOperadoresForm(initialOperadores, mockOperadoresService)
    );

    await act(async () => {
      await result.current.loadOperadores(1);
    });

    expect(mockOperadoresService.fetchOperadoresById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockOperadores);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Operador', async () => {
    const errorMessage = 'Erro ao carregar Operador';
    mockOperadoresService.fetchOperadoresById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadoresForm(initialOperadores, mockOperadoresService)
    );

    await act(async () => {
      await result.current.loadOperadores(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useOperadoresForm(initialOperadores, mockOperadoresService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialOperadores, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialOperadores);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useOperadoresForm(initialOperadores, mockOperadoresService)
    );

    await act(async () => {
      await result.current.loadOperadores(0);
    });

    expect(mockOperadoresService.fetchOperadoresById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialOperadores);
  });
});

describe('useOperadoresList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadoresList(mockOperadoresService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialOperadores, id: 1, nome: 'Operador 1' },
      { ...initialOperadores, id: 2, nome: 'Operador 2' }
    ];
    mockOperadoresService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadoresList(mockOperadoresService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockOperadoresService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockOperadoresService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadoresList(mockOperadoresService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialOperadores, id: 1, nome: 'Operador Filtrado' }];
    const filtro = { nome: 'Operador' };
    mockOperadoresService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadoresList(mockOperadoresService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockOperadoresService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsOperadores', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsOperadores());

    const validData = { ...initialOperadores, nome: 'Operador Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsOperadores());

    const invalidData = { ...initialOperadores, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsOperadores());

    const invalidData = { 
      ...initialOperadores, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsOperadores());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialOperadores, id: 1, nome: 'Operador Teste' }];
    mockOperadoresService.getAll.mockResolvedValue(mockData);
    mockOperadoresService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useOperadoresList(mockOperadoresService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useOperadoresComboBox(mockOperadoresService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsOperadores()
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
      useOperadoresForm(initialOperadores, mockOperadoresService)
    );

    const mockEvent = {
      target: {
        name: 'enviado',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.enviado).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador 1' },
      { id: 2, nome: 'Operador 2' }
    ];
    mockOperadoresService.getList.mockResolvedValue(mockOptions as IOperadores[]);


    const { result } = renderHook(() => 
      useOperadoresComboBox(mockOperadoresService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador 1' },
        { id: 2, nome: 'Operador 2' }
      ]);
    });


    expect(mockOperadoresService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador ABC' },
      { id: 2, nome: 'Operador XYZ' }
    ];
    mockOperadoresService.getList.mockResolvedValue(mockOptions as IOperadores[]);   


 const { result } = renderHook(() => 
      useOperadoresComboBox(mockOperadoresService)
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
    mockOperadoresService.getList.mockResolvedValue(mockOptions as IOperadores[]);
  


    const { result } = renderHook(() => 
      useOperadoresComboBox(mockOperadoresService)
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
      useOperadoresComboBox(mockOperadoresService)
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
      useOperadoresComboBox(mockOperadoresService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useOperadoresComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadoresComboBox(mockOperadoresService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Operador Inicial' };
    
    const { result } = renderHook(() => 
      useOperadoresComboBox(mockOperadoresService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






