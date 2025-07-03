// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useCidadeForm, useCidadeList, useValidationsCidade } from '../GerAdv_TS/Cidade/Hooks/hookCidade';
import { ICidade } from '../GerAdv_TS/Cidade/Interfaces/interface.Cidade';
import { ICidadeService } from '../GerAdv_TS/Cidade/Services/Cidade.service';
import { CidadeTestEmpty } from '../GerAdv_TS/Models/Cidade';
import { useCidadeComboBox } from '../GerAdv_TS/Cidade/Hooks/hookCidade';

// Mock do serviço
const mockCidadeService: jest.Mocked<ICidadeService> = {
  fetchCidadeById: jest.fn(),
  saveCidade: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteCidade: jest.fn(),
  validateCidade: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialCidade: ICidade = { ...CidadeTestEmpty() };

describe('useCidadeForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    expect(result.current.data).toEqual(initialCidade);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Cidade',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Cidade');
  });

   test('deve carregar Cidade por ID', async () => {
    const mockCidade = { ...initialCidade, id: 1, nome: 'Cidade Teste' };
    mockCidadeService.fetchCidadeById.mockResolvedValue(mockCidade);

    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    await act(async () => {
      await result.current.loadCidade(1);
    });

    expect(mockCidadeService.fetchCidadeById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockCidade);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Cidade', async () => {
    const errorMessage = 'Erro ao carregar Cidade';
    mockCidadeService.fetchCidadeById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    await act(async () => {
      await result.current.loadCidade(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialCidade, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialCidade);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    await act(async () => {
      await result.current.loadCidade(0);
    });

    expect(mockCidadeService.fetchCidadeById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialCidade);
  });
});

describe('useCidadeList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCidadeList(mockCidadeService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialCidade, id: 1, nome: 'Cidade 1' },
      { ...initialCidade, id: 2, nome: 'Cidade 2' }
    ];
    mockCidadeService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCidadeList(mockCidadeService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockCidadeService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockCidadeService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCidadeList(mockCidadeService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialCidade, id: 1, nome: 'Cidade Filtrado' }];
    const filtro = { nome: 'Cidade' };
    mockCidadeService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCidadeList(mockCidadeService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockCidadeService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsCidade', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsCidade());

    const validData = { ...initialCidade, nome: 'Cidade Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsCidade());

    const invalidData = { ...initialCidade, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsCidade());

    const invalidData = { 
      ...initialCidade, 
      nome: 'a'.repeat(40+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 40 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsCidade());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialCidade, id: 1, nome: 'Cidade Teste' }];
    mockCidadeService.getAll.mockResolvedValue(mockData);
    mockCidadeService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useCidadeList(mockCidadeService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useCidadeComboBox(mockCidadeService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsCidade()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cidade Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cidade Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useCidadeForm(initialCidade, mockCidadeService)
    );

    const mockEvent = {
      target: {
        name: 'top',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.top).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cidade 1' },
      { id: 2, nome: 'Cidade 2' }
    ];
    mockCidadeService.getList.mockResolvedValue(mockOptions as ICidade[]);


    const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cidade 1' },
        { id: 2, nome: 'Cidade 2' }
      ]);
    });


    expect(mockCidadeService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cidade ABC' },
      { id: 2, nome: 'Cidade XYZ' }
    ];
    mockCidadeService.getList.mockResolvedValue(mockOptions as ICidade[]);   


 const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cidade ABC' },
        { id: 2, nome: 'Cidade XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Cidade ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cidade ABC' },
      { id: 2, nome: 'Cidade XYZ' }
    ];
    mockCidadeService.getList.mockResolvedValue(mockOptions as ICidade[]);
  


    const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cidade ABC' },
        { id: 2, nome: 'Cidade XYZ' }
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
          {id: 1, nome: 'Cidade ABC' },
          {id: 2, nome: 'Cidade XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService)
    );

    const newValue = { id: 1, nome: 'Cidade Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Cidade Inicial' };
    
    const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useCidadeComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Cidade Inicial' };
    
    const { result } = renderHook(() => 
      useCidadeComboBox(mockCidadeService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






