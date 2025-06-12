// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useProDepositosForm, useProDepositosList, useValidationsProDepositos } from '../GerAdv_TS/ProDepositos/Hooks/hookProDepositos';
import { IProDepositos } from '../GerAdv_TS/ProDepositos/Interfaces/interface.ProDepositos';
import { IProDepositosService } from '../GerAdv_TS/ProDepositos/Services/ProDepositos.service';
import { ProDepositosTestEmpty } from '../GerAdv_TS/Models/ProDepositos';


// Mock do serviço
const mockProDepositosService: jest.Mocked<IProDepositosService> = {
  fetchProDepositosById: jest.fn(),
  saveProDepositos: jest.fn(),
  
  getAll: jest.fn(),
  deleteProDepositos: jest.fn(),
  validateProDepositos: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialProDepositos: IProDepositos = { ...ProDepositosTestEmpty() };

describe('useProDepositosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useProDepositosForm(initialProDepositos, mockProDepositosService)
    );

    expect(result.current.data).toEqual(initialProDepositos);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useProDepositosForm(initialProDepositos, mockProDepositosService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Pro Depositos',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Pro Depositos');
  });

   test('deve carregar Pro Depositos por ID', async () => {
    const mockProDepositos = { ...initialProDepositos, id: 1, campo: 'Pro Depositos Teste' };
    mockProDepositosService.fetchProDepositosById.mockResolvedValue(mockProDepositos);

    const { result } = renderHook(() => 
      useProDepositosForm(initialProDepositos, mockProDepositosService)
    );

    await act(async () => {
      await result.current.loadProDepositos(1);
    });

    expect(mockProDepositosService.fetchProDepositosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockProDepositos);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Pro Depositos', async () => {
    const errorMessage = 'Erro ao carregar Pro Depositos';
    mockProDepositosService.fetchProDepositosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProDepositosForm(initialProDepositos, mockProDepositosService)
    );

    await act(async () => {
      await result.current.loadProDepositos(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useProDepositosForm(initialProDepositos, mockProDepositosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialProDepositos, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialProDepositos);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useProDepositosForm(initialProDepositos, mockProDepositosService)
    );

    await act(async () => {
      await result.current.loadProDepositos(0);
    });

    expect(mockProDepositosService.fetchProDepositosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialProDepositos);
  });
});

describe('useProDepositosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProDepositosList(mockProDepositosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialProDepositos, id: 1, campo: 'Pro Depositos 1' },
      { ...initialProDepositos, id: 2, campo: 'Pro Depositos 2' }
    ];
    mockProDepositosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProDepositosList(mockProDepositosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockProDepositosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockProDepositosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProDepositosList(mockProDepositosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialProDepositos, id: 1, campo: 'Pro Depositos Filtrado' }];
    const filtro = { campo: 'Pro Depositos' };
    mockProDepositosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProDepositosList(mockProDepositosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockProDepositosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsProDepositos', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsProDepositos());

    const validData = { ...initialProDepositos, campo: 'Pro Depositos Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsProDepositos());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialProDepositos, id: 1, campo: 'Pro Depositos Teste' }];
    mockProDepositosService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useProDepositosList(mockProDepositosService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsProDepositos()
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