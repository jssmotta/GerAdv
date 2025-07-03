// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useCargosForm, useCargosList, useValidationsCargos } from '../GerAdv_TS/Cargos/Hooks/hookCargos';
import { ICargos } from '../GerAdv_TS/Cargos/Interfaces/interface.Cargos';
import { ICargosService } from '../GerAdv_TS/Cargos/Services/Cargos.service';
import { CargosTestEmpty } from '../GerAdv_TS/Models/Cargos';
import { useCargosComboBox } from '../GerAdv_TS/Cargos/Hooks/hookCargos';

// Mock do serviço
const mockCargosService: jest.Mocked<ICargosService> = {
  fetchCargosById: jest.fn(),
  saveCargos: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteCargos: jest.fn(),
  validateCargos: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialCargos: ICargos = { ...CargosTestEmpty() };

describe('useCargosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useCargosForm(initialCargos, mockCargosService)
    );

    expect(result.current.data).toEqual(initialCargos);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useCargosForm(initialCargos, mockCargosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Cargo',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Cargo');
  });

   test('deve carregar Cargo por ID', async () => {
    const mockCargos = { ...initialCargos, id: 1, nome: 'Cargo Teste' };
    mockCargosService.fetchCargosById.mockResolvedValue(mockCargos);

    const { result } = renderHook(() => 
      useCargosForm(initialCargos, mockCargosService)
    );

    await act(async () => {
      await result.current.loadCargos(1);
    });

    expect(mockCargosService.fetchCargosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockCargos);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Cargo', async () => {
    const errorMessage = 'Erro ao carregar Cargo';
    mockCargosService.fetchCargosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCargosForm(initialCargos, mockCargosService)
    );

    await act(async () => {
      await result.current.loadCargos(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useCargosForm(initialCargos, mockCargosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialCargos, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialCargos);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useCargosForm(initialCargos, mockCargosService)
    );

    await act(async () => {
      await result.current.loadCargos(0);
    });

    expect(mockCargosService.fetchCargosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialCargos);
  });
});

describe('useCargosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCargosList(mockCargosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialCargos, id: 1, nome: 'Cargo 1' },
      { ...initialCargos, id: 2, nome: 'Cargo 2' }
    ];
    mockCargosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCargosList(mockCargosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockCargosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockCargosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useCargosList(mockCargosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialCargos, id: 1, nome: 'Cargo Filtrado' }];
    const filtro = { nome: 'Cargo' };
    mockCargosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useCargosList(mockCargosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockCargosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsCargos', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsCargos());

    const validData = { ...initialCargos, nome: 'Cargo Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsCargos());

    const invalidData = { ...initialCargos, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsCargos());

    const invalidData = { 
      ...initialCargos, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsCargos());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialCargos, id: 1, nome: 'Cargo Teste' }];
    mockCargosService.getAll.mockResolvedValue(mockData);
    mockCargosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useCargosList(mockCargosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useCargosComboBox(mockCargosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsCargos()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cargo Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Cargo Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargo 1' },
      { id: 2, nome: 'Cargo 2' }
    ];
    mockCargosService.getList.mockResolvedValue(mockOptions as ICargos[]);


    const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargo 1' },
        { id: 2, nome: 'Cargo 2' }
      ]);
    });


    expect(mockCargosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargo ABC' },
      { id: 2, nome: 'Cargo XYZ' }
    ];
    mockCargosService.getList.mockResolvedValue(mockOptions as ICargos[]);   


 const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargo ABC' },
        { id: 2, nome: 'Cargo XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Cargo ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Cargo ABC' },
      { id: 2, nome: 'Cargo XYZ' }
    ];
    mockCargosService.getList.mockResolvedValue(mockOptions as ICargos[]);
  


    const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Cargo ABC' },
        { id: 2, nome: 'Cargo XYZ' }
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
          {id: 1, nome: 'Cargo ABC' },
          {id: 2, nome: 'Cargo XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService)
    );

    const newValue = { id: 1, nome: 'Cargo Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Cargo Inicial' };
    
    const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useCargosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Cargo Inicial' };
    
    const { result } = renderHook(() => 
      useCargosComboBox(mockCargosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






