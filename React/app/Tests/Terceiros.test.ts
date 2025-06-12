// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTerceirosForm, useTerceirosList, useValidationsTerceiros } from '../GerAdv_TS/Terceiros/Hooks/hookTerceiros';
import { ITerceiros } from '../GerAdv_TS/Terceiros/Interfaces/interface.Terceiros';
import { ITerceirosService } from '../GerAdv_TS/Terceiros/Services/Terceiros.service';
import { TerceirosTestEmpty } from '../GerAdv_TS/Models/Terceiros';
import { useTerceirosComboBox } from '../GerAdv_TS/Terceiros/Hooks/hookTerceiros';

// Mock do serviço
const mockTerceirosService: jest.Mocked<ITerceirosService> = {
  fetchTerceirosById: jest.fn(),
  saveTerceiros: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTerceiros: jest.fn(),
  validateTerceiros: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTerceiros: ITerceiros = { ...TerceirosTestEmpty() };

describe('useTerceirosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTerceirosForm(initialTerceiros, mockTerceirosService)
    );

    expect(result.current.data).toEqual(initialTerceiros);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTerceirosForm(initialTerceiros, mockTerceirosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Terceiros',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Terceiros');
  });

   test('deve carregar Terceiros por ID', async () => {
    const mockTerceiros = { ...initialTerceiros, id: 1, nome: 'Terceiros Teste' };
    mockTerceirosService.fetchTerceirosById.mockResolvedValue(mockTerceiros);

    const { result } = renderHook(() => 
      useTerceirosForm(initialTerceiros, mockTerceirosService)
    );

    await act(async () => {
      await result.current.loadTerceiros(1);
    });

    expect(mockTerceirosService.fetchTerceirosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTerceiros);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Terceiros', async () => {
    const errorMessage = 'Erro ao carregar Terceiros';
    mockTerceirosService.fetchTerceirosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTerceirosForm(initialTerceiros, mockTerceirosService)
    );

    await act(async () => {
      await result.current.loadTerceiros(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTerceirosForm(initialTerceiros, mockTerceirosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTerceiros, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTerceiros);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTerceirosForm(initialTerceiros, mockTerceirosService)
    );

    await act(async () => {
      await result.current.loadTerceiros(0);
    });

    expect(mockTerceirosService.fetchTerceirosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTerceiros);
  });
});

describe('useTerceirosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTerceirosList(mockTerceirosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTerceiros, id: 1, nome: 'Terceiros 1' },
      { ...initialTerceiros, id: 2, nome: 'Terceiros 2' }
    ];
    mockTerceirosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTerceirosList(mockTerceirosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTerceirosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTerceirosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTerceirosList(mockTerceirosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTerceiros, id: 1, nome: 'Terceiros Filtrado' }];
    const filtro = { nome: 'Terceiros' };
    mockTerceirosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTerceirosList(mockTerceirosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTerceirosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTerceiros', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTerceiros());

    const validData = { ...initialTerceiros, nome: 'Terceiros Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTerceiros());

    const invalidData = { ...initialTerceiros, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTerceiros());

    const invalidData = { 
      ...initialTerceiros, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTerceiros());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTerceiros, id: 1, nome: 'Terceiros Teste' }];
    mockTerceirosService.getAll.mockResolvedValue(mockData);
    mockTerceirosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTerceirosList(mockTerceirosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTerceiros()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Terceiros Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Terceiros Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Terceiros 1' },
      { id: 2, nome: 'Terceiros 2' }
    ];
    mockTerceirosService.getList.mockResolvedValue(mockOptions as ITerceiros[]);


    const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Terceiros 1' },
        { id: 2, nome: 'Terceiros 2' }
      ]);
    });

    expect(mockTerceirosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Terceiros ABC' },
      { id: 2, nome: 'Terceiros XYZ' }
    ];
    mockTerceirosService.getList.mockResolvedValue(mockOptions as ITerceiros[]);   


 const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Terceiros ABC' },
        { id: 2, nome: 'Terceiros XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Terceiros ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Terceiros ABC' },
      { id: 2, nome: 'Terceiros XYZ' }
    ];
    mockTerceirosService.getList.mockResolvedValue(mockOptions as ITerceiros[]);
  


    const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Terceiros ABC' },
        { id: 2, nome: 'Terceiros XYZ' }
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
          {id: 1, nome: 'Terceiros ABC' },
          {id: 2, nome: 'Terceiros XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService)
    );

    const newValue = { id: 1, nome: 'Terceiros Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Terceiros Inicial' };
    
    const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTerceirosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Terceiros Inicial' };
    
    const { result } = renderHook(() => 
      useTerceirosComboBox(mockTerceirosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






