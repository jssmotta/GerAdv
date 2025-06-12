// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAgendaForm, useAgendaList, useValidationsAgenda } from '../GerAdv_TS/Agenda/Hooks/hookAgenda';
import { IAgenda } from '../GerAdv_TS/Agenda/Interfaces/interface.Agenda';
import { IAgendaService } from '../GerAdv_TS/Agenda/Services/Agenda.service';
import { AgendaTestEmpty } from '../GerAdv_TS/Models/Agenda';


// Mock do serviço
const mockAgendaService: jest.Mocked<IAgendaService> = {
  fetchAgendaById: jest.fn(),
  saveAgenda: jest.fn(),
  
  getAll: jest.fn(),
  deleteAgenda: jest.fn(),
  validateAgenda: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAgenda: IAgenda = { ...AgendaTestEmpty() };

describe('useAgendaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    expect(result.current.data).toEqual(initialAgenda);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    const mockEvent = {
      target: {
        name: 'compromisso',
        value: 'Novo Agenda',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.compromisso).toBe('Novo Agenda');
  });

   test('deve carregar Agenda por ID', async () => {
    const mockAgenda = { ...initialAgenda, id: 1, compromisso: 'Agenda Teste' };
    mockAgendaService.fetchAgendaById.mockResolvedValue(mockAgenda);

    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    await act(async () => {
      await result.current.loadAgenda(1);
    });

    expect(mockAgendaService.fetchAgendaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAgenda);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Agenda', async () => {
    const errorMessage = 'Erro ao carregar Agenda';
    mockAgendaService.fetchAgendaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    await act(async () => {
      await result.current.loadAgenda(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAgenda, compromisso: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAgenda);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    await act(async () => {
      await result.current.loadAgenda(0);
    });

    expect(mockAgendaService.fetchAgendaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAgenda);
  });
});

describe('useAgendaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAgendaList(mockAgendaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAgenda, id: 1, compromisso: 'Agenda 1' },
      { ...initialAgenda, id: 2, compromisso: 'Agenda 2' }
    ];
    mockAgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAgendaList(mockAgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAgendaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAgendaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAgendaList(mockAgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAgenda, id: 1, compromisso: 'Agenda Filtrado' }];
    const filtro = { compromisso: 'Agenda' };
    mockAgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAgendaList(mockAgendaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAgendaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAgenda', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAgenda());

    const validData = { ...initialAgenda, compromisso: 'Agenda Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAgenda());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAgenda, id: 1, compromisso: 'Agenda Teste' }];
    mockAgendaService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAgendaList(mockAgendaService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsAgenda()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
    
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useAgendaForm(initialAgenda, mockAgendaService)
    );

    const mockEvent = {
      target: {
        name: 'clienteavisado',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.clienteavisado).toBe(true);
  });


