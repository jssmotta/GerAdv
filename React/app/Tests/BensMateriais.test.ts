// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useBensMateriaisForm, useBensMateriaisList, useValidationsBensMateriais } from '../GerAdv_TS/BensMateriais/Hooks/hookBensMateriais';
import { IBensMateriais } from '../GerAdv_TS/BensMateriais/Interfaces/interface.BensMateriais';
import { IBensMateriaisService } from '../GerAdv_TS/BensMateriais/Services/BensMateriais.service';
import { BensMateriaisTestEmpty } from '../GerAdv_TS/Models/BensMateriais';
import { useBensMateriaisComboBox } from '../GerAdv_TS/BensMateriais/Hooks/hookBensMateriais';

// Mock do serviço
const mockBensMateriaisService: jest.Mocked<IBensMateriaisService> = {
  fetchBensMateriaisById: jest.fn(),
  saveBensMateriais: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteBensMateriais: jest.fn(),
  validateBensMateriais: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialBensMateriais: IBensMateriais = { ...BensMateriaisTestEmpty() };

describe('useBensMateriaisForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    expect(result.current.data).toEqual(initialBensMateriais);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Bens Materiais',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Bens Materiais');
  });

   test('deve carregar Bens Materiais por ID', async () => {
    const mockBensMateriais = { ...initialBensMateriais, id: 1, nome: 'Bens Materiais Teste' };
    mockBensMateriaisService.fetchBensMateriaisById.mockResolvedValue(mockBensMateriais);

    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    await act(async () => {
      await result.current.loadBensMateriais(1);
    });

    expect(mockBensMateriaisService.fetchBensMateriaisById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockBensMateriais);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Bens Materiais', async () => {
    const errorMessage = 'Erro ao carregar Bens Materiais';
    mockBensMateriaisService.fetchBensMateriaisById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    await act(async () => {
      await result.current.loadBensMateriais(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialBensMateriais, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialBensMateriais);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    await act(async () => {
      await result.current.loadBensMateriais(0);
    });

    expect(mockBensMateriaisService.fetchBensMateriaisById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialBensMateriais);
  });
});

describe('useBensMateriaisList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useBensMateriaisList(mockBensMateriaisService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialBensMateriais, id: 1, nome: 'Bens Materiais 1' },
      { ...initialBensMateriais, id: 2, nome: 'Bens Materiais 2' }
    ];
    mockBensMateriaisService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useBensMateriaisList(mockBensMateriaisService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockBensMateriaisService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockBensMateriaisService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useBensMateriaisList(mockBensMateriaisService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialBensMateriais, id: 1, nome: 'Bens Materiais Filtrado' }];
    const filtro = { nome: 'Bens Materiais' };
    mockBensMateriaisService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useBensMateriaisList(mockBensMateriaisService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockBensMateriaisService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsBensMateriais', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsBensMateriais());

    const validData = { ...initialBensMateriais, nome: 'Bens Materiais Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsBensMateriais());

    const invalidData = { ...initialBensMateriais, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsBensMateriais());

    const invalidData = { 
      ...initialBensMateriais, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsBensMateriais());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialBensMateriais, id: 1, nome: 'Bens Materiais Teste' }];
    mockBensMateriaisService.getAll.mockResolvedValue(mockData);
    mockBensMateriaisService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useBensMateriaisList(mockBensMateriaisService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsBensMateriais()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Bens Materiais Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Bens Materiais Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useBensMateriaisForm(initialBensMateriais, mockBensMateriaisService)
    );

    const mockEvent = {
      target: {
        name: 'garantialoja',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.garantialoja).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Bens Materiais 1' },
      { id: 2, nome: 'Bens Materiais 2' }
    ];
    mockBensMateriaisService.getList.mockResolvedValue(mockOptions as IBensMateriais[]);


    const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Bens Materiais 1' },
        { id: 2, nome: 'Bens Materiais 2' }
      ]);
    });

    expect(mockBensMateriaisService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Bens Materiais ABC' },
      { id: 2, nome: 'Bens Materiais XYZ' }
    ];
    mockBensMateriaisService.getList.mockResolvedValue(mockOptions as IBensMateriais[]);   


 const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Bens Materiais ABC' },
        { id: 2, nome: 'Bens Materiais XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Bens Materiais ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Bens Materiais ABC' },
      { id: 2, nome: 'Bens Materiais XYZ' }
    ];
    mockBensMateriaisService.getList.mockResolvedValue(mockOptions as IBensMateriais[]);
  


    const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Bens Materiais ABC' },
        { id: 2, nome: 'Bens Materiais XYZ' }
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
          {id: 1, nome: 'Bens Materiais ABC' },
          {id: 2, nome: 'Bens Materiais XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService)
    );

    const newValue = { id: 1, nome: 'Bens Materiais Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Bens Materiais Inicial' };
    
    const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useBensMateriaisComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Bens Materiais Inicial' };
    
    const { result } = renderHook(() => 
      useBensMateriaisComboBox(mockBensMateriaisService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






