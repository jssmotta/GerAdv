// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { usePreClientesForm, usePreClientesList, useValidationsPreClientes } from '../GerAdv_TS/PreClientes/Hooks/hookPreClientes';
import { IPreClientes } from '../GerAdv_TS/PreClientes/Interfaces/interface.PreClientes';
import { IPreClientesService } from '../GerAdv_TS/PreClientes/Services/PreClientes.service';
import { PreClientesTestEmpty } from '../GerAdv_TS/Models/PreClientes';
import { usePreClientesComboBox } from '../GerAdv_TS/PreClientes/Hooks/hookPreClientes';

// Mock do serviço
const mockPreClientesService: jest.Mocked<IPreClientesService> = {
  fetchPreClientesById: jest.fn(),
  savePreClientes: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deletePreClientes: jest.fn(),
  validatePreClientes: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialPreClientes: IPreClientes = { ...PreClientesTestEmpty() };

describe('usePreClientesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    expect(result.current.data).toEqual(initialPreClientes);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Pre Clientes',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Pre Clientes');
  });

   test('deve carregar Pre Clientes por ID', async () => {
    const mockPreClientes = { ...initialPreClientes, id: 1, nome: 'Pre Clientes Teste' };
    mockPreClientesService.fetchPreClientesById.mockResolvedValue(mockPreClientes);

    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    await act(async () => {
      await result.current.loadPreClientes(1);
    });

    expect(mockPreClientesService.fetchPreClientesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockPreClientes);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Pre Clientes', async () => {
    const errorMessage = 'Erro ao carregar Pre Clientes';
    mockPreClientesService.fetchPreClientesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    await act(async () => {
      await result.current.loadPreClientes(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialPreClientes, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialPreClientes);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    await act(async () => {
      await result.current.loadPreClientes(0);
    });

    expect(mockPreClientesService.fetchPreClientesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialPreClientes);
  });
});

describe('usePreClientesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      usePreClientesList(mockPreClientesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialPreClientes, id: 1, nome: 'Pre Clientes 1' },
      { ...initialPreClientes, id: 2, nome: 'Pre Clientes 2' }
    ];
    mockPreClientesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      usePreClientesList(mockPreClientesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockPreClientesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockPreClientesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      usePreClientesList(mockPreClientesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialPreClientes, id: 1, nome: 'Pre Clientes Filtrado' }];
    const filtro = { nome: 'Pre Clientes' };
    mockPreClientesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      usePreClientesList(mockPreClientesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockPreClientesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsPreClientes', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsPreClientes());

    const validData = { ...initialPreClientes, nome: 'Pre Clientes Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsPreClientes());

    const invalidData = { ...initialPreClientes, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsPreClientes());

    const invalidData = { 
      ...initialPreClientes, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsPreClientes());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialPreClientes, id: 1, nome: 'Pre Clientes Teste' }];
    mockPreClientesService.getAll.mockResolvedValue(mockData);
    mockPreClientesService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      usePreClientesList(mockPreClientesService)
    );
    
     const { result: comboResult } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsPreClientes()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Pre Clientes Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Pre Clientes Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      usePreClientesForm(initialPreClientes, mockPreClientesService)
    );

    const mockEvent = {
      target: {
        name: 'inativo',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.inativo).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Pre Clientes 1' },
      { id: 2, nome: 'Pre Clientes 2' }
    ];
    mockPreClientesService.getList.mockResolvedValue(mockOptions as IPreClientes[]);


    const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Pre Clientes 1' },
        { id: 2, nome: 'Pre Clientes 2' }
      ]);
    });

    expect(mockPreClientesService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Pre Clientes ABC' },
      { id: 2, nome: 'Pre Clientes XYZ' }
    ];
    mockPreClientesService.getList.mockResolvedValue(mockOptions as IPreClientes[]);   


 const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Pre Clientes ABC' },
        { id: 2, nome: 'Pre Clientes XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Pre Clientes ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Pre Clientes ABC' },
      { id: 2, nome: 'Pre Clientes XYZ' }
    ];
    mockPreClientesService.getList.mockResolvedValue(mockOptions as IPreClientes[]);
  


    const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Pre Clientes ABC' },
        { id: 2, nome: 'Pre Clientes XYZ' }
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
          {id: 1, nome: 'Pre Clientes ABC' },
          {id: 2, nome: 'Pre Clientes XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService)
    );

    const newValue = { id: 1, nome: 'Pre Clientes Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Pre Clientes Inicial' };
    
    const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('usePreClientesComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Pre Clientes Inicial' };
    
    const { result } = renderHook(() => 
      usePreClientesComboBox(mockPreClientesService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






