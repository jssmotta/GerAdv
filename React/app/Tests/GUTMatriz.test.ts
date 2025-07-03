// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useGUTMatrizForm, useGUTMatrizList, useValidationsGUTMatriz } from '../GerAdv_TS/GUTMatriz/Hooks/hookGUTMatriz';
import { IGUTMatriz } from '../GerAdv_TS/GUTMatriz/Interfaces/interface.GUTMatriz';
import { IGUTMatrizService } from '../GerAdv_TS/GUTMatriz/Services/GUTMatriz.service';
import { GUTMatrizTestEmpty } from '../GerAdv_TS/Models/GUTMatriz';
import { useGUTMatrizComboBox } from '../GerAdv_TS/GUTMatriz/Hooks/hookGUTMatriz';

// Mock do serviço
const mockGUTMatrizService: jest.Mocked<IGUTMatrizService> = {
  fetchGUTMatrizById: jest.fn(),
  saveGUTMatriz: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteGUTMatriz: jest.fn(),
  validateGUTMatriz: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialGUTMatriz: IGUTMatriz = { ...GUTMatrizTestEmpty() };

describe('useGUTMatrizForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useGUTMatrizForm(initialGUTMatriz, mockGUTMatrizService)
    );

    expect(result.current.data).toEqual(initialGUTMatriz);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useGUTMatrizForm(initialGUTMatriz, mockGUTMatrizService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo G U T Matriz',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo G U T Matriz');
  });

   test('deve carregar G U T Matriz por ID', async () => {
    const mockGUTMatriz = { ...initialGUTMatriz, id: 1, descricao: 'G U T Matriz Teste' };
    mockGUTMatrizService.fetchGUTMatrizById.mockResolvedValue(mockGUTMatriz);

    const { result } = renderHook(() => 
      useGUTMatrizForm(initialGUTMatriz, mockGUTMatrizService)
    );

    await act(async () => {
      await result.current.loadGUTMatriz(1);
    });

    expect(mockGUTMatrizService.fetchGUTMatrizById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockGUTMatriz);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar G U T Matriz', async () => {
    const errorMessage = 'Erro ao carregar G U T Matriz';
    mockGUTMatrizService.fetchGUTMatrizById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTMatrizForm(initialGUTMatriz, mockGUTMatrizService)
    );

    await act(async () => {
      await result.current.loadGUTMatriz(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useGUTMatrizForm(initialGUTMatriz, mockGUTMatrizService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialGUTMatriz, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialGUTMatriz);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useGUTMatrizForm(initialGUTMatriz, mockGUTMatrizService)
    );

    await act(async () => {
      await result.current.loadGUTMatriz(0);
    });

    expect(mockGUTMatrizService.fetchGUTMatrizById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialGUTMatriz);
  });
});

describe('useGUTMatrizList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGUTMatrizList(mockGUTMatrizService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialGUTMatriz, id: 1, descricao: 'G U T Matriz 1' },
      { ...initialGUTMatriz, id: 2, descricao: 'G U T Matriz 2' }
    ];
    mockGUTMatrizService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTMatrizList(mockGUTMatrizService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockGUTMatrizService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockGUTMatrizService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTMatrizList(mockGUTMatrizService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialGUTMatriz, id: 1, descricao: 'G U T Matriz Filtrado' }];
    const filtro = { descricao: 'G U T Matriz' };
    mockGUTMatrizService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTMatrizList(mockGUTMatrizService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockGUTMatrizService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsGUTMatriz', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsGUTMatriz());

    const validData = { ...initialGUTMatriz, descricao: 'G U T Matriz Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsGUTMatriz());

    const invalidData = { ...initialGUTMatriz, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsGUTMatriz());

    const invalidData = { 
      ...initialGUTMatriz, 
      descricao: 'a'.repeat(150+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 150 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsGUTMatriz());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialGUTMatriz, id: 1, descricao: 'G U T Matriz Teste' }];
    mockGUTMatrizService.getAll.mockResolvedValue(mockData);
    mockGUTMatrizService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useGUTMatrizList(mockGUTMatrizService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsGUTMatriz()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'G U T Matriz Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'G U T Matriz Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, descricao: 'G U T Matriz 1' },
      { id: 2, descricao: 'G U T Matriz 2' }
    ];
    mockGUTMatrizService.getList.mockResolvedValue(mockOptions as IGUTMatriz[]);


    const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'G U T Matriz 1' },
        { id: 2, nome: 'G U T Matriz 2' }
      ]);
    });


    expect(mockGUTMatrizService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'G U T Matriz ABC' },
      { id: 2, descricao: 'G U T Matriz XYZ' }
    ];
    mockGUTMatrizService.getList.mockResolvedValue(mockOptions as IGUTMatriz[]);   


 const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'G U T Matriz ABC' },
        { id: 2, nome: 'G U T Matriz XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'G U T Matriz ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'G U T Matriz ABC' },
      { id: 2, descricao: 'G U T Matriz XYZ' }
    ];
    mockGUTMatrizService.getList.mockResolvedValue(mockOptions as IGUTMatriz[]);
  


    const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'G U T Matriz ABC' },
        { id: 2, nome: 'G U T Matriz XYZ' }
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
          {id: 1, nome: 'G U T Matriz ABC' },
          {id: 2, nome: 'G U T Matriz XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService)
    );

    const newValue = { id: 1, descricao: 'G U T Matriz Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'G U T Matriz Inicial' };
    
    const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useGUTMatrizComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'G U T Matriz Inicial' };
    
    const { result } = renderHook(() => 
      useGUTMatrizComboBox(mockGUTMatrizService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






