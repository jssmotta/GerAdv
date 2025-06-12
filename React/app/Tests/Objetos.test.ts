// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useObjetosForm, useObjetosList, useValidationsObjetos } from '../GerAdv_TS/Objetos/Hooks/hookObjetos';
import { IObjetos } from '../GerAdv_TS/Objetos/Interfaces/interface.Objetos';
import { IObjetosService } from '../GerAdv_TS/Objetos/Services/Objetos.service';
import { ObjetosTestEmpty } from '../GerAdv_TS/Models/Objetos';
import { useObjetosComboBox } from '../GerAdv_TS/Objetos/Hooks/hookObjetos';

// Mock do serviço
const mockObjetosService: jest.Mocked<IObjetosService> = {
  fetchObjetosById: jest.fn(),
  saveObjetos: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteObjetos: jest.fn(),
  validateObjetos: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialObjetos: IObjetos = { ...ObjetosTestEmpty() };

describe('useObjetosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useObjetosForm(initialObjetos, mockObjetosService)
    );

    expect(result.current.data).toEqual(initialObjetos);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useObjetosForm(initialObjetos, mockObjetosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Objetos',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Objetos');
  });

   test('deve carregar Objetos por ID', async () => {
    const mockObjetos = { ...initialObjetos, id: 1, nome: 'Objetos Teste' };
    mockObjetosService.fetchObjetosById.mockResolvedValue(mockObjetos);

    const { result } = renderHook(() => 
      useObjetosForm(initialObjetos, mockObjetosService)
    );

    await act(async () => {
      await result.current.loadObjetos(1);
    });

    expect(mockObjetosService.fetchObjetosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockObjetos);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Objetos', async () => {
    const errorMessage = 'Erro ao carregar Objetos';
    mockObjetosService.fetchObjetosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useObjetosForm(initialObjetos, mockObjetosService)
    );

    await act(async () => {
      await result.current.loadObjetos(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useObjetosForm(initialObjetos, mockObjetosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialObjetos, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialObjetos);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useObjetosForm(initialObjetos, mockObjetosService)
    );

    await act(async () => {
      await result.current.loadObjetos(0);
    });

    expect(mockObjetosService.fetchObjetosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialObjetos);
  });
});

describe('useObjetosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useObjetosList(mockObjetosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialObjetos, id: 1, nome: 'Objetos 1' },
      { ...initialObjetos, id: 2, nome: 'Objetos 2' }
    ];
    mockObjetosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useObjetosList(mockObjetosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockObjetosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockObjetosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useObjetosList(mockObjetosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialObjetos, id: 1, nome: 'Objetos Filtrado' }];
    const filtro = { nome: 'Objetos' };
    mockObjetosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useObjetosList(mockObjetosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockObjetosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsObjetos', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsObjetos());

    const validData = { ...initialObjetos, nome: 'Objetos Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsObjetos());

    const invalidData = { ...initialObjetos, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsObjetos());

    const invalidData = { 
      ...initialObjetos, 
      nome: 'a'.repeat(255+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 255 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsObjetos());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialObjetos, id: 1, nome: 'Objetos Teste' }];
    mockObjetosService.getAll.mockResolvedValue(mockData);
    mockObjetosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useObjetosList(mockObjetosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useObjetosComboBox(mockObjetosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsObjetos()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Objetos Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Objetos Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Objetos 1' },
      { id: 2, nome: 'Objetos 2' }
    ];
    mockObjetosService.getList.mockResolvedValue(mockOptions as IObjetos[]);


    const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Objetos 1' },
        { id: 2, nome: 'Objetos 2' }
      ]);
    });

    expect(mockObjetosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Objetos ABC' },
      { id: 2, nome: 'Objetos XYZ' }
    ];
    mockObjetosService.getList.mockResolvedValue(mockOptions as IObjetos[]);   


 const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Objetos ABC' },
        { id: 2, nome: 'Objetos XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Objetos ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Objetos ABC' },
      { id: 2, nome: 'Objetos XYZ' }
    ];
    mockObjetosService.getList.mockResolvedValue(mockOptions as IObjetos[]);
  


    const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Objetos ABC' },
        { id: 2, nome: 'Objetos XYZ' }
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
          {id: 1, nome: 'Objetos ABC' },
          {id: 2, nome: 'Objetos XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService)
    );

    const newValue = { id: 1, nome: 'Objetos Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Objetos Inicial' };
    
    const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useObjetosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Objetos Inicial' };
    
    const { result } = renderHook(() => 
      useObjetosComboBox(mockObjetosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






