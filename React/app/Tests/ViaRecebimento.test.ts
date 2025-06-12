// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useViaRecebimentoForm, useViaRecebimentoList, useValidationsViaRecebimento } from '../GerAdv_TS/ViaRecebimento/Hooks/hookViaRecebimento';
import { IViaRecebimento } from '../GerAdv_TS/ViaRecebimento/Interfaces/interface.ViaRecebimento';
import { IViaRecebimentoService } from '../GerAdv_TS/ViaRecebimento/Services/ViaRecebimento.service';
import { ViaRecebimentoTestEmpty } from '../GerAdv_TS/Models/ViaRecebimento';
import { useViaRecebimentoComboBox } from '../GerAdv_TS/ViaRecebimento/Hooks/hookViaRecebimento';

// Mock do serviço
const mockViaRecebimentoService: jest.Mocked<IViaRecebimentoService> = {
  fetchViaRecebimentoById: jest.fn(),
  saveViaRecebimento: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteViaRecebimento: jest.fn(),
  validateViaRecebimento: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialViaRecebimento: IViaRecebimento = { ...ViaRecebimentoTestEmpty() };

describe('useViaRecebimentoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useViaRecebimentoForm(initialViaRecebimento, mockViaRecebimentoService)
    );

    expect(result.current.data).toEqual(initialViaRecebimento);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useViaRecebimentoForm(initialViaRecebimento, mockViaRecebimentoService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Via Recebimento',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Via Recebimento');
  });

   test('deve carregar Via Recebimento por ID', async () => {
    const mockViaRecebimento = { ...initialViaRecebimento, id: 1, nome: 'Via Recebimento Teste' };
    mockViaRecebimentoService.fetchViaRecebimentoById.mockResolvedValue(mockViaRecebimento);

    const { result } = renderHook(() => 
      useViaRecebimentoForm(initialViaRecebimento, mockViaRecebimentoService)
    );

    await act(async () => {
      await result.current.loadViaRecebimento(1);
    });

    expect(mockViaRecebimentoService.fetchViaRecebimentoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockViaRecebimento);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Via Recebimento', async () => {
    const errorMessage = 'Erro ao carregar Via Recebimento';
    mockViaRecebimentoService.fetchViaRecebimentoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useViaRecebimentoForm(initialViaRecebimento, mockViaRecebimentoService)
    );

    await act(async () => {
      await result.current.loadViaRecebimento(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useViaRecebimentoForm(initialViaRecebimento, mockViaRecebimentoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialViaRecebimento, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialViaRecebimento);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useViaRecebimentoForm(initialViaRecebimento, mockViaRecebimentoService)
    );

    await act(async () => {
      await result.current.loadViaRecebimento(0);
    });

    expect(mockViaRecebimentoService.fetchViaRecebimentoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialViaRecebimento);
  });
});

describe('useViaRecebimentoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useViaRecebimentoList(mockViaRecebimentoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialViaRecebimento, id: 1, nome: 'Via Recebimento 1' },
      { ...initialViaRecebimento, id: 2, nome: 'Via Recebimento 2' }
    ];
    mockViaRecebimentoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useViaRecebimentoList(mockViaRecebimentoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockViaRecebimentoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockViaRecebimentoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useViaRecebimentoList(mockViaRecebimentoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialViaRecebimento, id: 1, nome: 'Via Recebimento Filtrado' }];
    const filtro = { nome: 'Via Recebimento' };
    mockViaRecebimentoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useViaRecebimentoList(mockViaRecebimentoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockViaRecebimentoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsViaRecebimento', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsViaRecebimento());

    const validData = { ...initialViaRecebimento, nome: 'Via Recebimento Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsViaRecebimento());

    const invalidData = { ...initialViaRecebimento, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsViaRecebimento());

    const invalidData = { 
      ...initialViaRecebimento, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsViaRecebimento());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialViaRecebimento, id: 1, nome: 'Via Recebimento Teste' }];
    mockViaRecebimentoService.getAll.mockResolvedValue(mockData);
    mockViaRecebimentoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useViaRecebimentoList(mockViaRecebimentoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsViaRecebimento()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Via Recebimento Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Via Recebimento Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Via Recebimento 1' },
      { id: 2, nome: 'Via Recebimento 2' }
    ];
    mockViaRecebimentoService.getList.mockResolvedValue(mockOptions as IViaRecebimento[]);


    const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Via Recebimento 1' },
        { id: 2, nome: 'Via Recebimento 2' }
      ]);
    });

    expect(mockViaRecebimentoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Via Recebimento ABC' },
      { id: 2, nome: 'Via Recebimento XYZ' }
    ];
    mockViaRecebimentoService.getList.mockResolvedValue(mockOptions as IViaRecebimento[]);   


 const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Via Recebimento ABC' },
        { id: 2, nome: 'Via Recebimento XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Via Recebimento ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Via Recebimento ABC' },
      { id: 2, nome: 'Via Recebimento XYZ' }
    ];
    mockViaRecebimentoService.getList.mockResolvedValue(mockOptions as IViaRecebimento[]);
  


    const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Via Recebimento ABC' },
        { id: 2, nome: 'Via Recebimento XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    // Remove filtro
    act(() => {
      result.current.handleFilter('');
    });
 

     expect(result.current.options).toEqual([
          {id: 1, nome: 'Via Recebimento ABC' },
          {id: 2, nome: 'Via Recebimento XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService)
    );

    const newValue = { id: 1, nome: 'Via Recebimento Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Via Recebimento Inicial' };
    
    const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useViaRecebimentoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Via Recebimento Inicial' };
    
    const { result } = renderHook(() => 
      useViaRecebimentoComboBox(mockViaRecebimentoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






