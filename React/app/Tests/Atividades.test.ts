// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAtividadesForm, useAtividadesList, useValidationsAtividades } from '../GerAdv_TS/Atividades/Hooks/hookAtividades';
import { IAtividades } from '../GerAdv_TS/Atividades/Interfaces/interface.Atividades';
import { IAtividadesService } from '../GerAdv_TS/Atividades/Services/Atividades.service';
import { AtividadesTestEmpty } from '../GerAdv_TS/Models/Atividades';
import { useAtividadesComboBox } from '../GerAdv_TS/Atividades/Hooks/hookAtividades';

// Mock do serviço
const mockAtividadesService: jest.Mocked<IAtividadesService> = {
  fetchAtividadesById: jest.fn(),
  saveAtividades: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteAtividades: jest.fn(),
  validateAtividades: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAtividades: IAtividades = { ...AtividadesTestEmpty() };

describe('useAtividadesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAtividadesForm(initialAtividades, mockAtividadesService)
    );

    expect(result.current.data).toEqual(initialAtividades);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAtividadesForm(initialAtividades, mockAtividadesService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo Atividades',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo Atividades');
  });

   test('deve carregar Atividades por ID', async () => {
    const mockAtividades = { ...initialAtividades, id: 1, descricao: 'Atividades Teste' };
    mockAtividadesService.fetchAtividadesById.mockResolvedValue(mockAtividades);

    const { result } = renderHook(() => 
      useAtividadesForm(initialAtividades, mockAtividadesService)
    );

    await act(async () => {
      await result.current.loadAtividades(1);
    });

    expect(mockAtividadesService.fetchAtividadesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAtividades);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Atividades', async () => {
    const errorMessage = 'Erro ao carregar Atividades';
    mockAtividadesService.fetchAtividadesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAtividadesForm(initialAtividades, mockAtividadesService)
    );

    await act(async () => {
      await result.current.loadAtividades(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAtividadesForm(initialAtividades, mockAtividadesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAtividades, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAtividades);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAtividadesForm(initialAtividades, mockAtividadesService)
    );

    await act(async () => {
      await result.current.loadAtividades(0);
    });

    expect(mockAtividadesService.fetchAtividadesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAtividades);
  });
});

describe('useAtividadesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAtividadesList(mockAtividadesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAtividades, id: 1, descricao: 'Atividades 1' },
      { ...initialAtividades, id: 2, descricao: 'Atividades 2' }
    ];
    mockAtividadesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAtividadesList(mockAtividadesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAtividadesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAtividadesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAtividadesList(mockAtividadesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAtividades, id: 1, descricao: 'Atividades Filtrado' }];
    const filtro = { descricao: 'Atividades' };
    mockAtividadesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAtividadesList(mockAtividadesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAtividadesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAtividades', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAtividades());

    const validData = { ...initialAtividades, descricao: 'Atividades Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsAtividades());

    const invalidData = { ...initialAtividades, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsAtividades());

    const invalidData = { 
      ...initialAtividades, 
      descricao: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAtividades());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAtividades, id: 1, descricao: 'Atividades Teste' }];
    mockAtividadesService.getAll.mockResolvedValue(mockData);
    mockAtividadesService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAtividadesList(mockAtividadesService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsAtividades()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Atividades Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Atividades Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Atividades 1' },
      { id: 2, descricao: 'Atividades 2' }
    ];
    mockAtividadesService.getList.mockResolvedValue(mockOptions as IAtividades[]);


    const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Atividades 1' },
        { id: 2, nome: 'Atividades 2' }
      ]);
    });

    expect(mockAtividadesService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Atividades ABC' },
      { id: 2, descricao: 'Atividades XYZ' }
    ];
    mockAtividadesService.getList.mockResolvedValue(mockOptions as IAtividades[]);   


 const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Atividades ABC' },
        { id: 2, nome: 'Atividades XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Atividades ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Atividades ABC' },
      { id: 2, descricao: 'Atividades XYZ' }
    ];
    mockAtividadesService.getList.mockResolvedValue(mockOptions as IAtividades[]);
  


    const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Atividades ABC' },
        { id: 2, nome: 'Atividades XYZ' }
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
          {id: 1, nome: 'Atividades ABC' },
          {id: 2, nome: 'Atividades XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService)
    );

    const newValue = { id: 1, descricao: 'Atividades Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'Atividades Inicial' };
    
    const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useAtividadesComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'Atividades Inicial' };
    
    const { result } = renderHook(() => 
      useAtividadesComboBox(mockAtividadesService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






