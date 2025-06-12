// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useReuniaoPessoasForm, useReuniaoPessoasList, useValidationsReuniaoPessoas } from '../GerAdv_TS/ReuniaoPessoas/Hooks/hookReuniaoPessoas';
import { IReuniaoPessoas } from '../GerAdv_TS/ReuniaoPessoas/Interfaces/interface.ReuniaoPessoas';
import { IReuniaoPessoasService } from '../GerAdv_TS/ReuniaoPessoas/Services/ReuniaoPessoas.service';
import { ReuniaoPessoasTestEmpty } from '../GerAdv_TS/Models/ReuniaoPessoas';


// Mock do serviço
const mockReuniaoPessoasService: jest.Mocked<IReuniaoPessoasService> = {
  fetchReuniaoPessoasById: jest.fn(),
  saveReuniaoPessoas: jest.fn(),
  
  getAll: jest.fn(),
  deleteReuniaoPessoas: jest.fn(),
  validateReuniaoPessoas: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialReuniaoPessoas: IReuniaoPessoas = { ...ReuniaoPessoasTestEmpty() };

describe('useReuniaoPessoasForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useReuniaoPessoasForm(initialReuniaoPessoas, mockReuniaoPessoasService)
    );

    expect(result.current.data).toEqual(initialReuniaoPessoas);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useReuniaoPessoasForm(initialReuniaoPessoas, mockReuniaoPessoasService)
    );

    const mockEvent = {
      target: {
        name: 'campo',
        value: 'Novo Reuniao Pessoas',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.campo).toBe('Novo Reuniao Pessoas');
  });

   test('deve carregar Reuniao Pessoas por ID', async () => {
    const mockReuniaoPessoas = { ...initialReuniaoPessoas, id: 1, campo: 'Reuniao Pessoas Teste' };
    mockReuniaoPessoasService.fetchReuniaoPessoasById.mockResolvedValue(mockReuniaoPessoas);

    const { result } = renderHook(() => 
      useReuniaoPessoasForm(initialReuniaoPessoas, mockReuniaoPessoasService)
    );

    await act(async () => {
      await result.current.loadReuniaoPessoas(1);
    });

    expect(mockReuniaoPessoasService.fetchReuniaoPessoasById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockReuniaoPessoas);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Reuniao Pessoas', async () => {
    const errorMessage = 'Erro ao carregar Reuniao Pessoas';
    mockReuniaoPessoasService.fetchReuniaoPessoasById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useReuniaoPessoasForm(initialReuniaoPessoas, mockReuniaoPessoasService)
    );

    await act(async () => {
      await result.current.loadReuniaoPessoas(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useReuniaoPessoasForm(initialReuniaoPessoas, mockReuniaoPessoasService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialReuniaoPessoas, campo: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialReuniaoPessoas);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useReuniaoPessoasForm(initialReuniaoPessoas, mockReuniaoPessoasService)
    );

    await act(async () => {
      await result.current.loadReuniaoPessoas(0);
    });

    expect(mockReuniaoPessoasService.fetchReuniaoPessoasById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialReuniaoPessoas);
  });
});

describe('useReuniaoPessoasList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useReuniaoPessoasList(mockReuniaoPessoasService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialReuniaoPessoas, id: 1, campo: 'Reuniao Pessoas 1' },
      { ...initialReuniaoPessoas, id: 2, campo: 'Reuniao Pessoas 2' }
    ];
    mockReuniaoPessoasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useReuniaoPessoasList(mockReuniaoPessoasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockReuniaoPessoasService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockReuniaoPessoasService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useReuniaoPessoasList(mockReuniaoPessoasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialReuniaoPessoas, id: 1, campo: 'Reuniao Pessoas Filtrado' }];
    const filtro = { campo: 'Reuniao Pessoas' };
    mockReuniaoPessoasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useReuniaoPessoasList(mockReuniaoPessoasService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockReuniaoPessoasService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsReuniaoPessoas', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsReuniaoPessoas());

    const validData = { ...initialReuniaoPessoas, campo: 'Reuniao Pessoas Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsReuniaoPessoas());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialReuniaoPessoas, id: 1, campo: 'Reuniao Pessoas Teste' }];
    mockReuniaoPessoasService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useReuniaoPessoasList(mockReuniaoPessoasService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsReuniaoPessoas()
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