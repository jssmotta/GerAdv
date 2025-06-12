// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useContatoCRMForm, useContatoCRMList, useValidationsContatoCRM } from '../GerAdv_TS/ContatoCRM/Hooks/hookContatoCRM';
import { IContatoCRM } from '../GerAdv_TS/ContatoCRM/Interfaces/interface.ContatoCRM';
import { IContatoCRMService } from '../GerAdv_TS/ContatoCRM/Services/ContatoCRM.service';
import { ContatoCRMTestEmpty } from '../GerAdv_TS/Models/ContatoCRM';


// Mock do serviço
const mockContatoCRMService: jest.Mocked<IContatoCRMService> = {
  fetchContatoCRMById: jest.fn(),
  saveContatoCRM: jest.fn(),
  
  getAll: jest.fn(),
  deleteContatoCRM: jest.fn(),
  validateContatoCRM: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialContatoCRM: IContatoCRM = { ...ContatoCRMTestEmpty() };

describe('useContatoCRMForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    expect(result.current.data).toEqual(initialContatoCRM);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    const mockEvent = {
      target: {
        name: 'assunto',
        value: 'Novo Contato C R M',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.assunto).toBe('Novo Contato C R M');
  });

   test('deve carregar Contato C R M por ID', async () => {
    const mockContatoCRM = { ...initialContatoCRM, id: 1, assunto: 'Contato C R M Teste' };
    mockContatoCRMService.fetchContatoCRMById.mockResolvedValue(mockContatoCRM);

    const { result } = renderHook(() => 
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    await act(async () => {
      await result.current.loadContatoCRM(1);
    });

    expect(mockContatoCRMService.fetchContatoCRMById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockContatoCRM);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Contato C R M', async () => {
    const errorMessage = 'Erro ao carregar Contato C R M';
    mockContatoCRMService.fetchContatoCRMById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    await act(async () => {
      await result.current.loadContatoCRM(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialContatoCRM, assunto: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialContatoCRM);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    await act(async () => {
      await result.current.loadContatoCRM(0);
    });

    expect(mockContatoCRMService.fetchContatoCRMById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialContatoCRM);
  });
});

describe('useContatoCRMList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useContatoCRMList(mockContatoCRMService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialContatoCRM, id: 1, assunto: 'Contato C R M 1' },
      { ...initialContatoCRM, id: 2, assunto: 'Contato C R M 2' }
    ];
    mockContatoCRMService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useContatoCRMList(mockContatoCRMService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockContatoCRMService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockContatoCRMService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useContatoCRMList(mockContatoCRMService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialContatoCRM, id: 1, assunto: 'Contato C R M Filtrado' }];
    const filtro = { assunto: 'Contato C R M' };
    mockContatoCRMService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useContatoCRMList(mockContatoCRMService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockContatoCRMService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsContatoCRM', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsContatoCRM());

    const validData = { ...initialContatoCRM, assunto: 'Contato C R M Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsContatoCRM());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialContatoCRM, id: 1, assunto: 'Contato C R M Teste' }];
    mockContatoCRMService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useContatoCRMList(mockContatoCRMService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsContatoCRM()
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
      useContatoCRMForm(initialContatoCRM, mockContatoCRMService)
    );

    const mockEvent = {
      target: {
        name: 'naopublicavel',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.naopublicavel).toBe(true);
  });


