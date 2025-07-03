// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useStatusTarefasForm, useStatusTarefasList, useValidationsStatusTarefas } from '../GerAdv_TS/StatusTarefas/Hooks/hookStatusTarefas';
import { IStatusTarefas } from '../GerAdv_TS/StatusTarefas/Interfaces/interface.StatusTarefas';
import { IStatusTarefasService } from '../GerAdv_TS/StatusTarefas/Services/StatusTarefas.service';
import { StatusTarefasTestEmpty } from '../GerAdv_TS/Models/StatusTarefas';
import { useStatusTarefasComboBox } from '../GerAdv_TS/StatusTarefas/Hooks/hookStatusTarefas';

// Mock do serviço
const mockStatusTarefasService: jest.Mocked<IStatusTarefasService> = {
  fetchStatusTarefasById: jest.fn(),
  saveStatusTarefas: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteStatusTarefas: jest.fn(),
  validateStatusTarefas: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialStatusTarefas: IStatusTarefas = { ...StatusTarefasTestEmpty() };

describe('useStatusTarefasForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useStatusTarefasForm(initialStatusTarefas, mockStatusTarefasService)
    );

    expect(result.current.data).toEqual(initialStatusTarefas);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useStatusTarefasForm(initialStatusTarefas, mockStatusTarefasService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Status Tarefas',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Status Tarefas');
  });

   test('deve carregar Status Tarefas por ID', async () => {
    const mockStatusTarefas = { ...initialStatusTarefas, id: 1, nome: 'Status Tarefas Teste' };
    mockStatusTarefasService.fetchStatusTarefasById.mockResolvedValue(mockStatusTarefas);

    const { result } = renderHook(() => 
      useStatusTarefasForm(initialStatusTarefas, mockStatusTarefasService)
    );

    await act(async () => {
      await result.current.loadStatusTarefas(1);
    });

    expect(mockStatusTarefasService.fetchStatusTarefasById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockStatusTarefas);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Status Tarefas', async () => {
    const errorMessage = 'Erro ao carregar Status Tarefas';
    mockStatusTarefasService.fetchStatusTarefasById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useStatusTarefasForm(initialStatusTarefas, mockStatusTarefasService)
    );

    await act(async () => {
      await result.current.loadStatusTarefas(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useStatusTarefasForm(initialStatusTarefas, mockStatusTarefasService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialStatusTarefas, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialStatusTarefas);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useStatusTarefasForm(initialStatusTarefas, mockStatusTarefasService)
    );

    await act(async () => {
      await result.current.loadStatusTarefas(0);
    });

    expect(mockStatusTarefasService.fetchStatusTarefasById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialStatusTarefas);
  });
});

describe('useStatusTarefasList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useStatusTarefasList(mockStatusTarefasService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialStatusTarefas, id: 1, nome: 'Status Tarefas 1' },
      { ...initialStatusTarefas, id: 2, nome: 'Status Tarefas 2' }
    ];
    mockStatusTarefasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useStatusTarefasList(mockStatusTarefasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockStatusTarefasService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockStatusTarefasService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useStatusTarefasList(mockStatusTarefasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialStatusTarefas, id: 1, nome: 'Status Tarefas Filtrado' }];
    const filtro = { nome: 'Status Tarefas' };
    mockStatusTarefasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useStatusTarefasList(mockStatusTarefasService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockStatusTarefasService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsStatusTarefas', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsStatusTarefas());

    const validData = { ...initialStatusTarefas, nome: 'Status Tarefas Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsStatusTarefas());

    const invalidData = { ...initialStatusTarefas, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsStatusTarefas());

    const invalidData = { 
      ...initialStatusTarefas, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsStatusTarefas());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialStatusTarefas, id: 1, nome: 'Status Tarefas Teste' }];
    mockStatusTarefasService.getAll.mockResolvedValue(mockData);
    mockStatusTarefasService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useStatusTarefasList(mockStatusTarefasService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsStatusTarefas()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Status Tarefas Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Status Tarefas Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Status Tarefas 1' },
      { id: 2, nome: 'Status Tarefas 2' }
    ];
    mockStatusTarefasService.getList.mockResolvedValue(mockOptions as IStatusTarefas[]);


    const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Status Tarefas 1' },
        { id: 2, nome: 'Status Tarefas 2' }
      ]);
    });


    expect(mockStatusTarefasService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Status Tarefas ABC' },
      { id: 2, nome: 'Status Tarefas XYZ' }
    ];
    mockStatusTarefasService.getList.mockResolvedValue(mockOptions as IStatusTarefas[]);   


 const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Status Tarefas ABC' },
        { id: 2, nome: 'Status Tarefas XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Status Tarefas ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Status Tarefas ABC' },
      { id: 2, nome: 'Status Tarefas XYZ' }
    ];
    mockStatusTarefasService.getList.mockResolvedValue(mockOptions as IStatusTarefas[]);
  


    const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Status Tarefas ABC' },
        { id: 2, nome: 'Status Tarefas XYZ' }
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
          {id: 1, nome: 'Status Tarefas ABC' },
          {id: 2, nome: 'Status Tarefas XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService)
    );

    const newValue = { id: 1, nome: 'Status Tarefas Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Status Tarefas Inicial' };
    
    const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useStatusTarefasComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Status Tarefas Inicial' };
    
    const { result } = renderHook(() => 
      useStatusTarefasComboBox(mockStatusTarefasService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






