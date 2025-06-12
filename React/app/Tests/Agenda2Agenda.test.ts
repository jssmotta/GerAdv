// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAgenda2AgendaForm, useAgenda2AgendaList, useValidationsAgenda2Agenda } from '../GerAdv_TS/Agenda2Agenda/Hooks/hookAgenda2Agenda';
import { IAgenda2Agenda } from '../GerAdv_TS/Agenda2Agenda/Interfaces/interface.Agenda2Agenda';
import { IAgenda2AgendaService } from '../GerAdv_TS/Agenda2Agenda/Services/Agenda2Agenda.service';
import { Agenda2AgendaTestEmpty } from '../GerAdv_TS/Models/Agenda2Agenda';


// Mock do serviço
const mockAgenda2AgendaService: jest.Mocked<IAgenda2AgendaService> = {
  fetchAgenda2AgendaById: jest.fn(),
  saveAgenda2Agenda: jest.fn(),
  
  getAll: jest.fn(),
  deleteAgenda2Agenda: jest.fn(),
  validateAgenda2Agenda: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAgenda2Agenda: IAgenda2Agenda = { ...Agenda2AgendaTestEmpty() };

describe('useAgenda2AgendaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAgenda2AgendaForm(initialAgenda2Agenda, mockAgenda2AgendaService)
    );

    expect(result.current.data).toEqual(initialAgenda2Agenda);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAgenda2AgendaForm(initialAgenda2Agenda, mockAgenda2AgendaService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Agenda2 Agenda',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Agenda2 Agenda');
  });

   test('deve carregar Agenda2 Agenda por ID', async () => {
    const mockAgenda2Agenda = { ...initialAgenda2Agenda, id: 1, campo: 'Agenda2 Agenda Teste' };
    mockAgenda2AgendaService.fetchAgenda2AgendaById.mockResolvedValue(mockAgenda2Agenda);

    const { result } = renderHook(() => 
      useAgenda2AgendaForm(initialAgenda2Agenda, mockAgenda2AgendaService)
    );

    await act(async () => {
      await result.current.loadAgenda2Agenda(1);
    });

    expect(mockAgenda2AgendaService.fetchAgenda2AgendaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAgenda2Agenda);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Agenda2 Agenda', async () => {
    const errorMessage = 'Erro ao carregar Agenda2 Agenda';
    mockAgenda2AgendaService.fetchAgenda2AgendaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAgenda2AgendaForm(initialAgenda2Agenda, mockAgenda2AgendaService)
    );

    await act(async () => {
      await result.current.loadAgenda2Agenda(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAgenda2AgendaForm(initialAgenda2Agenda, mockAgenda2AgendaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAgenda2Agenda, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAgenda2Agenda);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAgenda2AgendaForm(initialAgenda2Agenda, mockAgenda2AgendaService)
    );

    await act(async () => {
      await result.current.loadAgenda2Agenda(0);
    });

    expect(mockAgenda2AgendaService.fetchAgenda2AgendaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAgenda2Agenda);
  });
});

describe('useAgenda2AgendaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAgenda2AgendaList(mockAgenda2AgendaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAgenda2Agenda, id: 1, campo: 'Agenda2 Agenda 1' },
      { ...initialAgenda2Agenda, id: 2, campo: 'Agenda2 Agenda 2' }
    ];
    mockAgenda2AgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAgenda2AgendaList(mockAgenda2AgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAgenda2AgendaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAgenda2AgendaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAgenda2AgendaList(mockAgenda2AgendaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAgenda2Agenda, id: 1, campo: 'Agenda2 Agenda Filtrado' }];
    const filtro = { campo: 'Agenda2 Agenda' };
    mockAgenda2AgendaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAgenda2AgendaList(mockAgenda2AgendaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAgenda2AgendaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAgenda2Agenda', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAgenda2Agenda());

    const validData = { ...initialAgenda2Agenda, campo: 'Agenda2 Agenda Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAgenda2Agenda());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAgenda2Agenda, id: 1, campo: 'Agenda2 Agenda Teste' }];
    mockAgenda2AgendaService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAgenda2AgendaList(mockAgenda2AgendaService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsAgenda2Agenda()
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
});