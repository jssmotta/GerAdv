// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useDiario2Form, useDiario2List, useValidationsDiario2 } from '../GerAdv_TS/Diario2/Hooks/hookDiario2';
import { IDiario2 } from '../GerAdv_TS/Diario2/Interfaces/interface.Diario2';
import { IDiario2Service } from '../GerAdv_TS/Diario2/Services/Diario2.service';
import { Diario2TestEmpty } from '../GerAdv_TS/Models/Diario2';
import { useDiario2ComboBox } from '../GerAdv_TS/Diario2/Hooks/hookDiario2';

// Mock do serviço
const mockDiario2Service: jest.Mocked<IDiario2Service> = {
  fetchDiario2ById: jest.fn(),
  saveDiario2: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteDiario2: jest.fn(),
  validateDiario2: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialDiario2: IDiario2 = { ...Diario2TestEmpty() };

describe('useDiario2Form', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useDiario2Form(initialDiario2, mockDiario2Service)
    );

    expect(result.current.data).toEqual(initialDiario2);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useDiario2Form(initialDiario2, mockDiario2Service)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Diário',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Diário');
  });

   test('deve carregar Diário por ID', async () => {
    const mockDiario2 = { ...initialDiario2, id: 1, nome: 'Diário Teste' };
    mockDiario2Service.fetchDiario2ById.mockResolvedValue(mockDiario2);

    const { result } = renderHook(() => 
      useDiario2Form(initialDiario2, mockDiario2Service)
    );

    await act(async () => {
      await result.current.loadDiario2(1);
    });

    expect(mockDiario2Service.fetchDiario2ById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockDiario2);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Diário', async () => {
    const errorMessage = 'Erro ao carregar Diário';
    mockDiario2Service.fetchDiario2ById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useDiario2Form(initialDiario2, mockDiario2Service)
    );

    await act(async () => {
      await result.current.loadDiario2(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useDiario2Form(initialDiario2, mockDiario2Service)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialDiario2, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialDiario2);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useDiario2Form(initialDiario2, mockDiario2Service)
    );

    await act(async () => {
      await result.current.loadDiario2(0);
    });

    expect(mockDiario2Service.fetchDiario2ById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialDiario2);
  });
});

describe('useDiario2List', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useDiario2List(mockDiario2Service)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialDiario2, id: 1, nome: 'Diário 1' },
      { ...initialDiario2, id: 2, nome: 'Diário 2' }
    ];
    mockDiario2Service.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useDiario2List(mockDiario2Service)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockDiario2Service.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockDiario2Service.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useDiario2List(mockDiario2Service)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialDiario2, id: 1, nome: 'Diário Filtrado' }];
    const filtro = { nome: 'Diário' };
    mockDiario2Service.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useDiario2List(mockDiario2Service)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockDiario2Service.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsDiario2', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsDiario2());

    const validData = { ...initialDiario2, nome: 'Diário Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsDiario2());

    const invalidData = { ...initialDiario2, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsDiario2());

    const invalidData = { 
      ...initialDiario2, 
      nome: 'a'.repeat(150+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 150 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsDiario2());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialDiario2, id: 1, nome: 'Diário Teste' }];
    mockDiario2Service.getAll.mockResolvedValue(mockData);
    mockDiario2Service.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useDiario2List(mockDiario2Service)
    );
    
     const { result: comboResult } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsDiario2()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Diário Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Diário Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Diário 1' },
      { id: 2, nome: 'Diário 2' }
    ];
    mockDiario2Service.getList.mockResolvedValue(mockOptions as IDiario2[]);


    const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Diário 1' },
        { id: 2, nome: 'Diário 2' }
      ]);
    });


    expect(mockDiario2Service.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Diário ABC' },
      { id: 2, nome: 'Diário XYZ' }
    ];
    mockDiario2Service.getList.mockResolvedValue(mockOptions as IDiario2[]);   


 const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Diário ABC' },
        { id: 2, nome: 'Diário XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Diário ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Diário ABC' },
      { id: 2, nome: 'Diário XYZ' }
    ];
    mockDiario2Service.getList.mockResolvedValue(mockOptions as IDiario2[]);
  


    const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Diário ABC' },
        { id: 2, nome: 'Diário XYZ' }
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
          {id: 1, nome: 'Diário ABC' },
          {id: 2, nome: 'Diário XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service)
    );

    const newValue = { id: 1, nome: 'Diário Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Diário Inicial' };
    
    const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useDiario2ComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Diário Inicial' };
    
    const { result } = renderHook(() => 
      useDiario2ComboBox(mockDiario2Service, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






