// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAgendaRepetirForm, useAgendaRepetirList, useValidationsAgendaRepetir } from '../GerAdv_TS/AgendaRepetir/Hooks/hookAgendaRepetir';
import { IAgendaRepetir } from '../GerAdv_TS/AgendaRepetir/Interfaces/interface.AgendaRepetir';
import { IAgendaRepetirService } from '../GerAdv_TS/AgendaRepetir/Services/AgendaRepetir.service';
import { AgendaRepetirTestEmpty } from '../GerAdv_TS/Models/AgendaRepetir';


// Mock do serviço
const mockAgendaRepetirService: jest.Mocked<IAgendaRepetirService> = {
  fetchAgendaRepetirById: jest.fn(),
  saveAgendaRepetir: jest.fn(),
  
  getAll: jest.fn(),
  deleteAgendaRepetir: jest.fn(),
  validateAgendaRepetir: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAgendaRepetir: IAgendaRepetir = { ...AgendaRepetirTestEmpty() };

describe('useAgendaRepetirForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    expect(result.current.data).toEqual(initialAgendaRepetir);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    const mockEvent = {
      target: {
        name: 'mensagem',
        value: 'Novo Agenda Repetir',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.mensagem).toBe('Novo Agenda Repetir');
  });

   test('deve carregar Agenda Repetir por ID', async () => {
    const mockAgendaRepetir = { ...initialAgendaRepetir, id: 1, mensagem: 'Agenda Repetir Teste' };
    mockAgendaRepetirService.fetchAgendaRepetirById.mockResolvedValue(mockAgendaRepetir);

    const { result } = renderHook(() => 
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    await act(async () => {
      await result.current.loadAgendaRepetir(1);
    });

    expect(mockAgendaRepetirService.fetchAgendaRepetirById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAgendaRepetir);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Agenda Repetir', async () => {
    const errorMessage = 'Erro ao carregar Agenda Repetir';
    mockAgendaRepetirService.fetchAgendaRepetirById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    await act(async () => {
      await result.current.loadAgendaRepetir(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAgendaRepetir, mensagem: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAgendaRepetir);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    await act(async () => {
      await result.current.loadAgendaRepetir(0);
    });

    expect(mockAgendaRepetirService.fetchAgendaRepetirById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAgendaRepetir);
  });
});

describe('useAgendaRepetirList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAgendaRepetirList(mockAgendaRepetirService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAgendaRepetir, id: 1, mensagem: 'Agenda Repetir 1' },
      { ...initialAgendaRepetir, id: 2, mensagem: 'Agenda Repetir 2' }
    ];
    mockAgendaRepetirService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAgendaRepetirList(mockAgendaRepetirService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAgendaRepetirService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAgendaRepetirService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAgendaRepetirList(mockAgendaRepetirService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAgendaRepetir, id: 1, mensagem: 'Agenda Repetir Filtrado' }];
    const filtro = { mensagem: 'Agenda Repetir' };
    mockAgendaRepetirService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAgendaRepetirList(mockAgendaRepetirService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAgendaRepetirService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAgendaRepetir', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAgendaRepetir());

    const validData = { ...initialAgendaRepetir, mensagem: 'Agenda Repetir Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAgendaRepetir());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAgendaRepetir, id: 1, mensagem: 'Agenda Repetir Teste' }];
    mockAgendaRepetirService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAgendaRepetirList(mockAgendaRepetirService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsAgendaRepetir()
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
      useAgendaRepetirForm(initialAgendaRepetir, mockAgendaRepetirService)
    );

    const mockEvent = {
      target: {
        name: 'pessoal',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.pessoal).toBe(true);
  });


