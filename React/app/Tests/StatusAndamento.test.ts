// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useStatusAndamentoForm, useStatusAndamentoList, useValidationsStatusAndamento } from '../GerAdv_TS/StatusAndamento/Hooks/hookStatusAndamento';
import { IStatusAndamento } from '../GerAdv_TS/StatusAndamento/Interfaces/interface.StatusAndamento';
import { IStatusAndamentoService } from '../GerAdv_TS/StatusAndamento/Services/StatusAndamento.service';
import { StatusAndamentoTestEmpty } from '../GerAdv_TS/Models/StatusAndamento';
import { useStatusAndamentoComboBox } from '../GerAdv_TS/StatusAndamento/Hooks/hookStatusAndamento';

// Mock do serviço
const mockStatusAndamentoService: jest.Mocked<IStatusAndamentoService> = {
  fetchStatusAndamentoById: jest.fn(),
  saveStatusAndamento: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteStatusAndamento: jest.fn(),
  validateStatusAndamento: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialStatusAndamento: IStatusAndamento = { ...StatusAndamentoTestEmpty() };

describe('useStatusAndamentoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useStatusAndamentoForm(initialStatusAndamento, mockStatusAndamentoService)
    );

    expect(result.current.data).toEqual(initialStatusAndamento);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useStatusAndamentoForm(initialStatusAndamento, mockStatusAndamentoService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Status Andamento',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Status Andamento');
  });

   test('deve carregar Status Andamento por ID', async () => {
    const mockStatusAndamento = { ...initialStatusAndamento, id: 1, nome: 'Status Andamento Teste' };
    mockStatusAndamentoService.fetchStatusAndamentoById.mockResolvedValue(mockStatusAndamento);

    const { result } = renderHook(() => 
      useStatusAndamentoForm(initialStatusAndamento, mockStatusAndamentoService)
    );

    await act(async () => {
      await result.current.loadStatusAndamento(1);
    });

    expect(mockStatusAndamentoService.fetchStatusAndamentoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockStatusAndamento);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Status Andamento', async () => {
    const errorMessage = 'Erro ao carregar Status Andamento';
    mockStatusAndamentoService.fetchStatusAndamentoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useStatusAndamentoForm(initialStatusAndamento, mockStatusAndamentoService)
    );

    await act(async () => {
      await result.current.loadStatusAndamento(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useStatusAndamentoForm(initialStatusAndamento, mockStatusAndamentoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialStatusAndamento, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialStatusAndamento);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useStatusAndamentoForm(initialStatusAndamento, mockStatusAndamentoService)
    );

    await act(async () => {
      await result.current.loadStatusAndamento(0);
    });

    expect(mockStatusAndamentoService.fetchStatusAndamentoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialStatusAndamento);
  });
});

describe('useStatusAndamentoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useStatusAndamentoList(mockStatusAndamentoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialStatusAndamento, id: 1, nome: 'Status Andamento 1' },
      { ...initialStatusAndamento, id: 2, nome: 'Status Andamento 2' }
    ];
    mockStatusAndamentoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useStatusAndamentoList(mockStatusAndamentoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockStatusAndamentoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockStatusAndamentoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useStatusAndamentoList(mockStatusAndamentoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialStatusAndamento, id: 1, nome: 'Status Andamento Filtrado' }];
    const filtro = { nome: 'Status Andamento' };
    mockStatusAndamentoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useStatusAndamentoList(mockStatusAndamentoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockStatusAndamentoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsStatusAndamento', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsStatusAndamento());

    const validData = { ...initialStatusAndamento, nome: 'Status Andamento Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsStatusAndamento());

    const invalidData = { ...initialStatusAndamento, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsStatusAndamento());

    const invalidData = { 
      ...initialStatusAndamento, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsStatusAndamento());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialStatusAndamento, id: 1, nome: 'Status Andamento Teste' }];
    mockStatusAndamentoService.getAll.mockResolvedValue(mockData);
    mockStatusAndamentoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useStatusAndamentoList(mockStatusAndamentoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsStatusAndamento()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Status Andamento Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Status Andamento Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Status Andamento 1' },
      { id: 2, nome: 'Status Andamento 2' }
    ];
    mockStatusAndamentoService.getList.mockResolvedValue(mockOptions as IStatusAndamento[]);


    const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Status Andamento 1' },
        { id: 2, nome: 'Status Andamento 2' }
      ]);
    });


    expect(mockStatusAndamentoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Status Andamento ABC' },
      { id: 2, nome: 'Status Andamento XYZ' }
    ];
    mockStatusAndamentoService.getList.mockResolvedValue(mockOptions as IStatusAndamento[]);   


 const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Status Andamento ABC' },
        { id: 2, nome: 'Status Andamento XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Status Andamento ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Status Andamento ABC' },
      { id: 2, nome: 'Status Andamento XYZ' }
    ];
    mockStatusAndamentoService.getList.mockResolvedValue(mockOptions as IStatusAndamento[]);
  


    const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Status Andamento ABC' },
        { id: 2, nome: 'Status Andamento XYZ' }
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
          {id: 1, nome: 'Status Andamento ABC' },
          {id: 2, nome: 'Status Andamento XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService)
    );

    const newValue = { id: 1, nome: 'Status Andamento Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Status Andamento Inicial' };
    
    const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useStatusAndamentoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Status Andamento Inicial' };
    
    const { result } = renderHook(() => 
      useStatusAndamentoComboBox(mockStatusAndamentoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






