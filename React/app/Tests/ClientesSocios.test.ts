// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useClientesSociosForm, useClientesSociosList, useValidationsClientesSocios } from '../GerAdv_TS/ClientesSocios/Hooks/hookClientesSocios';
import { IClientesSocios } from '../GerAdv_TS/ClientesSocios/Interfaces/interface.ClientesSocios';
import { IClientesSociosService } from '../GerAdv_TS/ClientesSocios/Services/ClientesSocios.service';
import { ClientesSociosTestEmpty } from '../GerAdv_TS/Models/ClientesSocios';
import { useClientesSociosComboBox } from '../GerAdv_TS/ClientesSocios/Hooks/hookClientesSocios';

// Mock do serviço
const mockClientesSociosService: jest.Mocked<IClientesSociosService> = {
  fetchClientesSociosById: jest.fn(),
  saveClientesSocios: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteClientesSocios: jest.fn(),
  validateClientesSocios: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialClientesSocios: IClientesSocios = { ...ClientesSociosTestEmpty() };

describe('useClientesSociosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    expect(result.current.data).toEqual(initialClientesSocios);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Clientes Socios',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Clientes Socios');
  });

   test('deve carregar Clientes Socios por ID', async () => {
    const mockClientesSocios = { ...initialClientesSocios, id: 1, nome: 'Clientes Socios Teste' };
    mockClientesSociosService.fetchClientesSociosById.mockResolvedValue(mockClientesSocios);

    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    await act(async () => {
      await result.current.loadClientesSocios(1);
    });

    expect(mockClientesSociosService.fetchClientesSociosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockClientesSocios);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Clientes Socios', async () => {
    const errorMessage = 'Erro ao carregar Clientes Socios';
    mockClientesSociosService.fetchClientesSociosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    await act(async () => {
      await result.current.loadClientesSocios(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialClientesSocios, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialClientesSocios);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    await act(async () => {
      await result.current.loadClientesSocios(0);
    });

    expect(mockClientesSociosService.fetchClientesSociosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialClientesSocios);
  });
});

describe('useClientesSociosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useClientesSociosList(mockClientesSociosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialClientesSocios, id: 1, nome: 'Clientes Socios 1' },
      { ...initialClientesSocios, id: 2, nome: 'Clientes Socios 2' }
    ];
    mockClientesSociosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useClientesSociosList(mockClientesSociosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockClientesSociosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockClientesSociosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useClientesSociosList(mockClientesSociosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialClientesSocios, id: 1, nome: 'Clientes Socios Filtrado' }];
    const filtro = { nome: 'Clientes Socios' };
    mockClientesSociosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useClientesSociosList(mockClientesSociosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockClientesSociosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsClientesSocios', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsClientesSocios());

    const validData = { ...initialClientesSocios, nome: 'Clientes Socios Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsClientesSocios());

    const invalidData = { ...initialClientesSocios, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsClientesSocios());

    const invalidData = { 
      ...initialClientesSocios, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsClientesSocios());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialClientesSocios, id: 1, nome: 'Clientes Socios Teste' }];
    mockClientesSociosService.getAll.mockResolvedValue(mockData);
    mockClientesSociosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useClientesSociosList(mockClientesSociosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsClientesSocios()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Clientes Socios Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Clientes Socios Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useClientesSociosForm(initialClientesSocios, mockClientesSociosService)
    );

    const mockEvent = {
      target: {
        name: 'somenterepresentante',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.somenterepresentante).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Clientes Socios 1' },
      { id: 2, nome: 'Clientes Socios 2' }
    ];
    mockClientesSociosService.getList.mockResolvedValue(mockOptions as IClientesSocios[]);


    const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Clientes Socios 1' },
        { id: 2, nome: 'Clientes Socios 2' }
      ]);
    });

    expect(mockClientesSociosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Clientes Socios ABC' },
      { id: 2, nome: 'Clientes Socios XYZ' }
    ];
    mockClientesSociosService.getList.mockResolvedValue(mockOptions as IClientesSocios[]);   


 const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Clientes Socios ABC' },
        { id: 2, nome: 'Clientes Socios XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Clientes Socios ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Clientes Socios ABC' },
      { id: 2, nome: 'Clientes Socios XYZ' }
    ];
    mockClientesSociosService.getList.mockResolvedValue(mockOptions as IClientesSocios[]);
  


    const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Clientes Socios ABC' },
        { id: 2, nome: 'Clientes Socios XYZ' }
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
          {id: 1, nome: 'Clientes Socios ABC' },
          {id: 2, nome: 'Clientes Socios XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService)
    );

    const newValue = { id: 1, nome: 'Clientes Socios Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Clientes Socios Inicial' };
    
    const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useClientesSociosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Clientes Socios Inicial' };
    
    const { result } = renderHook(() => 
      useClientesSociosComboBox(mockClientesSociosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






