// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useFuncionariosForm, useFuncionariosList, useValidationsFuncionarios } from '../GerAdv_TS/Funcionarios/Hooks/hookFuncionarios';
import { IFuncionarios } from '../GerAdv_TS/Funcionarios/Interfaces/interface.Funcionarios';
import { IFuncionariosService } from '../GerAdv_TS/Funcionarios/Services/Funcionarios.service';
import { FuncionariosTestEmpty } from '../GerAdv_TS/Models/Funcionarios';
import { useFuncionariosComboBox } from '../GerAdv_TS/Funcionarios/Hooks/hookFuncionarios';

// Mock do serviço
const mockFuncionariosService: jest.Mocked<IFuncionariosService> = {
  fetchFuncionariosById: jest.fn(),
  saveFuncionarios: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteFuncionarios: jest.fn(),
  validateFuncionarios: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialFuncionarios: IFuncionarios = { ...FuncionariosTestEmpty() };

describe('useFuncionariosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    expect(result.current.data).toEqual(initialFuncionarios);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Colaborador',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Colaborador');
  });

   test('deve carregar Colaborador por ID', async () => {
    const mockFuncionarios = { ...initialFuncionarios, id: 1, nome: 'Colaborador Teste' };
    mockFuncionariosService.fetchFuncionariosById.mockResolvedValue(mockFuncionarios);

    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    await act(async () => {
      await result.current.loadFuncionarios(1);
    });

    expect(mockFuncionariosService.fetchFuncionariosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockFuncionarios);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Colaborador', async () => {
    const errorMessage = 'Erro ao carregar Colaborador';
    mockFuncionariosService.fetchFuncionariosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    await act(async () => {
      await result.current.loadFuncionarios(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialFuncionarios, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialFuncionarios);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    await act(async () => {
      await result.current.loadFuncionarios(0);
    });

    expect(mockFuncionariosService.fetchFuncionariosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialFuncionarios);
  });
});

describe('useFuncionariosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useFuncionariosList(mockFuncionariosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialFuncionarios, id: 1, nome: 'Colaborador 1' },
      { ...initialFuncionarios, id: 2, nome: 'Colaborador 2' }
    ];
    mockFuncionariosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useFuncionariosList(mockFuncionariosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockFuncionariosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockFuncionariosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useFuncionariosList(mockFuncionariosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialFuncionarios, id: 1, nome: 'Colaborador Filtrado' }];
    const filtro = { nome: 'Colaborador' };
    mockFuncionariosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useFuncionariosList(mockFuncionariosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockFuncionariosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsFuncionarios', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsFuncionarios());

    const validData = { ...initialFuncionarios, nome: 'Colaborador Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsFuncionarios());

    const invalidData = { ...initialFuncionarios, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsFuncionarios());

    const invalidData = { 
      ...initialFuncionarios, 
      nome: 'a'.repeat(60+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 60 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsFuncionarios());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialFuncionarios, id: 1, nome: 'Colaborador Teste' }];
    mockFuncionariosService.getAll.mockResolvedValue(mockData);
    mockFuncionariosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useFuncionariosList(mockFuncionariosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsFuncionarios()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Colaborador Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Colaborador Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useFuncionariosForm(initialFuncionarios, mockFuncionariosService)
    );

    const mockEvent = {
      target: {
        name: 'liberaagenda',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.liberaagenda).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Colaborador 1' },
      { id: 2, nome: 'Colaborador 2' }
    ];
    mockFuncionariosService.getList.mockResolvedValue(mockOptions as IFuncionarios[]);


    const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Colaborador 1' },
        { id: 2, nome: 'Colaborador 2' }
      ]);
    });


    expect(mockFuncionariosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Colaborador ABC' },
      { id: 2, nome: 'Colaborador XYZ' }
    ];
    mockFuncionariosService.getList.mockResolvedValue(mockOptions as IFuncionarios[]);   


 const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Colaborador ABC' },
        { id: 2, nome: 'Colaborador XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Colaborador ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Colaborador ABC' },
      { id: 2, nome: 'Colaborador XYZ' }
    ];
    mockFuncionariosService.getList.mockResolvedValue(mockOptions as IFuncionarios[]);
  


    const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Colaborador ABC' },
        { id: 2, nome: 'Colaborador XYZ' }
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
          {id: 1, nome: 'Colaborador ABC' },
          {id: 2, nome: 'Colaborador XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService)
    );

    const newValue = { id: 1, nome: 'Colaborador Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Colaborador Inicial' };
    
    const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useFuncionariosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Colaborador Inicial' };
    
    const { result } = renderHook(() => 
      useFuncionariosComboBox(mockFuncionariosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






