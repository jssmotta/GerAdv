// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { usePrecatoriaForm, usePrecatoriaList, useValidationsPrecatoria } from '../GerAdv_TS/Precatoria/Hooks/hookPrecatoria';
import { IPrecatoria } from '../GerAdv_TS/Precatoria/Interfaces/interface.Precatoria';
import { IPrecatoriaService } from '../GerAdv_TS/Precatoria/Services/Precatoria.service';
import { PrecatoriaTestEmpty } from '../GerAdv_TS/Models/Precatoria';


// Mock do serviço
const mockPrecatoriaService: jest.Mocked<IPrecatoriaService> = {
  fetchPrecatoriaById: jest.fn(),
  savePrecatoria: jest.fn(),
  
  getAll: jest.fn(),
  deletePrecatoria: jest.fn(),
  validatePrecatoria: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialPrecatoria: IPrecatoria = { ...PrecatoriaTestEmpty() };

describe('usePrecatoriaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      usePrecatoriaForm(initialPrecatoria, mockPrecatoriaService)
    );

    expect(result.current.data).toEqual(initialPrecatoria);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      usePrecatoriaForm(initialPrecatoria, mockPrecatoriaService)
    );

    const mockEvent = {
      target: {
        name: 'precatoriax',
        value: 'Novo Precatoria',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.precatoriax).toBe('Novo Precatoria');
  });

   test('deve carregar Precatoria por ID', async () => {
    const mockPrecatoria = { ...initialPrecatoria, id: 1, precatoriax: 'Precatoria Teste' };
    mockPrecatoriaService.fetchPrecatoriaById.mockResolvedValue(mockPrecatoria);

    const { result } = renderHook(() => 
      usePrecatoriaForm(initialPrecatoria, mockPrecatoriaService)
    );

    await act(async () => {
      await result.current.loadPrecatoria(1);
    });

    expect(mockPrecatoriaService.fetchPrecatoriaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockPrecatoria);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Precatoria', async () => {
    const errorMessage = 'Erro ao carregar Precatoria';
    mockPrecatoriaService.fetchPrecatoriaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      usePrecatoriaForm(initialPrecatoria, mockPrecatoriaService)
    );

    await act(async () => {
      await result.current.loadPrecatoria(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      usePrecatoriaForm(initialPrecatoria, mockPrecatoriaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialPrecatoria, precatoriax: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialPrecatoria);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      usePrecatoriaForm(initialPrecatoria, mockPrecatoriaService)
    );

    await act(async () => {
      await result.current.loadPrecatoria(0);
    });

    expect(mockPrecatoriaService.fetchPrecatoriaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialPrecatoria);
  });
});

describe('usePrecatoriaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      usePrecatoriaList(mockPrecatoriaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialPrecatoria, id: 1, precatoriax: 'Precatoria 1' },
      { ...initialPrecatoria, id: 2, precatoriax: 'Precatoria 2' }
    ];
    mockPrecatoriaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      usePrecatoriaList(mockPrecatoriaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockPrecatoriaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockPrecatoriaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      usePrecatoriaList(mockPrecatoriaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialPrecatoria, id: 1, precatoriax: 'Precatoria Filtrado' }];
    const filtro = { precatoriax: 'Precatoria' };
    mockPrecatoriaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      usePrecatoriaList(mockPrecatoriaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockPrecatoriaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsPrecatoria', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsPrecatoria());

    const validData = { ...initialPrecatoria, precatoriax: 'Precatoria Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsPrecatoria());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialPrecatoria, id: 1, precatoriax: 'Precatoria Teste' }];
    mockPrecatoriaService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      usePrecatoriaList(mockPrecatoriaService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsPrecatoria()
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