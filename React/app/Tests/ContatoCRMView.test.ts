// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useContatoCRMViewForm, useContatoCRMViewList, useValidationsContatoCRMView } from '../GerAdv_TS/ContatoCRMView/Hooks/hookContatoCRMView';
import { IContatoCRMView } from '../GerAdv_TS/ContatoCRMView/Interfaces/interface.ContatoCRMView';
import { IContatoCRMViewService } from '../GerAdv_TS/ContatoCRMView/Services/ContatoCRMView.service';
import { ContatoCRMViewTestEmpty } from '../GerAdv_TS/Models/ContatoCRMView';


// Mock do serviço
const mockContatoCRMViewService: jest.Mocked<IContatoCRMViewService> = {
  fetchContatoCRMViewById: jest.fn(),
  saveContatoCRMView: jest.fn(),
  
  getAll: jest.fn(),
  deleteContatoCRMView: jest.fn(),
  validateContatoCRMView: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialContatoCRMView: IContatoCRMView = { ...ContatoCRMViewTestEmpty() };

describe('useContatoCRMViewForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useContatoCRMViewForm(initialContatoCRMView, mockContatoCRMViewService)
    );

    expect(result.current.data).toEqual(initialContatoCRMView);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useContatoCRMViewForm(initialContatoCRMView, mockContatoCRMViewService)
    );

    const mockEvent = {
      target: {
        name: 'cguid',
        value: 'Novo Contato C R M View',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.cguid).toBe('Novo Contato C R M View');
  });

   test('deve carregar Contato C R M View por ID', async () => {
    const mockContatoCRMView = { ...initialContatoCRMView, id: 1, cguid: 'Contato C R M View Teste' };
    mockContatoCRMViewService.fetchContatoCRMViewById.mockResolvedValue(mockContatoCRMView);

    const { result } = renderHook(() => 
      useContatoCRMViewForm(initialContatoCRMView, mockContatoCRMViewService)
    );

    await act(async () => {
      await result.current.loadContatoCRMView(1);
    });

    expect(mockContatoCRMViewService.fetchContatoCRMViewById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockContatoCRMView);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Contato C R M View', async () => {
    const errorMessage = 'Erro ao carregar Contato C R M View';
    mockContatoCRMViewService.fetchContatoCRMViewById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useContatoCRMViewForm(initialContatoCRMView, mockContatoCRMViewService)
    );

    await act(async () => {
      await result.current.loadContatoCRMView(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useContatoCRMViewForm(initialContatoCRMView, mockContatoCRMViewService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialContatoCRMView, cguid: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialContatoCRMView);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useContatoCRMViewForm(initialContatoCRMView, mockContatoCRMViewService)
    );

    await act(async () => {
      await result.current.loadContatoCRMView(0);
    });

    expect(mockContatoCRMViewService.fetchContatoCRMViewById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialContatoCRMView);
  });
});

describe('useContatoCRMViewList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useContatoCRMViewList(mockContatoCRMViewService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialContatoCRMView, id: 1, cguid: 'Contato C R M View 1' },
      { ...initialContatoCRMView, id: 2, cguid: 'Contato C R M View 2' }
    ];
    mockContatoCRMViewService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useContatoCRMViewList(mockContatoCRMViewService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockContatoCRMViewService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockContatoCRMViewService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useContatoCRMViewList(mockContatoCRMViewService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialContatoCRMView, id: 1, cguid: 'Contato C R M View Filtrado' }];
    const filtro = { cguid: 'Contato C R M View' };
    mockContatoCRMViewService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useContatoCRMViewList(mockContatoCRMViewService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockContatoCRMViewService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsContatoCRMView', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsContatoCRMView());

    const validData = { ...initialContatoCRMView, cguid: 'Contato C R M View Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsContatoCRMView());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialContatoCRMView, id: 1, cguid: 'Contato C R M View Teste' }];
    mockContatoCRMViewService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useContatoCRMViewList(mockContatoCRMViewService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsContatoCRMView()
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