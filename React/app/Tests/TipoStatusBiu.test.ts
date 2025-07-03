// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoStatusBiuForm, useTipoStatusBiuList, useValidationsTipoStatusBiu } from '../GerAdv_TS/TipoStatusBiu/Hooks/hookTipoStatusBiu';
import { ITipoStatusBiu } from '../GerAdv_TS/TipoStatusBiu/Interfaces/interface.TipoStatusBiu';
import { ITipoStatusBiuService } from '../GerAdv_TS/TipoStatusBiu/Services/TipoStatusBiu.service';
import { TipoStatusBiuTestEmpty } from '../GerAdv_TS/Models/TipoStatusBiu';
import { useTipoStatusBiuComboBox } from '../GerAdv_TS/TipoStatusBiu/Hooks/hookTipoStatusBiu';

// Mock do serviço
const mockTipoStatusBiuService: jest.Mocked<ITipoStatusBiuService> = {
  fetchTipoStatusBiuById: jest.fn(),
  saveTipoStatusBiu: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoStatusBiu: jest.fn(),
  validateTipoStatusBiu: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoStatusBiu: ITipoStatusBiu = { ...TipoStatusBiuTestEmpty() };

describe('useTipoStatusBiuForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuForm(initialTipoStatusBiu, mockTipoStatusBiuService)
    );

    expect(result.current.data).toEqual(initialTipoStatusBiu);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuForm(initialTipoStatusBiu, mockTipoStatusBiuService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Staus  Usuários',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Staus  Usuários');
  });

   test('deve carregar Staus  Usuários por ID', async () => {
    const mockTipoStatusBiu = { ...initialTipoStatusBiu, id: 1, nome: 'Staus  Usuários Teste' };
    mockTipoStatusBiuService.fetchTipoStatusBiuById.mockResolvedValue(mockTipoStatusBiu);

    const { result } = renderHook(() => 
      useTipoStatusBiuForm(initialTipoStatusBiu, mockTipoStatusBiuService)
    );

    await act(async () => {
      await result.current.loadTipoStatusBiu(1);
    });

    expect(mockTipoStatusBiuService.fetchTipoStatusBiuById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoStatusBiu);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Staus  Usuários', async () => {
    const errorMessage = 'Erro ao carregar Staus  Usuários';
    mockTipoStatusBiuService.fetchTipoStatusBiuById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoStatusBiuForm(initialTipoStatusBiu, mockTipoStatusBiuService)
    );

    await act(async () => {
      await result.current.loadTipoStatusBiu(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuForm(initialTipoStatusBiu, mockTipoStatusBiuService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoStatusBiu, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoStatusBiu);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuForm(initialTipoStatusBiu, mockTipoStatusBiuService)
    );

    await act(async () => {
      await result.current.loadTipoStatusBiu(0);
    });

    expect(mockTipoStatusBiuService.fetchTipoStatusBiuById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoStatusBiu);
  });
});

describe('useTipoStatusBiuList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuList(mockTipoStatusBiuService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoStatusBiu, id: 1, nome: 'Staus  Usuários 1' },
      { ...initialTipoStatusBiu, id: 2, nome: 'Staus  Usuários 2' }
    ];
    mockTipoStatusBiuService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoStatusBiuList(mockTipoStatusBiuService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoStatusBiuService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoStatusBiuService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoStatusBiuList(mockTipoStatusBiuService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoStatusBiu, id: 1, nome: 'Staus  Usuários Filtrado' }];
    const filtro = { nome: 'Staus  Usuários' };
    mockTipoStatusBiuService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoStatusBiuList(mockTipoStatusBiuService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoStatusBiuService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoStatusBiu', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoStatusBiu());

    const validData = { ...initialTipoStatusBiu, nome: 'Staus  Usuários Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTipoStatusBiu());

    const invalidData = { ...initialTipoStatusBiu, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoStatusBiu());

    const invalidData = { 
      ...initialTipoStatusBiu, 
      nome: 'a'.repeat(150+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 150 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoStatusBiu());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoStatusBiu, id: 1, nome: 'Staus  Usuários Teste' }];
    mockTipoStatusBiuService.getAll.mockResolvedValue(mockData);
    mockTipoStatusBiuService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoStatusBiuList(mockTipoStatusBiuService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoStatusBiu()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Staus  Usuários Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Staus  Usuários Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Staus  Usuários 1' },
      { id: 2, nome: 'Staus  Usuários 2' }
    ];
    mockTipoStatusBiuService.getList.mockResolvedValue(mockOptions as ITipoStatusBiu[]);


    const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Staus  Usuários 1' },
        { id: 2, nome: 'Staus  Usuários 2' }
      ]);
    });


    expect(mockTipoStatusBiuService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Staus  Usuários ABC' },
      { id: 2, nome: 'Staus  Usuários XYZ' }
    ];
    mockTipoStatusBiuService.getList.mockResolvedValue(mockOptions as ITipoStatusBiu[]);   


 const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Staus  Usuários ABC' },
        { id: 2, nome: 'Staus  Usuários XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Staus  Usuários ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Staus  Usuários ABC' },
      { id: 2, nome: 'Staus  Usuários XYZ' }
    ];
    mockTipoStatusBiuService.getList.mockResolvedValue(mockOptions as ITipoStatusBiu[]);
  


    const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Staus  Usuários ABC' },
        { id: 2, nome: 'Staus  Usuários XYZ' }
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
          {id: 1, nome: 'Staus  Usuários ABC' },
          {id: 2, nome: 'Staus  Usuários XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService)
    );

    const newValue = { id: 1, nome: 'Staus  Usuários Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Staus  Usuários Inicial' };
    
    const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoStatusBiuComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Staus  Usuários Inicial' };
    
    const { result } = renderHook(() => 
      useTipoStatusBiuComboBox(mockTipoStatusBiuService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






