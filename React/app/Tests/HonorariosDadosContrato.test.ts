// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useHonorariosDadosContratoForm, useHonorariosDadosContratoList, useValidationsHonorariosDadosContrato } from '../GerAdv_TS/HonorariosDadosContrato/Hooks/hookHonorariosDadosContrato';
import { IHonorariosDadosContrato } from '../GerAdv_TS/HonorariosDadosContrato/Interfaces/interface.HonorariosDadosContrato';
import { IHonorariosDadosContratoService } from '../GerAdv_TS/HonorariosDadosContrato/Services/HonorariosDadosContrato.service';
import { HonorariosDadosContratoTestEmpty } from '../GerAdv_TS/Models/HonorariosDadosContrato';


// Mock do serviço
const mockHonorariosDadosContratoService: jest.Mocked<IHonorariosDadosContratoService> = {
  fetchHonorariosDadosContratoById: jest.fn(),
  saveHonorariosDadosContrato: jest.fn(),
  
  getAll: jest.fn(),
  deleteHonorariosDadosContrato: jest.fn(),
  validateHonorariosDadosContrato: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialHonorariosDadosContrato: IHonorariosDadosContrato = { ...HonorariosDadosContratoTestEmpty() };

describe('useHonorariosDadosContratoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    expect(result.current.data).toEqual(initialHonorariosDadosContrato);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    const mockEvent = {
      target: {
        name: 'arquivocontrato',
        value: 'Novo Honorarios Dados Contrato',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.arquivocontrato).toBe('Novo Honorarios Dados Contrato');
  });

   test('deve carregar Honorarios Dados Contrato por ID', async () => {
    const mockHonorariosDadosContrato = { ...initialHonorariosDadosContrato, id: 1, arquivocontrato: 'Honorarios Dados Contrato Teste' };
    mockHonorariosDadosContratoService.fetchHonorariosDadosContratoById.mockResolvedValue(mockHonorariosDadosContrato);

    const { result } = renderHook(() => 
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    await act(async () => {
      await result.current.loadHonorariosDadosContrato(1);
    });

    expect(mockHonorariosDadosContratoService.fetchHonorariosDadosContratoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockHonorariosDadosContrato);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Honorarios Dados Contrato', async () => {
    const errorMessage = 'Erro ao carregar Honorarios Dados Contrato';
    mockHonorariosDadosContratoService.fetchHonorariosDadosContratoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    await act(async () => {
      await result.current.loadHonorariosDadosContrato(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialHonorariosDadosContrato, arquivocontrato: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialHonorariosDadosContrato);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    await act(async () => {
      await result.current.loadHonorariosDadosContrato(0);
    });

    expect(mockHonorariosDadosContratoService.fetchHonorariosDadosContratoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialHonorariosDadosContrato);
  });
});

describe('useHonorariosDadosContratoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useHonorariosDadosContratoList(mockHonorariosDadosContratoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialHonorariosDadosContrato, id: 1, arquivocontrato: 'Honorarios Dados Contrato 1' },
      { ...initialHonorariosDadosContrato, id: 2, arquivocontrato: 'Honorarios Dados Contrato 2' }
    ];
    mockHonorariosDadosContratoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useHonorariosDadosContratoList(mockHonorariosDadosContratoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockHonorariosDadosContratoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockHonorariosDadosContratoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useHonorariosDadosContratoList(mockHonorariosDadosContratoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialHonorariosDadosContrato, id: 1, arquivocontrato: 'Honorarios Dados Contrato Filtrado' }];
    const filtro = { arquivocontrato: 'Honorarios Dados Contrato' };
    mockHonorariosDadosContratoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useHonorariosDadosContratoList(mockHonorariosDadosContratoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockHonorariosDadosContratoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsHonorariosDadosContrato', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsHonorariosDadosContrato());

    const validData = { ...initialHonorariosDadosContrato, arquivocontrato: 'Honorarios Dados Contrato Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsHonorariosDadosContrato());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialHonorariosDadosContrato, id: 1, arquivocontrato: 'Honorarios Dados Contrato Teste' }];
    mockHonorariosDadosContratoService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useHonorariosDadosContratoList(mockHonorariosDadosContratoService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsHonorariosDadosContrato()
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
      useHonorariosDadosContratoForm(initialHonorariosDadosContrato, mockHonorariosDadosContratoService)
    );

    const mockEvent = {
      target: {
        name: 'fixo',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.fixo).toBe(true);
  });


