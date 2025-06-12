// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoProDespositoForm, useTipoProDespositoList, useValidationsTipoProDesposito } from '../GerAdv_TS/TipoProDesposito/Hooks/hookTipoProDesposito';
import { ITipoProDesposito } from '../GerAdv_TS/TipoProDesposito/Interfaces/interface.TipoProDesposito';
import { ITipoProDespositoService } from '../GerAdv_TS/TipoProDesposito/Services/TipoProDesposito.service';
import { TipoProDespositoTestEmpty } from '../GerAdv_TS/Models/TipoProDesposito';
import { useTipoProDespositoComboBox } from '../GerAdv_TS/TipoProDesposito/Hooks/hookTipoProDesposito';

// Mock do serviço
const mockTipoProDespositoService: jest.Mocked<ITipoProDespositoService> = {
  fetchTipoProDespositoById: jest.fn(),
  saveTipoProDesposito: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoProDesposito: jest.fn(),
  validateTipoProDesposito: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoProDesposito: ITipoProDesposito = { ...TipoProDespositoTestEmpty() };

describe('useTipoProDespositoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoProDespositoForm(initialTipoProDesposito, mockTipoProDespositoService)
    );

    expect(result.current.data).toEqual(initialTipoProDesposito);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoProDespositoForm(initialTipoProDesposito, mockTipoProDespositoService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Tipo Pro Desposito',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Tipo Pro Desposito');
  });

   test('deve carregar Tipo Pro Desposito por ID', async () => {
    const mockTipoProDesposito = { ...initialTipoProDesposito, id: 1, nome: 'Tipo Pro Desposito Teste' };
    mockTipoProDespositoService.fetchTipoProDespositoById.mockResolvedValue(mockTipoProDesposito);

    const { result } = renderHook(() => 
      useTipoProDespositoForm(initialTipoProDesposito, mockTipoProDespositoService)
    );

    await act(async () => {
      await result.current.loadTipoProDesposito(1);
    });

    expect(mockTipoProDespositoService.fetchTipoProDespositoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoProDesposito);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo Pro Desposito', async () => {
    const errorMessage = 'Erro ao carregar Tipo Pro Desposito';
    mockTipoProDespositoService.fetchTipoProDespositoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoProDespositoForm(initialTipoProDesposito, mockTipoProDespositoService)
    );

    await act(async () => {
      await result.current.loadTipoProDesposito(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoProDespositoForm(initialTipoProDesposito, mockTipoProDespositoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoProDesposito, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoProDesposito);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoProDespositoForm(initialTipoProDesposito, mockTipoProDespositoService)
    );

    await act(async () => {
      await result.current.loadTipoProDesposito(0);
    });

    expect(mockTipoProDespositoService.fetchTipoProDespositoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoProDesposito);
  });
});

describe('useTipoProDespositoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoProDespositoList(mockTipoProDespositoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoProDesposito, id: 1, nome: 'Tipo Pro Desposito 1' },
      { ...initialTipoProDesposito, id: 2, nome: 'Tipo Pro Desposito 2' }
    ];
    mockTipoProDespositoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoProDespositoList(mockTipoProDespositoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoProDespositoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoProDespositoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoProDespositoList(mockTipoProDespositoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoProDesposito, id: 1, nome: 'Tipo Pro Desposito Filtrado' }];
    const filtro = { nome: 'Tipo Pro Desposito' };
    mockTipoProDespositoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoProDespositoList(mockTipoProDespositoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoProDespositoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoProDesposito', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoProDesposito());

    const validData = { ...initialTipoProDesposito, nome: 'Tipo Pro Desposito Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTipoProDesposito());

    const invalidData = { ...initialTipoProDesposito, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoProDesposito());

    const invalidData = { 
      ...initialTipoProDesposito, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoProDesposito());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoProDesposito, id: 1, nome: 'Tipo Pro Desposito Teste' }];
    mockTipoProDespositoService.getAll.mockResolvedValue(mockData);
    mockTipoProDespositoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoProDespositoList(mockTipoProDespositoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoProDesposito()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Pro Desposito Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Pro Desposito Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Pro Desposito 1' },
      { id: 2, nome: 'Tipo Pro Desposito 2' }
    ];
    mockTipoProDespositoService.getList.mockResolvedValue(mockOptions as ITipoProDesposito[]);


    const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Pro Desposito 1' },
        { id: 2, nome: 'Tipo Pro Desposito 2' }
      ]);
    });

    expect(mockTipoProDespositoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Pro Desposito ABC' },
      { id: 2, nome: 'Tipo Pro Desposito XYZ' }
    ];
    mockTipoProDespositoService.getList.mockResolvedValue(mockOptions as ITipoProDesposito[]);   


 const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Pro Desposito ABC' },
        { id: 2, nome: 'Tipo Pro Desposito XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo Pro Desposito ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Pro Desposito ABC' },
      { id: 2, nome: 'Tipo Pro Desposito XYZ' }
    ];
    mockTipoProDespositoService.getList.mockResolvedValue(mockOptions as ITipoProDesposito[]);
  


    const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Pro Desposito ABC' },
        { id: 2, nome: 'Tipo Pro Desposito XYZ' }
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
          {id: 1, nome: 'Tipo Pro Desposito ABC' },
          {id: 2, nome: 'Tipo Pro Desposito XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService)
    );

    const newValue = { id: 1, nome: 'Tipo Pro Desposito Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Tipo Pro Desposito Inicial' };
    
    const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoProDespositoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Tipo Pro Desposito Inicial' };
    
    const { result } = renderHook(() => 
      useTipoProDespositoComboBox(mockTipoProDespositoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






