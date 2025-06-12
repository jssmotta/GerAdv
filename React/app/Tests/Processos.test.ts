// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useProcessosForm, useProcessosList, useValidationsProcessos } from '../GerAdv_TS/Processos/Hooks/hookProcessos';
import { IProcessos } from '../GerAdv_TS/Processos/Interfaces/interface.Processos';
import { IProcessosService } from '../GerAdv_TS/Processos/Services/Processos.service';
import { ProcessosTestEmpty } from '../GerAdv_TS/Models/Processos';
import { useProcessosComboBox } from '../GerAdv_TS/Processos/Hooks/hookProcessos';

// Mock do serviço
const mockProcessosService: jest.Mocked<IProcessosService> = {
  fetchProcessosById: jest.fn(),
  saveProcessos: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteProcessos: jest.fn(),
  validateProcessos: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialProcessos: IProcessos = { ...ProcessosTestEmpty() };

describe('useProcessosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    expect(result.current.data).toEqual(initialProcessos);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    const mockEvent = {
      target: {
        name: 'nropasta',
        value: 'Novo Processos',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nropasta).toBe('Novo Processos');
  });

   test('deve carregar Processos por ID', async () => {
    const mockProcessos = { ...initialProcessos, id: 1, nropasta: 'Processos Teste' };
    mockProcessosService.fetchProcessosById.mockResolvedValue(mockProcessos);

    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    await act(async () => {
      await result.current.loadProcessos(1);
    });

    expect(mockProcessosService.fetchProcessosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockProcessos);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Processos', async () => {
    const errorMessage = 'Erro ao carregar Processos';
    mockProcessosService.fetchProcessosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    await act(async () => {
      await result.current.loadProcessos(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialProcessos, nropasta: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialProcessos);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    await act(async () => {
      await result.current.loadProcessos(0);
    });

    expect(mockProcessosService.fetchProcessosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialProcessos);
  });
});

describe('useProcessosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessosList(mockProcessosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialProcessos, id: 1, nropasta: 'Processos 1' },
      { ...initialProcessos, id: 2, nropasta: 'Processos 2' }
    ];
    mockProcessosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessosList(mockProcessosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockProcessosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockProcessosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessosList(mockProcessosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialProcessos, id: 1, nropasta: 'Processos Filtrado' }];
    const filtro = { nropasta: 'Processos' };
    mockProcessosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessosList(mockProcessosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockProcessosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsProcessos', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsProcessos());

    const validData = { ...initialProcessos, nropasta: 'Processos Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nropasta vazio', () => {
    const { result } = renderHook(() => useValidationsProcessos());

    const invalidData = { ...initialProcessos, nropasta: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo NroPasta não pode ficar vazio.');
  });

  
  test('deve invalidar nropasta muito longo', () => {
    const { result } = renderHook(() => useValidationsProcessos());

    const invalidData = { 
      ...initialProcessos, 
      nropasta: 'a'.repeat(10+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo NroPasta não pode ter mais de 10 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsProcessos());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialProcessos, id: 1, nropasta: 'Processos Teste' }];
    mockProcessosService.getAll.mockResolvedValue(mockData);
    mockProcessosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useProcessosList(mockProcessosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useProcessosComboBox(mockProcessosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsProcessos()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Processos Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Processos Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useProcessosForm(initialProcessos, mockProcessosService)
    );

    const mockEvent = {
      target: {
        name: 'ajgpedidonegado',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.ajgpedidonegado).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nropasta: 'Processos 1' },
      { id: 2, nropasta: 'Processos 2' }
    ];
    mockProcessosService.getList.mockResolvedValue(mockOptions as IProcessos[]);


    const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Processos 1' },
        { id: 2, nome: 'Processos 2' }
      ]);
    });

    expect(mockProcessosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nropasta: 'Processos ABC' },
      { id: 2, nropasta: 'Processos XYZ' }
    ];
    mockProcessosService.getList.mockResolvedValue(mockOptions as IProcessos[]);   


 const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Processos ABC' },
        { id: 2, nome: 'Processos XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Processos ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nropasta: 'Processos ABC' },
      { id: 2, nropasta: 'Processos XYZ' }
    ];
    mockProcessosService.getList.mockResolvedValue(mockOptions as IProcessos[]);
  


    const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Processos ABC' },
        { id: 2, nome: 'Processos XYZ' }
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
          {id: 1, nome: 'Processos ABC' },
          {id: 2, nome: 'Processos XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService)
    );

    const newValue = { id: 1, nropasta: 'Processos Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nropasta: 'Processos Inicial' };
    
    const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useProcessosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nropasta: 'Processos Inicial' };
    
    const { result } = renderHook(() => 
      useProcessosComboBox(mockProcessosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






