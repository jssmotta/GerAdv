// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTribunalForm, useTribunalList, useValidationsTribunal } from '../GerAdv_TS/Tribunal/Hooks/hookTribunal';
import { ITribunal } from '../GerAdv_TS/Tribunal/Interfaces/interface.Tribunal';
import { ITribunalService } from '../GerAdv_TS/Tribunal/Services/Tribunal.service';
import { TribunalTestEmpty } from '../GerAdv_TS/Models/Tribunal';
import { useTribunalComboBox } from '../GerAdv_TS/Tribunal/Hooks/hookTribunal';

// Mock do serviço
const mockTribunalService: jest.Mocked<ITribunalService> = {
  fetchTribunalById: jest.fn(),
  saveTribunal: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTribunal: jest.fn(),
  validateTribunal: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTribunal: ITribunal = { ...TribunalTestEmpty() };

describe('useTribunalForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTribunalForm(initialTribunal, mockTribunalService)
    );

    expect(result.current.data).toEqual(initialTribunal);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTribunalForm(initialTribunal, mockTribunalService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Tribunal',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Tribunal');
  });

   test('deve carregar Tribunal por ID', async () => {
    const mockTribunal = { ...initialTribunal, id: 1, nome: 'Tribunal Teste' };
    mockTribunalService.fetchTribunalById.mockResolvedValue(mockTribunal);

    const { result } = renderHook(() => 
      useTribunalForm(initialTribunal, mockTribunalService)
    );

    await act(async () => {
      await result.current.loadTribunal(1);
    });

    expect(mockTribunalService.fetchTribunalById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTribunal);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tribunal', async () => {
    const errorMessage = 'Erro ao carregar Tribunal';
    mockTribunalService.fetchTribunalById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTribunalForm(initialTribunal, mockTribunalService)
    );

    await act(async () => {
      await result.current.loadTribunal(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTribunalForm(initialTribunal, mockTribunalService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTribunal, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTribunal);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTribunalForm(initialTribunal, mockTribunalService)
    );

    await act(async () => {
      await result.current.loadTribunal(0);
    });

    expect(mockTribunalService.fetchTribunalById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTribunal);
  });
});

describe('useTribunalList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTribunalList(mockTribunalService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTribunal, id: 1, nome: 'Tribunal 1' },
      { ...initialTribunal, id: 2, nome: 'Tribunal 2' }
    ];
    mockTribunalService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTribunalList(mockTribunalService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTribunalService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTribunalService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTribunalList(mockTribunalService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTribunal, id: 1, nome: 'Tribunal Filtrado' }];
    const filtro = { nome: 'Tribunal' };
    mockTribunalService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTribunalList(mockTribunalService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTribunalService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTribunal', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTribunal());

    const validData = { ...initialTribunal, nome: 'Tribunal Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTribunal());

    const invalidData = { ...initialTribunal, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTribunal());

    const invalidData = { 
      ...initialTribunal, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTribunal());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTribunal, id: 1, nome: 'Tribunal Teste' }];
    mockTribunalService.getAll.mockResolvedValue(mockData);
    mockTribunalService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTribunalList(mockTribunalService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTribunalComboBox(mockTribunalService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTribunal()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tribunal Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tribunal Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tribunal 1' },
      { id: 2, nome: 'Tribunal 2' }
    ];
    mockTribunalService.getList.mockResolvedValue(mockOptions as ITribunal[]);


    const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tribunal 1' },
        { id: 2, nome: 'Tribunal 2' }
      ]);
    });


    expect(mockTribunalService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tribunal ABC' },
      { id: 2, nome: 'Tribunal XYZ' }
    ];
    mockTribunalService.getList.mockResolvedValue(mockOptions as ITribunal[]);   


 const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tribunal ABC' },
        { id: 2, nome: 'Tribunal XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tribunal ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tribunal ABC' },
      { id: 2, nome: 'Tribunal XYZ' }
    ];
    mockTribunalService.getList.mockResolvedValue(mockOptions as ITribunal[]);
  


    const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tribunal ABC' },
        { id: 2, nome: 'Tribunal XYZ' }
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
          {id: 1, nome: 'Tribunal ABC' },
          {id: 2, nome: 'Tribunal XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService)
    );

    const newValue = { id: 1, nome: 'Tribunal Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Tribunal Inicial' };
    
    const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTribunalComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Tribunal Inicial' };
    
    const { result } = renderHook(() => 
      useTribunalComboBox(mockTribunalService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






