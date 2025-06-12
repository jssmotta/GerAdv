// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useCargosEscForm, useCargosEscList, useValidationsCargosEsc } from '../GerAdv_TS/CargosEsc/Hooks/hookCargosEsc';
import { ICargosEsc } from '../GerAdv_TS/CargosEsc/Interfaces/interface.CargosEsc';
import { ICargosEscService } from '../GerAdv_TS/CargosEsc/Services/CargosEsc.service';
import { CargosEscTestEmpty } from '../GerAdv_TS/Models/CargosEsc';
import { useCargosEscComboBox } from '../GerAdv_TS/CargosEsc/Hooks/hookCargosEsc';

// Mock do serviço
const mockCargosEscService: jest.Mocked<ICargosEscService> = {
  fetchCargosEscById: jest.fn(),
  saveCargosEsc: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteCargosEsc: jest.fn(),
  validateCargosEsc: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialCargosEsc: ICargosEsc = { ...CargosEscTestEmpty() };

describe('useCargosEscForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useCargosEscForm(initialCargosEsc, mockCargosEscService)
    );

    expect(result.current.data).toEqual(initialCargosEsc);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useCargosEscForm(initialCargosEsc, mockCargosEscService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Cargos Esc',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Cargos Esc');
  });

   test('deve carregar Cargos Esc por ID', async () => {
    const mockCargosEsc = { ...initialCargosEsc, id: 1, nome: 'Cargos Esc Teste' };
    mockCargosEscService.fetchCargosEscById.mockResolvedValue(mockCargosEsc);

    const { result } = renderHook(() => 
      useCargosEscForm(initialCargosEsc, mockCargosEscService)
    );

    await act(async () => {
      await result.current.loadCargosEsc(1);
    });

    expect(mockCargosEscService.fetchCargosEscById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockCargosEsc);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Cargos Esc', async () => {
    const errorMessage = 'Erro ao carregar Cargos Esc';
    mockCargosEscService.fetchCargosEscById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCargosEscForm(initialCargosEsc, mockCargosEscService)
    );

    await act(async () => {
      await result.current.loadCargosEsc(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useCargosEscForm(initialCargosEsc, mockCargosEscService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialCargosEsc, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialCargosEsc);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useCargosEscForm(initialCargosEsc, mockCargosEscService)
    );

    await act(async () => {
      await result.current.loadCargosEsc(0);
    });

    expect(mockCargosEscService.fetchCargosEscById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialCargosEsc);
  });
});

describe('useCargosEscList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCargosEscList(mockCargosEscService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialCargosEsc, id: 1, nome: 'Cargos Esc 1' },
      { ...initialCargosEsc, id: 2, nome: 'Cargos Esc 2' }
    ];
    mockCargosEscService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCargosEscList(mockCargosEscService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockCargosEscService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockCargosEscService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCargosEscList(mockCargosEscService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialCargosEsc, id: 1, nome: 'Cargos Esc Filtrado' }];
    const filtro = { nome: 'Cargos Esc' };
    mockCargosEscService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCargosEscList(mockCargosEscService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockCargosEscService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsCargosEsc', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsCargosEsc());

    const validData = { ...initialCargosEsc, nome: 'Cargos Esc Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsCargosEsc());

    const invalidData = { ...initialCargosEsc, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsCargosEsc());

    const invalidData = { 
      ...initialCargosEsc, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsCargosEsc());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialCargosEsc, id: 1, nome: 'Cargos Esc Teste' }];
    mockCargosEscService.getAll.mockResolvedValue(mockData);
    mockCargosEscService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useCargosEscList(mockCargosEscService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsCargosEsc()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cargos Esc Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cargos Esc Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargos Esc 1' },
      { id: 2, nome: 'Cargos Esc 2' }
    ];
    mockCargosEscService.getList.mockResolvedValue(mockOptions as ICargosEsc[]);


    const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargos Esc 1' },
        { id: 2, nome: 'Cargos Esc 2' }
      ]);
    });

    expect(mockCargosEscService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargos Esc ABC' },
      { id: 2, nome: 'Cargos Esc XYZ' }
    ];
    mockCargosEscService.getList.mockResolvedValue(mockOptions as ICargosEsc[]);   


 const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargos Esc ABC' },
        { id: 2, nome: 'Cargos Esc XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Cargos Esc ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargos Esc ABC' },
      { id: 2, nome: 'Cargos Esc XYZ' }
    ];
    mockCargosEscService.getList.mockResolvedValue(mockOptions as ICargosEsc[]);
  


    const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargos Esc ABC' },
        { id: 2, nome: 'Cargos Esc XYZ' }
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
          {id: 1, nome: 'Cargos Esc ABC' },
          {id: 2, nome: 'Cargos Esc XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService)
    );

    const newValue = { id: 1, nome: 'Cargos Esc Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Cargos Esc Inicial' };
    
    const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useCargosEscComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Cargos Esc Inicial' };
    
    const { result } = renderHook(() => 
      useCargosEscComboBox(mockCargosEscService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






