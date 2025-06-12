// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useOperadorGruposAgendaForm, useOperadorGruposAgendaList, useValidationsOperadorGruposAgenda } from '../GerAdv_TS/OperadorGruposAgenda/Hooks/hookOperadorGruposAgenda';
import { IOperadorGruposAgenda } from '../GerAdv_TS/OperadorGruposAgenda/Interfaces/interface.OperadorGruposAgenda';
import { IOperadorGruposAgendaService } from '../GerAdv_TS/OperadorGruposAgenda/Services/OperadorGruposAgenda.service';
import { OperadorGruposAgendaTestEmpty } from '../GerAdv_TS/Models/OperadorGruposAgenda';
import { useOperadorGruposAgendaComboBox } from '../GerAdv_TS/OperadorGruposAgenda/Hooks/hookOperadorGruposAgenda';

// Mock do serviço
const mockOperadorGruposAgendaService: jest.Mocked<IOperadorGruposAgendaService> = {
  fetchOperadorGruposAgendaById: jest.fn(),
  saveOperadorGruposAgenda: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteOperadorGruposAgenda: jest.fn(),
  validateOperadorGruposAgenda: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialOperadorGruposAgenda: IOperadorGruposAgenda = { ...OperadorGruposAgendaTestEmpty() };

describe('useOperadorGruposAgendaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaForm(initialOperadorGruposAgenda, mockOperadorGruposAgendaService)
    );

    expect(result.current.data).toEqual(initialOperadorGruposAgenda);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaForm(initialOperadorGruposAgenda, mockOperadorGruposAgendaService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Operador Grupos Agenda',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Operador Grupos Agenda');
  });

   test('deve carregar Operador Grupos Agenda por ID', async () => {
    const mockOperadorGruposAgenda = { ...initialOperadorGruposAgenda, id: 1, nome: 'Operador Grupos Agenda Teste' };
    mockOperadorGruposAgendaService.fetchOperadorGruposAgendaById.mockResolvedValue(mockOperadorGruposAgenda);

    const { result } = renderHook(() => 
      useOperadorGruposAgendaForm(initialOperadorGruposAgenda, mockOperadorGruposAgendaService)
    );

    await act(async () => {
      await result.current.loadOperadorGruposAgenda(1);
    });

    expect(mockOperadorGruposAgendaService.fetchOperadorGruposAgendaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockOperadorGruposAgenda);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Operador Grupos Agenda', async () => {
    const errorMessage = 'Erro ao carregar Operador Grupos Agenda';
    mockOperadorGruposAgendaService.fetchOperadorGruposAgendaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadorGruposAgendaForm(initialOperadorGruposAgenda, mockOperadorGruposAgendaService)
    );

    await act(async () => {
      await result.current.loadOperadorGruposAgenda(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaForm(initialOperadorGruposAgenda, mockOperadorGruposAgendaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialOperadorGruposAgenda, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialOperadorGruposAgenda);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaForm(initialOperadorGruposAgenda, mockOperadorGruposAgendaService)
    );

    await act(async () => {
      await result.current.loadOperadorGruposAgenda(0);
    });

    expect(mockOperadorGruposAgendaService.fetchOperadorGruposAgendaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialOperadorGruposAgenda);
  });
});

describe('useOperadorGruposAgendaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaList(mockOperadorGruposAgendaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialOperadorGruposAgenda, id: 1, nome: 'Operador Grupos Agenda 1' },
      { ...initialOperadorGruposAgenda, id: 2, nome: 'Operador Grupos Agenda 2' }
    ];
    mockOperadorGruposAgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadorGruposAgendaList(mockOperadorGruposAgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockOperadorGruposAgendaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockOperadorGruposAgendaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useOperadorGruposAgendaList(mockOperadorGruposAgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialOperadorGruposAgenda, id: 1, nome: 'Operador Grupos Agenda Filtrado' }];
    const filtro = { nome: 'Operador Grupos Agenda' };
    mockOperadorGruposAgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useOperadorGruposAgendaList(mockOperadorGruposAgendaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockOperadorGruposAgendaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsOperadorGruposAgenda', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsOperadorGruposAgenda());

    const validData = { ...initialOperadorGruposAgenda, nome: 'Operador Grupos Agenda Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsOperadorGruposAgenda());

    const invalidData = { ...initialOperadorGruposAgenda, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsOperadorGruposAgenda());

    const invalidData = { 
      ...initialOperadorGruposAgenda, 
      nome: 'a'.repeat(100+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 100 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsOperadorGruposAgenda());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialOperadorGruposAgenda, id: 1, nome: 'Operador Grupos Agenda Teste' }];
    mockOperadorGruposAgendaService.getAll.mockResolvedValue(mockData);
    mockOperadorGruposAgendaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useOperadorGruposAgendaList(mockOperadorGruposAgendaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsOperadorGruposAgenda()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Operador Grupos Agenda Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Operador Grupos Agenda Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador Grupos Agenda 1' },
      { id: 2, nome: 'Operador Grupos Agenda 2' }
    ];
    mockOperadorGruposAgendaService.getList.mockResolvedValue(mockOptions as IOperadorGruposAgenda[]);


    const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador Grupos Agenda 1' },
        { id: 2, nome: 'Operador Grupos Agenda 2' }
      ]);
    });

    expect(mockOperadorGruposAgendaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador Grupos Agenda ABC' },
      { id: 2, nome: 'Operador Grupos Agenda XYZ' }
    ];
    mockOperadorGruposAgendaService.getList.mockResolvedValue(mockOptions as IOperadorGruposAgenda[]);   


 const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador Grupos Agenda ABC' },
        { id: 2, nome: 'Operador Grupos Agenda XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Operador Grupos Agenda ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Operador Grupos Agenda ABC' },
      { id: 2, nome: 'Operador Grupos Agenda XYZ' }
    ];
    mockOperadorGruposAgendaService.getList.mockResolvedValue(mockOptions as IOperadorGruposAgenda[]);
  


    const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Operador Grupos Agenda ABC' },
        { id: 2, nome: 'Operador Grupos Agenda XYZ' }
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
          {id: 1, nome: 'Operador Grupos Agenda ABC' },
          {id: 2, nome: 'Operador Grupos Agenda XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService)
    );

    const newValue = { id: 1, nome: 'Operador Grupos Agenda Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Operador Grupos Agenda Inicial' };
    
    const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useOperadorGruposAgendaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Operador Grupos Agenda Inicial' };
    
    const { result } = renderHook(() => 
      useOperadorGruposAgendaComboBox(mockOperadorGruposAgendaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






