// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useEventoPrazoAgendaForm, useEventoPrazoAgendaList, useValidationsEventoPrazoAgenda } from '../GerAdv_TS/EventoPrazoAgenda/Hooks/hookEventoPrazoAgenda';
import { IEventoPrazoAgenda } from '../GerAdv_TS/EventoPrazoAgenda/Interfaces/interface.EventoPrazoAgenda';
import { IEventoPrazoAgendaService } from '../GerAdv_TS/EventoPrazoAgenda/Services/EventoPrazoAgenda.service';
import { EventoPrazoAgendaTestEmpty } from '../GerAdv_TS/Models/EventoPrazoAgenda';
import { useEventoPrazoAgendaComboBox } from '../GerAdv_TS/EventoPrazoAgenda/Hooks/hookEventoPrazoAgenda';

// Mock do serviço
const mockEventoPrazoAgendaService: jest.Mocked<IEventoPrazoAgendaService> = {
  fetchEventoPrazoAgendaById: jest.fn(),
  saveEventoPrazoAgenda: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteEventoPrazoAgenda: jest.fn(),
  validateEventoPrazoAgenda: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialEventoPrazoAgenda: IEventoPrazoAgenda = { ...EventoPrazoAgendaTestEmpty() };

describe('useEventoPrazoAgendaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaForm(initialEventoPrazoAgenda, mockEventoPrazoAgendaService)
    );

    expect(result.current.data).toEqual(initialEventoPrazoAgenda);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaForm(initialEventoPrazoAgenda, mockEventoPrazoAgendaService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Evento Prazo Agenda',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Evento Prazo Agenda');
  });

   test('deve carregar Evento Prazo Agenda por ID', async () => {
    const mockEventoPrazoAgenda = { ...initialEventoPrazoAgenda, id: 1, nome: 'Evento Prazo Agenda Teste' };
    mockEventoPrazoAgendaService.fetchEventoPrazoAgendaById.mockResolvedValue(mockEventoPrazoAgenda);

    const { result } = renderHook(() => 
      useEventoPrazoAgendaForm(initialEventoPrazoAgenda, mockEventoPrazoAgendaService)
    );

    await act(async () => {
      await result.current.loadEventoPrazoAgenda(1);
    });

    expect(mockEventoPrazoAgendaService.fetchEventoPrazoAgendaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockEventoPrazoAgenda);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Evento Prazo Agenda', async () => {
    const errorMessage = 'Erro ao carregar Evento Prazo Agenda';
    mockEventoPrazoAgendaService.fetchEventoPrazoAgendaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useEventoPrazoAgendaForm(initialEventoPrazoAgenda, mockEventoPrazoAgendaService)
    );

    await act(async () => {
      await result.current.loadEventoPrazoAgenda(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaForm(initialEventoPrazoAgenda, mockEventoPrazoAgendaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialEventoPrazoAgenda, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialEventoPrazoAgenda);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaForm(initialEventoPrazoAgenda, mockEventoPrazoAgendaService)
    );

    await act(async () => {
      await result.current.loadEventoPrazoAgenda(0);
    });

    expect(mockEventoPrazoAgendaService.fetchEventoPrazoAgendaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialEventoPrazoAgenda);
  });
});

describe('useEventoPrazoAgendaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaList(mockEventoPrazoAgendaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialEventoPrazoAgenda, id: 1, nome: 'Evento Prazo Agenda 1' },
      { ...initialEventoPrazoAgenda, id: 2, nome: 'Evento Prazo Agenda 2' }
    ];
    mockEventoPrazoAgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useEventoPrazoAgendaList(mockEventoPrazoAgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockEventoPrazoAgendaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockEventoPrazoAgendaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useEventoPrazoAgendaList(mockEventoPrazoAgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialEventoPrazoAgenda, id: 1, nome: 'Evento Prazo Agenda Filtrado' }];
    const filtro = { nome: 'Evento Prazo Agenda' };
    mockEventoPrazoAgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useEventoPrazoAgendaList(mockEventoPrazoAgendaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockEventoPrazoAgendaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsEventoPrazoAgenda', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsEventoPrazoAgenda());

    const validData = { ...initialEventoPrazoAgenda, nome: 'Evento Prazo Agenda Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsEventoPrazoAgenda());

    const invalidData = { ...initialEventoPrazoAgenda, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsEventoPrazoAgenda());

    const invalidData = { 
      ...initialEventoPrazoAgenda, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsEventoPrazoAgenda());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialEventoPrazoAgenda, id: 1, nome: 'Evento Prazo Agenda Teste' }];
    mockEventoPrazoAgendaService.getAll.mockResolvedValue(mockData);
    mockEventoPrazoAgendaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useEventoPrazoAgendaList(mockEventoPrazoAgendaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsEventoPrazoAgenda()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Evento Prazo Agenda Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Evento Prazo Agenda Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Evento Prazo Agenda 1' },
      { id: 2, nome: 'Evento Prazo Agenda 2' }
    ];
    mockEventoPrazoAgendaService.getList.mockResolvedValue(mockOptions as IEventoPrazoAgenda[]);


    const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Evento Prazo Agenda 1' },
        { id: 2, nome: 'Evento Prazo Agenda 2' }
      ]);
    });

    expect(mockEventoPrazoAgendaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Evento Prazo Agenda ABC' },
      { id: 2, nome: 'Evento Prazo Agenda XYZ' }
    ];
    mockEventoPrazoAgendaService.getList.mockResolvedValue(mockOptions as IEventoPrazoAgenda[]);   


 const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Evento Prazo Agenda ABC' },
        { id: 2, nome: 'Evento Prazo Agenda XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Evento Prazo Agenda ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Evento Prazo Agenda ABC' },
      { id: 2, nome: 'Evento Prazo Agenda XYZ' }
    ];
    mockEventoPrazoAgendaService.getList.mockResolvedValue(mockOptions as IEventoPrazoAgenda[]);
  


    const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Evento Prazo Agenda ABC' },
        { id: 2, nome: 'Evento Prazo Agenda XYZ' }
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
          {id: 1, nome: 'Evento Prazo Agenda ABC' },
          {id: 2, nome: 'Evento Prazo Agenda XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService)
    );

    const newValue = { id: 1, nome: 'Evento Prazo Agenda Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Evento Prazo Agenda Inicial' };
    
    const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useEventoPrazoAgendaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Evento Prazo Agenda Inicial' };
    
    const { result } = renderHook(() => 
      useEventoPrazoAgendaComboBox(mockEventoPrazoAgendaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






