// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useRitoForm, useRitoList, useValidationsRito } from '../GerAdv_TS/Rito/Hooks/hookRito';
import { IRito } from '../GerAdv_TS/Rito/Interfaces/interface.Rito';
import { IRitoService } from '../GerAdv_TS/Rito/Services/Rito.service';
import { RitoTestEmpty } from '../GerAdv_TS/Models/Rito';
import { useRitoComboBox } from '../GerAdv_TS/Rito/Hooks/hookRito';

// Mock do serviço
const mockRitoService: jest.Mocked<IRitoService> = {
  fetchRitoById: jest.fn(),
  saveRito: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteRito: jest.fn(),
  validateRito: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialRito: IRito = { ...RitoTestEmpty() };

describe('useRitoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
    );

    expect(result.current.data).toEqual(initialRito);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo Rito',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo Rito');
  });

   test('deve carregar Rito por ID', async () => {
    const mockRito = { ...initialRito, id: 1, descricao: 'Rito Teste' };
    mockRitoService.fetchRitoById.mockResolvedValue(mockRito);

    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
    );

    await act(async () => {
      await result.current.loadRito(1);
    });

    expect(mockRitoService.fetchRitoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockRito);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Rito', async () => {
    const errorMessage = 'Erro ao carregar Rito';
    mockRitoService.fetchRitoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
    );

    await act(async () => {
      await result.current.loadRito(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialRito, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialRito);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
    );

    await act(async () => {
      await result.current.loadRito(0);
    });

    expect(mockRitoService.fetchRitoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialRito);
  });
});

describe('useRitoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useRitoList(mockRitoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialRito, id: 1, descricao: 'Rito 1' },
      { ...initialRito, id: 2, descricao: 'Rito 2' }
    ];
    mockRitoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useRitoList(mockRitoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockRitoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockRitoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useRitoList(mockRitoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialRito, id: 1, descricao: 'Rito Filtrado' }];
    const filtro = { descricao: 'Rito' };
    mockRitoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useRitoList(mockRitoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockRitoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsRito', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsRito());

    const validData = { ...initialRito, descricao: 'Rito Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsRito());

    const invalidData = { ...initialRito, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsRito());

    const invalidData = { 
      ...initialRito, 
      descricao: 'a'.repeat(20+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 20 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsRito());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialRito, id: 1, descricao: 'Rito Teste' }];
    mockRitoService.getAll.mockResolvedValue(mockData);
    mockRitoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useRitoList(mockRitoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useRitoComboBox(mockRitoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsRito()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Rito Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Rito Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useRitoForm(initialRito, mockRitoService)
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
      { id: 1, descricao: 'Rito 1' },
      { id: 2, descricao: 'Rito 2' }
    ];
    mockRitoService.getList.mockResolvedValue(mockOptions as IRito[]);


    const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Rito 1' },
        { id: 2, nome: 'Rito 2' }
      ]);
    });


    expect(mockRitoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Rito ABC' },
      { id: 2, descricao: 'Rito XYZ' }
    ];
    mockRitoService.getList.mockResolvedValue(mockOptions as IRito[]);   


 const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Rito ABC' },
        { id: 2, nome: 'Rito XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Rito ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Rito ABC' },
      { id: 2, descricao: 'Rito XYZ' }
    ];
    mockRitoService.getList.mockResolvedValue(mockOptions as IRito[]);
  


    const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Rito ABC' },
        { id: 2, nome: 'Rito XYZ' }
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
          {id: 1, nome: 'Rito ABC' },
          {id: 2, nome: 'Rito XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService)
    );

    const newValue = { id: 1, descricao: 'Rito Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'Rito Inicial' };
    
    const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useRitoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'Rito Inicial' };
    
    const { result } = renderHook(() => 
      useRitoComboBox(mockRitoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






