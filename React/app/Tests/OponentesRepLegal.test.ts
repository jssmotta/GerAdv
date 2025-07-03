// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useOponentesRepLegalForm, useOponentesRepLegalList, useValidationsOponentesRepLegal } from '../GerAdv_TS/OponentesRepLegal/Hooks/hookOponentesRepLegal';
import { IOponentesRepLegal } from '../GerAdv_TS/OponentesRepLegal/Interfaces/interface.OponentesRepLegal';
import { IOponentesRepLegalService } from '../GerAdv_TS/OponentesRepLegal/Services/OponentesRepLegal.service';
import { OponentesRepLegalTestEmpty } from '../GerAdv_TS/Models/OponentesRepLegal';
import { useOponentesRepLegalComboBox } from '../GerAdv_TS/OponentesRepLegal/Hooks/hookOponentesRepLegal';

// Mock do serviço
const mockOponentesRepLegalService: jest.Mocked<IOponentesRepLegalService> = {
  fetchOponentesRepLegalById: jest.fn(),
  saveOponentesRepLegal: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteOponentesRepLegal: jest.fn(),
  validateOponentesRepLegal: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialOponentesRepLegal: IOponentesRepLegal = { ...OponentesRepLegalTestEmpty() };

describe('useOponentesRepLegalForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalForm(initialOponentesRepLegal, mockOponentesRepLegalService)
    );

    expect(result.current.data).toEqual(initialOponentesRepLegal);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalForm(initialOponentesRepLegal, mockOponentesRepLegalService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Oponentes Rep Legal',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Oponentes Rep Legal');
  });

   test('deve carregar Oponentes Rep Legal por ID', async () => {
    const mockOponentesRepLegal = { ...initialOponentesRepLegal, id: 1, nome: 'Oponentes Rep Legal Teste' };
    mockOponentesRepLegalService.fetchOponentesRepLegalById.mockResolvedValue(mockOponentesRepLegal);

    const { result } = renderHook(() => 
      useOponentesRepLegalForm(initialOponentesRepLegal, mockOponentesRepLegalService)
    );

    await act(async () => {
      await result.current.loadOponentesRepLegal(1);
    });

    expect(mockOponentesRepLegalService.fetchOponentesRepLegalById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockOponentesRepLegal);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Oponentes Rep Legal', async () => {
    const errorMessage = 'Erro ao carregar Oponentes Rep Legal';
    mockOponentesRepLegalService.fetchOponentesRepLegalById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOponentesRepLegalForm(initialOponentesRepLegal, mockOponentesRepLegalService)
    );

    await act(async () => {
      await result.current.loadOponentesRepLegal(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalForm(initialOponentesRepLegal, mockOponentesRepLegalService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialOponentesRepLegal, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialOponentesRepLegal);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalForm(initialOponentesRepLegal, mockOponentesRepLegalService)
    );

    await act(async () => {
      await result.current.loadOponentesRepLegal(0);
    });

    expect(mockOponentesRepLegalService.fetchOponentesRepLegalById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialOponentesRepLegal);
  });
});

describe('useOponentesRepLegalList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalList(mockOponentesRepLegalService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialOponentesRepLegal, id: 1, nome: 'Oponentes Rep Legal 1' },
      { ...initialOponentesRepLegal, id: 2, nome: 'Oponentes Rep Legal 2' }
    ];
    mockOponentesRepLegalService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOponentesRepLegalList(mockOponentesRepLegalService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockOponentesRepLegalService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockOponentesRepLegalService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOponentesRepLegalList(mockOponentesRepLegalService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialOponentesRepLegal, id: 1, nome: 'Oponentes Rep Legal Filtrado' }];
    const filtro = { nome: 'Oponentes Rep Legal' };
    mockOponentesRepLegalService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOponentesRepLegalList(mockOponentesRepLegalService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockOponentesRepLegalService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsOponentesRepLegal', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsOponentesRepLegal());

    const validData = { ...initialOponentesRepLegal, nome: 'Oponentes Rep Legal Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsOponentesRepLegal());

    const invalidData = { ...initialOponentesRepLegal, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsOponentesRepLegal());

    const invalidData = { 
      ...initialOponentesRepLegal, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsOponentesRepLegal());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialOponentesRepLegal, id: 1, nome: 'Oponentes Rep Legal Teste' }];
    mockOponentesRepLegalService.getAll.mockResolvedValue(mockData);
    mockOponentesRepLegalService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useOponentesRepLegalList(mockOponentesRepLegalService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsOponentesRepLegal()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Oponentes Rep Legal Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Oponentes Rep Legal Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Oponentes Rep Legal 1' },
      { id: 2, nome: 'Oponentes Rep Legal 2' }
    ];
    mockOponentesRepLegalService.getList.mockResolvedValue(mockOptions as IOponentesRepLegal[]);


    const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Oponentes Rep Legal 1' },
        { id: 2, nome: 'Oponentes Rep Legal 2' }
      ]);
    });


    expect(mockOponentesRepLegalService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Oponentes Rep Legal ABC' },
      { id: 2, nome: 'Oponentes Rep Legal XYZ' }
    ];
    mockOponentesRepLegalService.getList.mockResolvedValue(mockOptions as IOponentesRepLegal[]);   


 const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Oponentes Rep Legal ABC' },
        { id: 2, nome: 'Oponentes Rep Legal XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Oponentes Rep Legal ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Oponentes Rep Legal ABC' },
      { id: 2, nome: 'Oponentes Rep Legal XYZ' }
    ];
    mockOponentesRepLegalService.getList.mockResolvedValue(mockOptions as IOponentesRepLegal[]);
  


    const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Oponentes Rep Legal ABC' },
        { id: 2, nome: 'Oponentes Rep Legal XYZ' }
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
          {id: 1, nome: 'Oponentes Rep Legal ABC' },
          {id: 2, nome: 'Oponentes Rep Legal XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService)
    );

    const newValue = { id: 1, nome: 'Oponentes Rep Legal Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Oponentes Rep Legal Inicial' };
    
    const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useOponentesRepLegalComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Oponentes Rep Legal Inicial' };
    
    const { result } = renderHook(() => 
      useOponentesRepLegalComboBox(mockOponentesRepLegalService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






