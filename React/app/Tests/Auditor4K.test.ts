// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAuditor4KForm, useAuditor4KList, useValidationsAuditor4K } from '../GerAdv_TS/Auditor4K/Hooks/hookAuditor4K';
import { IAuditor4K } from '../GerAdv_TS/Auditor4K/Interfaces/interface.Auditor4K';
import { IAuditor4KService } from '../GerAdv_TS/Auditor4K/Services/Auditor4K.service';
import { Auditor4KTestEmpty } from '../GerAdv_TS/Models/Auditor4K';
import { useAuditor4KComboBox } from '../GerAdv_TS/Auditor4K/Hooks/hookAuditor4K';

// Mock do serviço
const mockAuditor4KService: jest.Mocked<IAuditor4KService> = {
  fetchAuditor4KById: jest.fn(),
  saveAuditor4K: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteAuditor4K: jest.fn(),
  validateAuditor4K: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAuditor4K: IAuditor4K = { ...Auditor4KTestEmpty() };

describe('useAuditor4KForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAuditor4KForm(initialAuditor4K, mockAuditor4KService)
    );

    expect(result.current.data).toEqual(initialAuditor4K);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAuditor4KForm(initialAuditor4K, mockAuditor4KService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Auditor4 K',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Auditor4 K');
  });

   test('deve carregar Auditor4 K por ID', async () => {
    const mockAuditor4K = { ...initialAuditor4K, id: 1, nome: 'Auditor4 K Teste' };
    mockAuditor4KService.fetchAuditor4KById.mockResolvedValue(mockAuditor4K);

    const { result } = renderHook(() => 
      useAuditor4KForm(initialAuditor4K, mockAuditor4KService)
    );

    await act(async () => {
      await result.current.loadAuditor4K(1);
    });

    expect(mockAuditor4KService.fetchAuditor4KById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAuditor4K);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Auditor4 K', async () => {
    const errorMessage = 'Erro ao carregar Auditor4 K';
    mockAuditor4KService.fetchAuditor4KById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAuditor4KForm(initialAuditor4K, mockAuditor4KService)
    );

    await act(async () => {
      await result.current.loadAuditor4K(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAuditor4KForm(initialAuditor4K, mockAuditor4KService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAuditor4K, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAuditor4K);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAuditor4KForm(initialAuditor4K, mockAuditor4KService)
    );

    await act(async () => {
      await result.current.loadAuditor4K(0);
    });

    expect(mockAuditor4KService.fetchAuditor4KById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAuditor4K);
  });
});

describe('useAuditor4KList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAuditor4KList(mockAuditor4KService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAuditor4K, id: 1, nome: 'Auditor4 K 1' },
      { ...initialAuditor4K, id: 2, nome: 'Auditor4 K 2' }
    ];
    mockAuditor4KService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAuditor4KList(mockAuditor4KService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAuditor4KService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAuditor4KService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAuditor4KList(mockAuditor4KService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAuditor4K, id: 1, nome: 'Auditor4 K Filtrado' }];
    const filtro = { nome: 'Auditor4 K' };
    mockAuditor4KService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAuditor4KList(mockAuditor4KService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAuditor4KService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAuditor4K', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAuditor4K());

    const validData = { ...initialAuditor4K, nome: 'Auditor4 K Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsAuditor4K());

    const invalidData = { ...initialAuditor4K, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsAuditor4K());

    const invalidData = { 
      ...initialAuditor4K, 
      nome: 'a'.repeat(100+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 100 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAuditor4K());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAuditor4K, id: 1, nome: 'Auditor4 K Teste' }];
    mockAuditor4KService.getAll.mockResolvedValue(mockData);
    mockAuditor4KService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAuditor4KList(mockAuditor4KService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsAuditor4K()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Auditor4 K Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Auditor4 K Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Auditor4 K 1' },
      { id: 2, nome: 'Auditor4 K 2' }
    ];
    mockAuditor4KService.getList.mockResolvedValue(mockOptions as IAuditor4K[]);


    const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Auditor4 K 1' },
        { id: 2, nome: 'Auditor4 K 2' }
      ]);
    });

    expect(mockAuditor4KService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Auditor4 K ABC' },
      { id: 2, nome: 'Auditor4 K XYZ' }
    ];
    mockAuditor4KService.getList.mockResolvedValue(mockOptions as IAuditor4K[]);   


 const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Auditor4 K ABC' },
        { id: 2, nome: 'Auditor4 K XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Auditor4 K ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Auditor4 K ABC' },
      { id: 2, nome: 'Auditor4 K XYZ' }
    ];
    mockAuditor4KService.getList.mockResolvedValue(mockOptions as IAuditor4K[]);
  


    const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Auditor4 K ABC' },
        { id: 2, nome: 'Auditor4 K XYZ' }
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
          {id: 1, nome: 'Auditor4 K ABC' },
          {id: 2, nome: 'Auditor4 K XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService)
    );

    const newValue = { id: 1, nome: 'Auditor4 K Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Auditor4 K Inicial' };
    
    const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useAuditor4KComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Auditor4 K Inicial' };
    
    const { result } = renderHook(() => 
      useAuditor4KComboBox(mockAuditor4KService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






