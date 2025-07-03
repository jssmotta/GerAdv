// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoEMailForm, useTipoEMailList, useValidationsTipoEMail } from '../GerAdv_TS/TipoEMail/Hooks/hookTipoEMail';
import { ITipoEMail } from '../GerAdv_TS/TipoEMail/Interfaces/interface.TipoEMail';
import { ITipoEMailService } from '../GerAdv_TS/TipoEMail/Services/TipoEMail.service';
import { TipoEMailTestEmpty } from '../GerAdv_TS/Models/TipoEMail';
import { useTipoEMailComboBox } from '../GerAdv_TS/TipoEMail/Hooks/hookTipoEMail';

// Mock do serviço
const mockTipoEMailService: jest.Mocked<ITipoEMailService> = {
  fetchTipoEMailById: jest.fn(),
  saveTipoEMail: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoEMail: jest.fn(),
  validateTipoEMail: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoEMail: ITipoEMail = { ...TipoEMailTestEmpty() };

describe('useTipoEMailForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoEMailForm(initialTipoEMail, mockTipoEMailService)
    );

    expect(result.current.data).toEqual(initialTipoEMail);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoEMailForm(initialTipoEMail, mockTipoEMailService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Tipo E Mail',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Tipo E Mail');
  });

   test('deve carregar Tipo E Mail por ID', async () => {
    const mockTipoEMail = { ...initialTipoEMail, id: 1, nome: 'Tipo E Mail Teste' };
    mockTipoEMailService.fetchTipoEMailById.mockResolvedValue(mockTipoEMail);

    const { result } = renderHook(() => 
      useTipoEMailForm(initialTipoEMail, mockTipoEMailService)
    );

    await act(async () => {
      await result.current.loadTipoEMail(1);
    });

    expect(mockTipoEMailService.fetchTipoEMailById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoEMail);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo E Mail', async () => {
    const errorMessage = 'Erro ao carregar Tipo E Mail';
    mockTipoEMailService.fetchTipoEMailById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoEMailForm(initialTipoEMail, mockTipoEMailService)
    );

    await act(async () => {
      await result.current.loadTipoEMail(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoEMailForm(initialTipoEMail, mockTipoEMailService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoEMail, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoEMail);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoEMailForm(initialTipoEMail, mockTipoEMailService)
    );

    await act(async () => {
      await result.current.loadTipoEMail(0);
    });

    expect(mockTipoEMailService.fetchTipoEMailById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoEMail);
  });
});

describe('useTipoEMailList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoEMailList(mockTipoEMailService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoEMail, id: 1, nome: 'Tipo E Mail 1' },
      { ...initialTipoEMail, id: 2, nome: 'Tipo E Mail 2' }
    ];
    mockTipoEMailService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoEMailList(mockTipoEMailService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoEMailService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoEMailService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoEMailList(mockTipoEMailService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoEMail, id: 1, nome: 'Tipo E Mail Filtrado' }];
    const filtro = { nome: 'Tipo E Mail' };
    mockTipoEMailService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoEMailList(mockTipoEMailService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoEMailService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoEMail', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoEMail());

    const validData = { ...initialTipoEMail, nome: 'Tipo E Mail Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTipoEMail());

    const invalidData = { ...initialTipoEMail, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoEMail());

    const invalidData = { 
      ...initialTipoEMail, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoEMail());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoEMail, id: 1, nome: 'Tipo E Mail Teste' }];
    mockTipoEMailService.getAll.mockResolvedValue(mockData);
    mockTipoEMailService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoEMailList(mockTipoEMailService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoEMail()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo E Mail Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo E Mail Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo E Mail 1' },
      { id: 2, nome: 'Tipo E Mail 2' }
    ];
    mockTipoEMailService.getList.mockResolvedValue(mockOptions as ITipoEMail[]);


    const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo E Mail 1' },
        { id: 2, nome: 'Tipo E Mail 2' }
      ]);
    });


    expect(mockTipoEMailService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo E Mail ABC' },
      { id: 2, nome: 'Tipo E Mail XYZ' }
    ];
    mockTipoEMailService.getList.mockResolvedValue(mockOptions as ITipoEMail[]);   


 const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo E Mail ABC' },
        { id: 2, nome: 'Tipo E Mail XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo E Mail ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo E Mail ABC' },
      { id: 2, nome: 'Tipo E Mail XYZ' }
    ];
    mockTipoEMailService.getList.mockResolvedValue(mockOptions as ITipoEMail[]);
  


    const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo E Mail ABC' },
        { id: 2, nome: 'Tipo E Mail XYZ' }
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
          {id: 1, nome: 'Tipo E Mail ABC' },
          {id: 2, nome: 'Tipo E Mail XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService)
    );

    const newValue = { id: 1, nome: 'Tipo E Mail Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Tipo E Mail Inicial' };
    
    const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoEMailComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Tipo E Mail Inicial' };
    
    const { result } = renderHook(() => 
      useTipoEMailComboBox(mockTipoEMailService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






