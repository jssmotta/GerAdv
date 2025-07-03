// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useCargosEscClassForm, useCargosEscClassList, useValidationsCargosEscClass } from '../GerAdv_TS/CargosEscClass/Hooks/hookCargosEscClass';
import { ICargosEscClass } from '../GerAdv_TS/CargosEscClass/Interfaces/interface.CargosEscClass';
import { ICargosEscClassService } from '../GerAdv_TS/CargosEscClass/Services/CargosEscClass.service';
import { CargosEscClassTestEmpty } from '../GerAdv_TS/Models/CargosEscClass';
import { useCargosEscClassComboBox } from '../GerAdv_TS/CargosEscClass/Hooks/hookCargosEscClass';

// Mock do serviço
const mockCargosEscClassService: jest.Mocked<ICargosEscClassService> = {
  fetchCargosEscClassById: jest.fn(),
  saveCargosEscClass: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteCargosEscClass: jest.fn(),
  validateCargosEscClass: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialCargosEscClass: ICargosEscClass = { ...CargosEscClassTestEmpty() };

describe('useCargosEscClassForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useCargosEscClassForm(initialCargosEscClass, mockCargosEscClassService)
    );

    expect(result.current.data).toEqual(initialCargosEscClass);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useCargosEscClassForm(initialCargosEscClass, mockCargosEscClassService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Cargos Esc Class',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Cargos Esc Class');
  });

   test('deve carregar Cargos Esc Class por ID', async () => {
    const mockCargosEscClass = { ...initialCargosEscClass, id: 1, nome: 'Cargos Esc Class Teste' };
    mockCargosEscClassService.fetchCargosEscClassById.mockResolvedValue(mockCargosEscClass);

    const { result } = renderHook(() => 
      useCargosEscClassForm(initialCargosEscClass, mockCargosEscClassService)
    );

    await act(async () => {
      await result.current.loadCargosEscClass(1);
    });

    expect(mockCargosEscClassService.fetchCargosEscClassById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockCargosEscClass);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Cargos Esc Class', async () => {
    const errorMessage = 'Erro ao carregar Cargos Esc Class';
    mockCargosEscClassService.fetchCargosEscClassById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCargosEscClassForm(initialCargosEscClass, mockCargosEscClassService)
    );

    await act(async () => {
      await result.current.loadCargosEscClass(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useCargosEscClassForm(initialCargosEscClass, mockCargosEscClassService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialCargosEscClass, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialCargosEscClass);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useCargosEscClassForm(initialCargosEscClass, mockCargosEscClassService)
    );

    await act(async () => {
      await result.current.loadCargosEscClass(0);
    });

    expect(mockCargosEscClassService.fetchCargosEscClassById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialCargosEscClass);
  });
});

describe('useCargosEscClassList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCargosEscClassList(mockCargosEscClassService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialCargosEscClass, id: 1, nome: 'Cargos Esc Class 1' },
      { ...initialCargosEscClass, id: 2, nome: 'Cargos Esc Class 2' }
    ];
    mockCargosEscClassService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCargosEscClassList(mockCargosEscClassService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockCargosEscClassService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockCargosEscClassService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCargosEscClassList(mockCargosEscClassService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialCargosEscClass, id: 1, nome: 'Cargos Esc Class Filtrado' }];
    const filtro = { nome: 'Cargos Esc Class' };
    mockCargosEscClassService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCargosEscClassList(mockCargosEscClassService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockCargosEscClassService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsCargosEscClass', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsCargosEscClass());

    const validData = { ...initialCargosEscClass, nome: 'Cargos Esc Class Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsCargosEscClass());

    const invalidData = { ...initialCargosEscClass, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsCargosEscClass());

    const invalidData = { 
      ...initialCargosEscClass, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsCargosEscClass());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialCargosEscClass, id: 1, nome: 'Cargos Esc Class Teste' }];
    mockCargosEscClassService.getAll.mockResolvedValue(mockData);
    mockCargosEscClassService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useCargosEscClassList(mockCargosEscClassService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsCargosEscClass()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cargos Esc Class Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cargos Esc Class Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargos Esc Class 1' },
      { id: 2, nome: 'Cargos Esc Class 2' }
    ];
    mockCargosEscClassService.getList.mockResolvedValue(mockOptions as ICargosEscClass[]);


    const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargos Esc Class 1' },
        { id: 2, nome: 'Cargos Esc Class 2' }
      ]);
    });


    expect(mockCargosEscClassService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargos Esc Class ABC' },
      { id: 2, nome: 'Cargos Esc Class XYZ' }
    ];
    mockCargosEscClassService.getList.mockResolvedValue(mockOptions as ICargosEscClass[]);   


 const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargos Esc Class ABC' },
        { id: 2, nome: 'Cargos Esc Class XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Cargos Esc Class ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargos Esc Class ABC' },
      { id: 2, nome: 'Cargos Esc Class XYZ' }
    ];
    mockCargosEscClassService.getList.mockResolvedValue(mockOptions as ICargosEscClass[]);
  


    const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargos Esc Class ABC' },
        { id: 2, nome: 'Cargos Esc Class XYZ' }
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
          {id: 1, nome: 'Cargos Esc Class ABC' },
          {id: 2, nome: 'Cargos Esc Class XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService)
    );

    const newValue = { id: 1, nome: 'Cargos Esc Class Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Cargos Esc Class Inicial' };
    
    const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useCargosEscClassComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Cargos Esc Class Inicial' };
    
    const { result } = renderHook(() => 
      useCargosEscClassComboBox(mockCargosEscClassService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






