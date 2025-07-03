// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoCompromissoForm, useTipoCompromissoList, useValidationsTipoCompromisso } from '../GerAdv_TS/TipoCompromisso/Hooks/hookTipoCompromisso';
import { ITipoCompromisso } from '../GerAdv_TS/TipoCompromisso/Interfaces/interface.TipoCompromisso';
import { ITipoCompromissoService } from '../GerAdv_TS/TipoCompromisso/Services/TipoCompromisso.service';
import { TipoCompromissoTestEmpty } from '../GerAdv_TS/Models/TipoCompromisso';
import { useTipoCompromissoComboBox } from '../GerAdv_TS/TipoCompromisso/Hooks/hookTipoCompromisso';

// Mock do serviço
const mockTipoCompromissoService: jest.Mocked<ITipoCompromissoService> = {
  fetchTipoCompromissoById: jest.fn(),
  saveTipoCompromisso: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoCompromisso: jest.fn(),
  validateTipoCompromisso: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoCompromisso: ITipoCompromisso = { ...TipoCompromissoTestEmpty() };

describe('useTipoCompromissoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    expect(result.current.data).toEqual(initialTipoCompromisso);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo Tipo Compromisso',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo Tipo Compromisso');
  });

   test('deve carregar Tipo Compromisso por ID', async () => {
    const mockTipoCompromisso = { ...initialTipoCompromisso, id: 1, descricao: 'Tipo Compromisso Teste' };
    mockTipoCompromissoService.fetchTipoCompromissoById.mockResolvedValue(mockTipoCompromisso);

    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    await act(async () => {
      await result.current.loadTipoCompromisso(1);
    });

    expect(mockTipoCompromissoService.fetchTipoCompromissoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoCompromisso);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo Compromisso', async () => {
    const errorMessage = 'Erro ao carregar Tipo Compromisso';
    mockTipoCompromissoService.fetchTipoCompromissoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    await act(async () => {
      await result.current.loadTipoCompromisso(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoCompromisso, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoCompromisso);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    await act(async () => {
      await result.current.loadTipoCompromisso(0);
    });

    expect(mockTipoCompromissoService.fetchTipoCompromissoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoCompromisso);
  });
});

describe('useTipoCompromissoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoList(mockTipoCompromissoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoCompromisso, id: 1, descricao: 'Tipo Compromisso 1' },
      { ...initialTipoCompromisso, id: 2, descricao: 'Tipo Compromisso 2' }
    ];
    mockTipoCompromissoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoCompromissoList(mockTipoCompromissoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoCompromissoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoCompromissoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoCompromissoList(mockTipoCompromissoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoCompromisso, id: 1, descricao: 'Tipo Compromisso Filtrado' }];
    const filtro = { descricao: 'Tipo Compromisso' };
    mockTipoCompromissoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoCompromissoList(mockTipoCompromissoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoCompromissoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoCompromisso', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoCompromisso());

    const validData = { ...initialTipoCompromisso, descricao: 'Tipo Compromisso Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsTipoCompromisso());

    const invalidData = { ...initialTipoCompromisso, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoCompromisso());

    const invalidData = { 
      ...initialTipoCompromisso, 
      descricao: 'a'.repeat(100+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 100 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoCompromisso());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoCompromisso, id: 1, descricao: 'Tipo Compromisso Teste' }];
    mockTipoCompromissoService.getAll.mockResolvedValue(mockData);
    mockTipoCompromissoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoCompromissoList(mockTipoCompromissoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoCompromisso()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Compromisso Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Compromisso Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoForm(initialTipoCompromisso, mockTipoCompromissoService)
    );

    const mockEvent = {
      target: {
        name: 'financeiro',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.financeiro).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Tipo Compromisso 1' },
      { id: 2, descricao: 'Tipo Compromisso 2' }
    ];
    mockTipoCompromissoService.getList.mockResolvedValue(mockOptions as ITipoCompromisso[]);


    const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Compromisso 1' },
        { id: 2, nome: 'Tipo Compromisso 2' }
      ]);
    });


    expect(mockTipoCompromissoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Tipo Compromisso ABC' },
      { id: 2, descricao: 'Tipo Compromisso XYZ' }
    ];
    mockTipoCompromissoService.getList.mockResolvedValue(mockOptions as ITipoCompromisso[]);   


 const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Compromisso ABC' },
        { id: 2, nome: 'Tipo Compromisso XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo Compromisso ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Tipo Compromisso ABC' },
      { id: 2, descricao: 'Tipo Compromisso XYZ' }
    ];
    mockTipoCompromissoService.getList.mockResolvedValue(mockOptions as ITipoCompromisso[]);
  


    const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Compromisso ABC' },
        { id: 2, nome: 'Tipo Compromisso XYZ' }
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
          {id: 1, nome: 'Tipo Compromisso ABC' },
          {id: 2, nome: 'Tipo Compromisso XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService)
    );

    const newValue = { id: 1, descricao: 'Tipo Compromisso Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'Tipo Compromisso Inicial' };
    
    const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoCompromissoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'Tipo Compromisso Inicial' };
    
    const { result } = renderHook(() => 
      useTipoCompromissoComboBox(mockTipoCompromissoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






