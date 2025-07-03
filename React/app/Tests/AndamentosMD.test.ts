// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAndamentosMDForm, useAndamentosMDList, useValidationsAndamentosMD } from '../GerAdv_TS/AndamentosMD/Hooks/hookAndamentosMD';
import { IAndamentosMD } from '../GerAdv_TS/AndamentosMD/Interfaces/interface.AndamentosMD';
import { IAndamentosMDService } from '../GerAdv_TS/AndamentosMD/Services/AndamentosMD.service';
import { AndamentosMDTestEmpty } from '../GerAdv_TS/Models/AndamentosMD';
import { useAndamentosMDComboBox } from '../GerAdv_TS/AndamentosMD/Hooks/hookAndamentosMD';

// Mock do serviço
const mockAndamentosMDService: jest.Mocked<IAndamentosMDService> = {
  fetchAndamentosMDById: jest.fn(),
  saveAndamentosMD: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteAndamentosMD: jest.fn(),
  validateAndamentosMD: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAndamentosMD: IAndamentosMD = { ...AndamentosMDTestEmpty() };

describe('useAndamentosMDForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAndamentosMDForm(initialAndamentosMD, mockAndamentosMDService)
    );

    expect(result.current.data).toEqual(initialAndamentosMD);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAndamentosMDForm(initialAndamentosMD, mockAndamentosMDService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Andamentos M D',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Andamentos M D');
  });

   test('deve carregar Andamentos M D por ID', async () => {
    const mockAndamentosMD = { ...initialAndamentosMD, id: 1, nome: 'Andamentos M D Teste' };
    mockAndamentosMDService.fetchAndamentosMDById.mockResolvedValue(mockAndamentosMD);

    const { result } = renderHook(() => 
      useAndamentosMDForm(initialAndamentosMD, mockAndamentosMDService)
    );

    await act(async () => {
      await result.current.loadAndamentosMD(1);
    });

    expect(mockAndamentosMDService.fetchAndamentosMDById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAndamentosMD);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Andamentos M D', async () => {
    const errorMessage = 'Erro ao carregar Andamentos M D';
    mockAndamentosMDService.fetchAndamentosMDById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAndamentosMDForm(initialAndamentosMD, mockAndamentosMDService)
    );

    await act(async () => {
      await result.current.loadAndamentosMD(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAndamentosMDForm(initialAndamentosMD, mockAndamentosMDService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAndamentosMD, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAndamentosMD);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAndamentosMDForm(initialAndamentosMD, mockAndamentosMDService)
    );

    await act(async () => {
      await result.current.loadAndamentosMD(0);
    });

    expect(mockAndamentosMDService.fetchAndamentosMDById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAndamentosMD);
  });
});

describe('useAndamentosMDList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAndamentosMDList(mockAndamentosMDService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAndamentosMD, id: 1, nome: 'Andamentos M D 1' },
      { ...initialAndamentosMD, id: 2, nome: 'Andamentos M D 2' }
    ];
    mockAndamentosMDService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAndamentosMDList(mockAndamentosMDService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAndamentosMDService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAndamentosMDService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAndamentosMDList(mockAndamentosMDService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAndamentosMD, id: 1, nome: 'Andamentos M D Filtrado' }];
    const filtro = { nome: 'Andamentos M D' };
    mockAndamentosMDService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAndamentosMDList(mockAndamentosMDService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAndamentosMDService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAndamentosMD', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAndamentosMD());

    const validData = { ...initialAndamentosMD, nome: 'Andamentos M D Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsAndamentosMD());

    const invalidData = { ...initialAndamentosMD, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsAndamentosMD());

    const invalidData = { 
      ...initialAndamentosMD, 
      nome: 'a'.repeat(255+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 255 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAndamentosMD());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAndamentosMD, id: 1, nome: 'Andamentos M D Teste' }];
    mockAndamentosMDService.getAll.mockResolvedValue(mockData);
    mockAndamentosMDService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAndamentosMDList(mockAndamentosMDService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsAndamentosMD()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Andamentos M D Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Andamentos M D Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Andamentos M D 1' },
      { id: 2, nome: 'Andamentos M D 2' }
    ];
    mockAndamentosMDService.getList.mockResolvedValue(mockOptions as IAndamentosMD[]);


    const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Andamentos M D 1' },
        { id: 2, nome: 'Andamentos M D 2' }
      ]);
    });


    expect(mockAndamentosMDService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Andamentos M D ABC' },
      { id: 2, nome: 'Andamentos M D XYZ' }
    ];
    mockAndamentosMDService.getList.mockResolvedValue(mockOptions as IAndamentosMD[]);   


 const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Andamentos M D ABC' },
        { id: 2, nome: 'Andamentos M D XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Andamentos M D ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Andamentos M D ABC' },
      { id: 2, nome: 'Andamentos M D XYZ' }
    ];
    mockAndamentosMDService.getList.mockResolvedValue(mockOptions as IAndamentosMD[]);
  


    const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Andamentos M D ABC' },
        { id: 2, nome: 'Andamentos M D XYZ' }
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
          {id: 1, nome: 'Andamentos M D ABC' },
          {id: 2, nome: 'Andamentos M D XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService)
    );

    const newValue = { id: 1, nome: 'Andamentos M D Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Andamentos M D Inicial' };
    
    const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useAndamentosMDComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Andamentos M D Inicial' };
    
    const { result } = renderHook(() => 
      useAndamentosMDComboBox(mockAndamentosMDService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






