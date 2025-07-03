// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useProcessOutputEngineForm, useProcessOutputEngineList, useValidationsProcessOutputEngine } from '../GerAdv_TS/ProcessOutputEngine/Hooks/hookProcessOutputEngine';
import { IProcessOutputEngine } from '../GerAdv_TS/ProcessOutputEngine/Interfaces/interface.ProcessOutputEngine';
import { IProcessOutputEngineService } from '../GerAdv_TS/ProcessOutputEngine/Services/ProcessOutputEngine.service';
import { ProcessOutputEngineTestEmpty } from '../GerAdv_TS/Models/ProcessOutputEngine';
import { useProcessOutputEngineComboBox } from '../GerAdv_TS/ProcessOutputEngine/Hooks/hookProcessOutputEngine';

// Mock do serviço
const mockProcessOutputEngineService: jest.Mocked<IProcessOutputEngineService> = {
  fetchProcessOutputEngineById: jest.fn(),
  saveProcessOutputEngine: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteProcessOutputEngine: jest.fn(),
  validateProcessOutputEngine: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialProcessOutputEngine: IProcessOutputEngine = { ...ProcessOutputEngineTestEmpty() };

describe('useProcessOutputEngineForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    expect(result.current.data).toEqual(initialProcessOutputEngine);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Process Output Engine',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Process Output Engine');
  });

   test('deve carregar Process Output Engine por ID', async () => {
    const mockProcessOutputEngine = { ...initialProcessOutputEngine, id: 1, nome: 'Process Output Engine Teste' };
    mockProcessOutputEngineService.fetchProcessOutputEngineById.mockResolvedValue(mockProcessOutputEngine);

    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    await act(async () => {
      await result.current.loadProcessOutputEngine(1);
    });

    expect(mockProcessOutputEngineService.fetchProcessOutputEngineById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockProcessOutputEngine);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Process Output Engine', async () => {
    const errorMessage = 'Erro ao carregar Process Output Engine';
    mockProcessOutputEngineService.fetchProcessOutputEngineById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    await act(async () => {
      await result.current.loadProcessOutputEngine(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialProcessOutputEngine, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialProcessOutputEngine);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    await act(async () => {
      await result.current.loadProcessOutputEngine(0);
    });

    expect(mockProcessOutputEngineService.fetchProcessOutputEngineById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialProcessOutputEngine);
  });
});

describe('useProcessOutputEngineList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineList(mockProcessOutputEngineService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialProcessOutputEngine, id: 1, nome: 'Process Output Engine 1' },
      { ...initialProcessOutputEngine, id: 2, nome: 'Process Output Engine 2' }
    ];
    mockProcessOutputEngineService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessOutputEngineList(mockProcessOutputEngineService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockProcessOutputEngineService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockProcessOutputEngineService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessOutputEngineList(mockProcessOutputEngineService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialProcessOutputEngine, id: 1, nome: 'Process Output Engine Filtrado' }];
    const filtro = { nome: 'Process Output Engine' };
    mockProcessOutputEngineService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessOutputEngineList(mockProcessOutputEngineService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockProcessOutputEngineService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsProcessOutputEngine', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsProcessOutputEngine());

    const validData = { ...initialProcessOutputEngine, nome: 'Process Output Engine Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsProcessOutputEngine());

    const invalidData = { ...initialProcessOutputEngine, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsProcessOutputEngine());

    const invalidData = { 
      ...initialProcessOutputEngine, 
      nome: 'a'.repeat(255+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 255 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsProcessOutputEngine());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialProcessOutputEngine, id: 1, nome: 'Process Output Engine Teste' }];
    mockProcessOutputEngineService.getAll.mockResolvedValue(mockData);
    mockProcessOutputEngineService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useProcessOutputEngineList(mockProcessOutputEngineService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsProcessOutputEngine()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Process Output Engine Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Process Output Engine Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineForm(initialProcessOutputEngine, mockProcessOutputEngineService)
    );

    const mockEvent = {
      target: {
        name: 'administrador',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.administrador).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Process Output Engine 1' },
      { id: 2, nome: 'Process Output Engine 2' }
    ];
    mockProcessOutputEngineService.getList.mockResolvedValue(mockOptions as IProcessOutputEngine[]);


    const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Process Output Engine 1' },
        { id: 2, nome: 'Process Output Engine 2' }
      ]);
    });


    expect(mockProcessOutputEngineService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Process Output Engine ABC' },
      { id: 2, nome: 'Process Output Engine XYZ' }
    ];
    mockProcessOutputEngineService.getList.mockResolvedValue(mockOptions as IProcessOutputEngine[]);   


 const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Process Output Engine ABC' },
        { id: 2, nome: 'Process Output Engine XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Process Output Engine ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Process Output Engine ABC' },
      { id: 2, nome: 'Process Output Engine XYZ' }
    ];
    mockProcessOutputEngineService.getList.mockResolvedValue(mockOptions as IProcessOutputEngine[]);
  


    const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Process Output Engine ABC' },
        { id: 2, nome: 'Process Output Engine XYZ' }
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
          {id: 1, nome: 'Process Output Engine ABC' },
          {id: 2, nome: 'Process Output Engine XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService)
    );

    const newValue = { id: 1, nome: 'Process Output Engine Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Process Output Engine Inicial' };
    
    const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useProcessOutputEngineComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Process Output Engine Inicial' };
    
    const { result } = renderHook(() => 
      useProcessOutputEngineComboBox(mockProcessOutputEngineService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






