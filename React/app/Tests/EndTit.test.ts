// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useEndTitForm, useEndTitList, useValidationsEndTit } from '../GerAdv_TS/EndTit/Hooks/hookEndTit';
import { IEndTit } from '../GerAdv_TS/EndTit/Interfaces/interface.EndTit';
import { IEndTitService } from '../GerAdv_TS/EndTit/Services/EndTit.service';
import { EndTitTestEmpty } from '../GerAdv_TS/Models/EndTit';


// Mock do serviço
const mockEndTitService: jest.Mocked<IEndTitService> = {
  fetchEndTitById: jest.fn(),
  saveEndTit: jest.fn(),
  
  getAll: jest.fn(),
  deleteEndTit: jest.fn(),
  validateEndTit: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialEndTit: IEndTit = { ...EndTitTestEmpty() };

describe('useEndTitForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useEndTitForm(initialEndTit, mockEndTitService)
    );

    expect(result.current.data).toEqual(initialEndTit);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useEndTitForm(initialEndTit, mockEndTitService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo End Tit',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo End Tit');
  });

   test('deve carregar End Tit por ID', async () => {
    const mockEndTit = { ...initialEndTit, id: 1, campo: 'End Tit Teste' };
    mockEndTitService.fetchEndTitById.mockResolvedValue(mockEndTit);

    const { result } = renderHook(() => 
      useEndTitForm(initialEndTit, mockEndTitService)
    );

    await act(async () => {
      await result.current.loadEndTit(1);
    });

    expect(mockEndTitService.fetchEndTitById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockEndTit);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar End Tit', async () => {
    const errorMessage = 'Erro ao carregar End Tit';
    mockEndTitService.fetchEndTitById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useEndTitForm(initialEndTit, mockEndTitService)
    );

    await act(async () => {
      await result.current.loadEndTit(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useEndTitForm(initialEndTit, mockEndTitService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialEndTit, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialEndTit);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useEndTitForm(initialEndTit, mockEndTitService)
    );

    await act(async () => {
      await result.current.loadEndTit(0);
    });

    expect(mockEndTitService.fetchEndTitById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialEndTit);
  });
});

describe('useEndTitList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useEndTitList(mockEndTitService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialEndTit, id: 1, campo: 'End Tit 1' },
      { ...initialEndTit, id: 2, campo: 'End Tit 2' }
    ];
    mockEndTitService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useEndTitList(mockEndTitService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockEndTitService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockEndTitService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useEndTitList(mockEndTitService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialEndTit, id: 1, campo: 'End Tit Filtrado' }];
    const filtro = { campo: 'End Tit' };
    mockEndTitService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useEndTitList(mockEndTitService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockEndTitService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsEndTit', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsEndTit());

    const validData = { ...initialEndTit, campo: 'End Tit Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsEndTit());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialEndTit, id: 1, campo: 'End Tit Teste' }];
    mockEndTitService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useEndTitList(mockEndTitService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsEndTit()
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