// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { usePaisesForm, usePaisesList, useValidationsPaises } from '../GerAdv_TS/Paises/Hooks/hookPaises';
import { IPaises } from '../GerAdv_TS/Paises/Interfaces/interface.Paises';
import { IPaisesService } from '../GerAdv_TS/Paises/Services/Paises.service';
import { PaisesTestEmpty } from '../GerAdv_TS/Models/Paises';
import { usePaisesComboBox } from '../GerAdv_TS/Paises/Hooks/hookPaises';

// Mock do serviço
const mockPaisesService: jest.Mocked<IPaisesService> = {
  fetchPaisesById: jest.fn(),
  savePaises: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deletePaises: jest.fn(),
  validatePaises: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialPaises: IPaises = { ...PaisesTestEmpty() };

describe('usePaisesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      usePaisesForm(initialPaises, mockPaisesService)
    );

    expect(result.current.data).toEqual(initialPaises);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      usePaisesForm(initialPaises, mockPaisesService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Paises',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Paises');
  });

   test('deve carregar Paises por ID', async () => {
    const mockPaises = { ...initialPaises, id: 1, nome: 'Paises Teste' };
    mockPaisesService.fetchPaisesById.mockResolvedValue(mockPaises);

    const { result } = renderHook(() => 
      usePaisesForm(initialPaises, mockPaisesService)
    );

    await act(async () => {
      await result.current.loadPaises(1);
    });

    expect(mockPaisesService.fetchPaisesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockPaises);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Paises', async () => {
    const errorMessage = 'Erro ao carregar Paises';
    mockPaisesService.fetchPaisesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      usePaisesForm(initialPaises, mockPaisesService)
    );

    await act(async () => {
      await result.current.loadPaises(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      usePaisesForm(initialPaises, mockPaisesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialPaises, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialPaises);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      usePaisesForm(initialPaises, mockPaisesService)
    );

    await act(async () => {
      await result.current.loadPaises(0);
    });

    expect(mockPaisesService.fetchPaisesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialPaises);
  });
});

describe('usePaisesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      usePaisesList(mockPaisesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialPaises, id: 1, nome: 'Paises 1' },
      { ...initialPaises, id: 2, nome: 'Paises 2' }
    ];
    mockPaisesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      usePaisesList(mockPaisesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockPaisesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockPaisesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      usePaisesList(mockPaisesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialPaises, id: 1, nome: 'Paises Filtrado' }];
    const filtro = { nome: 'Paises' };
    mockPaisesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      usePaisesList(mockPaisesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockPaisesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsPaises', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsPaises());

    const validData = { ...initialPaises, nome: 'Paises Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsPaises());

    const invalidData = { ...initialPaises, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsPaises());

    const invalidData = { 
      ...initialPaises, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsPaises());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialPaises, id: 1, nome: 'Paises Teste' }];
    mockPaisesService.getAll.mockResolvedValue(mockData);
    mockPaisesService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      usePaisesList(mockPaisesService)
    );
    
     const { result: comboResult } = renderHook(() => 
      usePaisesComboBox(mockPaisesService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsPaises()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Paises Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Paises Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Paises 1' },
      { id: 2, nome: 'Paises 2' }
    ];
    mockPaisesService.getList.mockResolvedValue(mockOptions as IPaises[]);


    const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Paises 1' },
        { id: 2, nome: 'Paises 2' }
      ]);
    });


    expect(mockPaisesService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Paises ABC' },
      { id: 2, nome: 'Paises XYZ' }
    ];
    mockPaisesService.getList.mockResolvedValue(mockOptions as IPaises[]);   


 const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Paises ABC' },
        { id: 2, nome: 'Paises XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Paises ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Paises ABC' },
      { id: 2, nome: 'Paises XYZ' }
    ];
    mockPaisesService.getList.mockResolvedValue(mockOptions as IPaises[]);
  


    const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Paises ABC' },
        { id: 2, nome: 'Paises XYZ' }
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
          {id: 1, nome: 'Paises ABC' },
          {id: 2, nome: 'Paises XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService)
    );

    const newValue = { id: 1, nome: 'Paises Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Paises Inicial' };
    
    const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('usePaisesComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Paises Inicial' };
    
    const { result } = renderHook(() => 
      usePaisesComboBox(mockPaisesService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






