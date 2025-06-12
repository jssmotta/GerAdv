// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useNECompromissosForm, useNECompromissosList, useValidationsNECompromissos } from '../GerAdv_TS/NECompromissos/Hooks/hookNECompromissos';
import { INECompromissos } from '../GerAdv_TS/NECompromissos/Interfaces/interface.NECompromissos';
import { INECompromissosService } from '../GerAdv_TS/NECompromissos/Services/NECompromissos.service';
import { NECompromissosTestEmpty } from '../GerAdv_TS/Models/NECompromissos';


// Mock do serviço
const mockNECompromissosService: jest.Mocked<INECompromissosService> = {
  fetchNECompromissosById: jest.fn(),
  saveNECompromissos: jest.fn(),
  
  getAll: jest.fn(),
  deleteNECompromissos: jest.fn(),
  validateNECompromissos: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialNECompromissos: INECompromissos = { ...NECompromissosTestEmpty() };

describe('useNECompromissosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    expect(result.current.data).toEqual(initialNECompromissos);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    const mockEvent = {
      target: {
        name: 'textocompromisso',
        value: 'Novo N E Compromissos',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.textocompromisso).toBe('Novo N E Compromissos');
  });

   test('deve carregar N E Compromissos por ID', async () => {
    const mockNECompromissos = { ...initialNECompromissos, id: 1, textocompromisso: 'N E Compromissos Teste' };
    mockNECompromissosService.fetchNECompromissosById.mockResolvedValue(mockNECompromissos);

    const { result } = renderHook(() => 
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    await act(async () => {
      await result.current.loadNECompromissos(1);
    });

    expect(mockNECompromissosService.fetchNECompromissosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockNECompromissos);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar N E Compromissos', async () => {
    const errorMessage = 'Erro ao carregar N E Compromissos';
    mockNECompromissosService.fetchNECompromissosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    await act(async () => {
      await result.current.loadNECompromissos(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialNECompromissos, textocompromisso: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialNECompromissos);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    await act(async () => {
      await result.current.loadNECompromissos(0);
    });

    expect(mockNECompromissosService.fetchNECompromissosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialNECompromissos);
  });
});

describe('useNECompromissosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useNECompromissosList(mockNECompromissosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialNECompromissos, id: 1, textocompromisso: 'N E Compromissos 1' },
      { ...initialNECompromissos, id: 2, textocompromisso: 'N E Compromissos 2' }
    ];
    mockNECompromissosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useNECompromissosList(mockNECompromissosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockNECompromissosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockNECompromissosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useNECompromissosList(mockNECompromissosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialNECompromissos, id: 1, textocompromisso: 'N E Compromissos Filtrado' }];
    const filtro = { textocompromisso: 'N E Compromissos' };
    mockNECompromissosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useNECompromissosList(mockNECompromissosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockNECompromissosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsNECompromissos', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsNECompromissos());

    const validData = { ...initialNECompromissos, textocompromisso: 'N E Compromissos Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsNECompromissos());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialNECompromissos, id: 1, textocompromisso: 'N E Compromissos Teste' }];
    mockNECompromissosService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useNECompromissosList(mockNECompromissosService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsNECompromissos()
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
      useNECompromissosForm(initialNECompromissos, mockNECompromissosService)
    );

    const mockEvent = {
      target: {
        name: 'provisionar',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.provisionar).toBe(true);
  });


