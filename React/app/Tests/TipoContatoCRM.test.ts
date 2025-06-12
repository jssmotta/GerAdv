// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoContatoCRMForm, useTipoContatoCRMList, useValidationsTipoContatoCRM } from '../GerAdv_TS/TipoContatoCRM/Hooks/hookTipoContatoCRM';
import { ITipoContatoCRM } from '../GerAdv_TS/TipoContatoCRM/Interfaces/interface.TipoContatoCRM';
import { ITipoContatoCRMService } from '../GerAdv_TS/TipoContatoCRM/Services/TipoContatoCRM.service';
import { TipoContatoCRMTestEmpty } from '../GerAdv_TS/Models/TipoContatoCRM';
import { useTipoContatoCRMComboBox } from '../GerAdv_TS/TipoContatoCRM/Hooks/hookTipoContatoCRM';

// Mock do serviço
const mockTipoContatoCRMService: jest.Mocked<ITipoContatoCRMService> = {
  fetchTipoContatoCRMById: jest.fn(),
  saveTipoContatoCRM: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoContatoCRM: jest.fn(),
  validateTipoContatoCRM: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoContatoCRM: ITipoContatoCRM = { ...TipoContatoCRMTestEmpty() };

describe('useTipoContatoCRMForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMForm(initialTipoContatoCRM, mockTipoContatoCRMService)
    );

    expect(result.current.data).toEqual(initialTipoContatoCRM);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMForm(initialTipoContatoCRM, mockTipoContatoCRMService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Tipo Contato C R M',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Tipo Contato C R M');
  });

   test('deve carregar Tipo Contato C R M por ID', async () => {
    const mockTipoContatoCRM = { ...initialTipoContatoCRM, id: 1, nome: 'Tipo Contato C R M Teste' };
    mockTipoContatoCRMService.fetchTipoContatoCRMById.mockResolvedValue(mockTipoContatoCRM);

    const { result } = renderHook(() => 
      useTipoContatoCRMForm(initialTipoContatoCRM, mockTipoContatoCRMService)
    );

    await act(async () => {
      await result.current.loadTipoContatoCRM(1);
    });

    expect(mockTipoContatoCRMService.fetchTipoContatoCRMById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoContatoCRM);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo Contato C R M', async () => {
    const errorMessage = 'Erro ao carregar Tipo Contato C R M';
    mockTipoContatoCRMService.fetchTipoContatoCRMById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoContatoCRMForm(initialTipoContatoCRM, mockTipoContatoCRMService)
    );

    await act(async () => {
      await result.current.loadTipoContatoCRM(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMForm(initialTipoContatoCRM, mockTipoContatoCRMService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoContatoCRM, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoContatoCRM);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMForm(initialTipoContatoCRM, mockTipoContatoCRMService)
    );

    await act(async () => {
      await result.current.loadTipoContatoCRM(0);
    });

    expect(mockTipoContatoCRMService.fetchTipoContatoCRMById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoContatoCRM);
  });
});

describe('useTipoContatoCRMList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMList(mockTipoContatoCRMService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoContatoCRM, id: 1, nome: 'Tipo Contato C R M 1' },
      { ...initialTipoContatoCRM, id: 2, nome: 'Tipo Contato C R M 2' }
    ];
    mockTipoContatoCRMService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoContatoCRMList(mockTipoContatoCRMService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoContatoCRMService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoContatoCRMService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoContatoCRMList(mockTipoContatoCRMService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoContatoCRM, id: 1, nome: 'Tipo Contato C R M Filtrado' }];
    const filtro = { nome: 'Tipo Contato C R M' };
    mockTipoContatoCRMService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoContatoCRMList(mockTipoContatoCRMService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoContatoCRMService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoContatoCRM', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoContatoCRM());

    const validData = { ...initialTipoContatoCRM, nome: 'Tipo Contato C R M Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTipoContatoCRM());

    const invalidData = { ...initialTipoContatoCRM, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoContatoCRM());

    const invalidData = { 
      ...initialTipoContatoCRM, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoContatoCRM());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoContatoCRM, id: 1, nome: 'Tipo Contato C R M Teste' }];
    mockTipoContatoCRMService.getAll.mockResolvedValue(mockData);
    mockTipoContatoCRMService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoContatoCRMList(mockTipoContatoCRMService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoContatoCRM()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Contato C R M Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Contato C R M Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Contato C R M 1' },
      { id: 2, nome: 'Tipo Contato C R M 2' }
    ];
    mockTipoContatoCRMService.getList.mockResolvedValue(mockOptions as ITipoContatoCRM[]);


    const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Contato C R M 1' },
        { id: 2, nome: 'Tipo Contato C R M 2' }
      ]);
    });

    expect(mockTipoContatoCRMService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Contato C R M ABC' },
      { id: 2, nome: 'Tipo Contato C R M XYZ' }
    ];
    mockTipoContatoCRMService.getList.mockResolvedValue(mockOptions as ITipoContatoCRM[]);   


 const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Contato C R M ABC' },
        { id: 2, nome: 'Tipo Contato C R M XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo Contato C R M ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Contato C R M ABC' },
      { id: 2, nome: 'Tipo Contato C R M XYZ' }
    ];
    mockTipoContatoCRMService.getList.mockResolvedValue(mockOptions as ITipoContatoCRM[]);
  


    const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Contato C R M ABC' },
        { id: 2, nome: 'Tipo Contato C R M XYZ' }
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
          {id: 1, nome: 'Tipo Contato C R M ABC' },
          {id: 2, nome: 'Tipo Contato C R M XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService)
    );

    const newValue = { id: 1, nome: 'Tipo Contato C R M Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Tipo Contato C R M Inicial' };
    
    const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoContatoCRMComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Tipo Contato C R M Inicial' };
    
    const { result } = renderHook(() => 
      useTipoContatoCRMComboBox(mockTipoContatoCRMService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






