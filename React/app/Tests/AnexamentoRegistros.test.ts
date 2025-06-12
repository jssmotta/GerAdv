// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAnexamentoRegistrosForm, useAnexamentoRegistrosList, useValidationsAnexamentoRegistros } from '../GerAdv_TS/AnexamentoRegistros/Hooks/hookAnexamentoRegistros';
import { IAnexamentoRegistros } from '../GerAdv_TS/AnexamentoRegistros/Interfaces/interface.AnexamentoRegistros';
import { IAnexamentoRegistrosService } from '../GerAdv_TS/AnexamentoRegistros/Services/AnexamentoRegistros.service';
import { AnexamentoRegistrosTestEmpty } from '../GerAdv_TS/Models/AnexamentoRegistros';


// Mock do serviço
const mockAnexamentoRegistrosService: jest.Mocked<IAnexamentoRegistrosService> = {
  fetchAnexamentoRegistrosById: jest.fn(),
  saveAnexamentoRegistros: jest.fn(),
  
  getAll: jest.fn(),
  deleteAnexamentoRegistros: jest.fn(),
  validateAnexamentoRegistros: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAnexamentoRegistros: IAnexamentoRegistros = { ...AnexamentoRegistrosTestEmpty() };

describe('useAnexamentoRegistrosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAnexamentoRegistrosForm(initialAnexamentoRegistros, mockAnexamentoRegistrosService)
    );

    expect(result.current.data).toEqual(initialAnexamentoRegistros);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAnexamentoRegistrosForm(initialAnexamentoRegistros, mockAnexamentoRegistrosService)
    );

    const mockEvent = {
      target: {
        name: 'guidreg',
        value: 'Novo Anexamento Registros',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.guidreg).toBe('Novo Anexamento Registros');
  });

   test('deve carregar Anexamento Registros por ID', async () => {
    const mockAnexamentoRegistros = { ...initialAnexamentoRegistros, id: 1, guidreg: 'Anexamento Registros Teste' };
    mockAnexamentoRegistrosService.fetchAnexamentoRegistrosById.mockResolvedValue(mockAnexamentoRegistros);

    const { result } = renderHook(() => 
      useAnexamentoRegistrosForm(initialAnexamentoRegistros, mockAnexamentoRegistrosService)
    );

    await act(async () => {
      await result.current.loadAnexamentoRegistros(1);
    });

    expect(mockAnexamentoRegistrosService.fetchAnexamentoRegistrosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAnexamentoRegistros);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Anexamento Registros', async () => {
    const errorMessage = 'Erro ao carregar Anexamento Registros';
    mockAnexamentoRegistrosService.fetchAnexamentoRegistrosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAnexamentoRegistrosForm(initialAnexamentoRegistros, mockAnexamentoRegistrosService)
    );

    await act(async () => {
      await result.current.loadAnexamentoRegistros(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAnexamentoRegistrosForm(initialAnexamentoRegistros, mockAnexamentoRegistrosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAnexamentoRegistros, guidreg: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAnexamentoRegistros);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAnexamentoRegistrosForm(initialAnexamentoRegistros, mockAnexamentoRegistrosService)
    );

    await act(async () => {
      await result.current.loadAnexamentoRegistros(0);
    });

    expect(mockAnexamentoRegistrosService.fetchAnexamentoRegistrosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAnexamentoRegistros);
  });
});

describe('useAnexamentoRegistrosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAnexamentoRegistrosList(mockAnexamentoRegistrosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAnexamentoRegistros, id: 1, guidreg: 'Anexamento Registros 1' },
      { ...initialAnexamentoRegistros, id: 2, guidreg: 'Anexamento Registros 2' }
    ];
    mockAnexamentoRegistrosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAnexamentoRegistrosList(mockAnexamentoRegistrosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAnexamentoRegistrosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAnexamentoRegistrosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAnexamentoRegistrosList(mockAnexamentoRegistrosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAnexamentoRegistros, id: 1, guidreg: 'Anexamento Registros Filtrado' }];
    const filtro = { guidreg: 'Anexamento Registros' };
    mockAnexamentoRegistrosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAnexamentoRegistrosList(mockAnexamentoRegistrosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAnexamentoRegistrosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAnexamentoRegistros', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAnexamentoRegistros());

    const validData = { ...initialAnexamentoRegistros, guidreg: 'Anexamento Registros Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAnexamentoRegistros());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAnexamentoRegistros, id: 1, guidreg: 'Anexamento Registros Teste' }];
    mockAnexamentoRegistrosService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAnexamentoRegistrosList(mockAnexamentoRegistrosService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsAnexamentoRegistros()
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