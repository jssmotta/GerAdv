// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useFornecedoresForm, useFornecedoresList, useValidationsFornecedores } from '../GerAdv_TS/Fornecedores/Hooks/hookFornecedores';
import { IFornecedores } from '../GerAdv_TS/Fornecedores/Interfaces/interface.Fornecedores';
import { IFornecedoresService } from '../GerAdv_TS/Fornecedores/Services/Fornecedores.service';
import { FornecedoresTestEmpty } from '../GerAdv_TS/Models/Fornecedores';
import { useFornecedoresComboBox } from '../GerAdv_TS/Fornecedores/Hooks/hookFornecedores';

// Mock do serviço
const mockFornecedoresService: jest.Mocked<IFornecedoresService> = {
  fetchFornecedoresById: jest.fn(),
  saveFornecedores: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteFornecedores: jest.fn(),
  validateFornecedores: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialFornecedores: IFornecedores = { ...FornecedoresTestEmpty() };

describe('useFornecedoresForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useFornecedoresForm(initialFornecedores, mockFornecedoresService)
    );

    expect(result.current.data).toEqual(initialFornecedores);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useFornecedoresForm(initialFornecedores, mockFornecedoresService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Fornecedor',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Fornecedor');
  });

   test('deve carregar Fornecedor por ID', async () => {
    const mockFornecedores = { ...initialFornecedores, id: 1, nome: 'Fornecedor Teste' };
    mockFornecedoresService.fetchFornecedoresById.mockResolvedValue(mockFornecedores);

    const { result } = renderHook(() => 
      useFornecedoresForm(initialFornecedores, mockFornecedoresService)
    );

    await act(async () => {
      await result.current.loadFornecedores(1);
    });

    expect(mockFornecedoresService.fetchFornecedoresById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockFornecedores);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Fornecedor', async () => {
    const errorMessage = 'Erro ao carregar Fornecedor';
    mockFornecedoresService.fetchFornecedoresById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useFornecedoresForm(initialFornecedores, mockFornecedoresService)
    );

    await act(async () => {
      await result.current.loadFornecedores(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useFornecedoresForm(initialFornecedores, mockFornecedoresService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialFornecedores, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialFornecedores);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useFornecedoresForm(initialFornecedores, mockFornecedoresService)
    );

    await act(async () => {
      await result.current.loadFornecedores(0);
    });

    expect(mockFornecedoresService.fetchFornecedoresById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialFornecedores);
  });
});

describe('useFornecedoresList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useFornecedoresList(mockFornecedoresService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialFornecedores, id: 1, nome: 'Fornecedor 1' },
      { ...initialFornecedores, id: 2, nome: 'Fornecedor 2' }
    ];
    mockFornecedoresService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useFornecedoresList(mockFornecedoresService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockFornecedoresService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockFornecedoresService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useFornecedoresList(mockFornecedoresService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialFornecedores, id: 1, nome: 'Fornecedor Filtrado' }];
    const filtro = { nome: 'Fornecedor' };
    mockFornecedoresService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useFornecedoresList(mockFornecedoresService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockFornecedoresService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsFornecedores', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsFornecedores());

    const validData = { ...initialFornecedores, nome: 'Fornecedor Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsFornecedores());

    const invalidData = { ...initialFornecedores, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsFornecedores());

    const invalidData = { 
      ...initialFornecedores, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsFornecedores());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialFornecedores, id: 1, nome: 'Fornecedor Teste' }];
    mockFornecedoresService.getAll.mockResolvedValue(mockData);
    mockFornecedoresService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useFornecedoresList(mockFornecedoresService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsFornecedores()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Fornecedor Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Fornecedor Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Fornecedor 1' },
      { id: 2, nome: 'Fornecedor 2' }
    ];
    mockFornecedoresService.getList.mockResolvedValue(mockOptions as IFornecedores[]);


    const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Fornecedor 1' },
        { id: 2, nome: 'Fornecedor 2' }
      ]);
    });


    expect(mockFornecedoresService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Fornecedor ABC' },
      { id: 2, nome: 'Fornecedor XYZ' }
    ];
    mockFornecedoresService.getList.mockResolvedValue(mockOptions as IFornecedores[]);   


 const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Fornecedor ABC' },
        { id: 2, nome: 'Fornecedor XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Fornecedor ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Fornecedor ABC' },
      { id: 2, nome: 'Fornecedor XYZ' }
    ];
    mockFornecedoresService.getList.mockResolvedValue(mockOptions as IFornecedores[]);
  


    const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Fornecedor ABC' },
        { id: 2, nome: 'Fornecedor XYZ' }
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
          {id: 1, nome: 'Fornecedor ABC' },
          {id: 2, nome: 'Fornecedor XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService)
    );

    const newValue = { id: 1, nome: 'Fornecedor Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Fornecedor Inicial' };
    
    const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useFornecedoresComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Fornecedor Inicial' };
    
    const { result } = renderHook(() => 
      useFornecedoresComboBox(mockFornecedoresService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






