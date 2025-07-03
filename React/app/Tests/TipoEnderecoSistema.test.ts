// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoEnderecoSistemaForm, useTipoEnderecoSistemaList, useValidationsTipoEnderecoSistema } from '../GerAdv_TS/TipoEnderecoSistema/Hooks/hookTipoEnderecoSistema';
import { ITipoEnderecoSistema } from '../GerAdv_TS/TipoEnderecoSistema/Interfaces/interface.TipoEnderecoSistema';
import { ITipoEnderecoSistemaService } from '../GerAdv_TS/TipoEnderecoSistema/Services/TipoEnderecoSistema.service';
import { TipoEnderecoSistemaTestEmpty } from '../GerAdv_TS/Models/TipoEnderecoSistema';
import { useTipoEnderecoSistemaComboBox } from '../GerAdv_TS/TipoEnderecoSistema/Hooks/hookTipoEnderecoSistema';

// Mock do serviço
const mockTipoEnderecoSistemaService: jest.Mocked<ITipoEnderecoSistemaService> = {
  fetchTipoEnderecoSistemaById: jest.fn(),
  saveTipoEnderecoSistema: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoEnderecoSistema: jest.fn(),
  validateTipoEnderecoSistema: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoEnderecoSistema: ITipoEnderecoSistema = { ...TipoEnderecoSistemaTestEmpty() };

describe('useTipoEnderecoSistemaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaForm(initialTipoEnderecoSistema, mockTipoEnderecoSistemaService)
    );

    expect(result.current.data).toEqual(initialTipoEnderecoSistema);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaForm(initialTipoEnderecoSistema, mockTipoEnderecoSistemaService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Tipo Endereco Sistema',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Tipo Endereco Sistema');
  });

   test('deve carregar Tipo Endereco Sistema por ID', async () => {
    const mockTipoEnderecoSistema = { ...initialTipoEnderecoSistema, id: 1, nome: 'Tipo Endereco Sistema Teste' };
    mockTipoEnderecoSistemaService.fetchTipoEnderecoSistemaById.mockResolvedValue(mockTipoEnderecoSistema);

    const { result } = renderHook(() => 
      useTipoEnderecoSistemaForm(initialTipoEnderecoSistema, mockTipoEnderecoSistemaService)
    );

    await act(async () => {
      await result.current.loadTipoEnderecoSistema(1);
    });

    expect(mockTipoEnderecoSistemaService.fetchTipoEnderecoSistemaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoEnderecoSistema);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo Endereco Sistema', async () => {
    const errorMessage = 'Erro ao carregar Tipo Endereco Sistema';
    mockTipoEnderecoSistemaService.fetchTipoEnderecoSistemaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoEnderecoSistemaForm(initialTipoEnderecoSistema, mockTipoEnderecoSistemaService)
    );

    await act(async () => {
      await result.current.loadTipoEnderecoSistema(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaForm(initialTipoEnderecoSistema, mockTipoEnderecoSistemaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoEnderecoSistema, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoEnderecoSistema);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaForm(initialTipoEnderecoSistema, mockTipoEnderecoSistemaService)
    );

    await act(async () => {
      await result.current.loadTipoEnderecoSistema(0);
    });

    expect(mockTipoEnderecoSistemaService.fetchTipoEnderecoSistemaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoEnderecoSistema);
  });
});

describe('useTipoEnderecoSistemaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaList(mockTipoEnderecoSistemaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoEnderecoSistema, id: 1, nome: 'Tipo Endereco Sistema 1' },
      { ...initialTipoEnderecoSistema, id: 2, nome: 'Tipo Endereco Sistema 2' }
    ];
    mockTipoEnderecoSistemaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoEnderecoSistemaList(mockTipoEnderecoSistemaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoEnderecoSistemaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoEnderecoSistemaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoEnderecoSistemaList(mockTipoEnderecoSistemaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoEnderecoSistema, id: 1, nome: 'Tipo Endereco Sistema Filtrado' }];
    const filtro = { nome: 'Tipo Endereco Sistema' };
    mockTipoEnderecoSistemaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoEnderecoSistemaList(mockTipoEnderecoSistemaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoEnderecoSistemaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoEnderecoSistema', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoEnderecoSistema());

    const validData = { ...initialTipoEnderecoSistema, nome: 'Tipo Endereco Sistema Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTipoEnderecoSistema());

    const invalidData = { ...initialTipoEnderecoSistema, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoEnderecoSistema());

    const invalidData = { 
      ...initialTipoEnderecoSistema, 
      nome: 'a'.repeat(150+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 150 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoEnderecoSistema());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoEnderecoSistema, id: 1, nome: 'Tipo Endereco Sistema Teste' }];
    mockTipoEnderecoSistemaService.getAll.mockResolvedValue(mockData);
    mockTipoEnderecoSistemaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoEnderecoSistemaList(mockTipoEnderecoSistemaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoEnderecoSistema()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Endereco Sistema Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Endereco Sistema Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Endereco Sistema 1' },
      { id: 2, nome: 'Tipo Endereco Sistema 2' }
    ];
    mockTipoEnderecoSistemaService.getList.mockResolvedValue(mockOptions as ITipoEnderecoSistema[]);


    const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Endereco Sistema 1' },
        { id: 2, nome: 'Tipo Endereco Sistema 2' }
      ]);
    });


    expect(mockTipoEnderecoSistemaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Endereco Sistema ABC' },
      { id: 2, nome: 'Tipo Endereco Sistema XYZ' }
    ];
    mockTipoEnderecoSistemaService.getList.mockResolvedValue(mockOptions as ITipoEnderecoSistema[]);   


 const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Endereco Sistema ABC' },
        { id: 2, nome: 'Tipo Endereco Sistema XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo Endereco Sistema ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Endereco Sistema ABC' },
      { id: 2, nome: 'Tipo Endereco Sistema XYZ' }
    ];
    mockTipoEnderecoSistemaService.getList.mockResolvedValue(mockOptions as ITipoEnderecoSistema[]);
  


    const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Endereco Sistema ABC' },
        { id: 2, nome: 'Tipo Endereco Sistema XYZ' }
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
          {id: 1, nome: 'Tipo Endereco Sistema ABC' },
          {id: 2, nome: 'Tipo Endereco Sistema XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService)
    );

    const newValue = { id: 1, nome: 'Tipo Endereco Sistema Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Tipo Endereco Sistema Inicial' };
    
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoEnderecoSistemaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Tipo Endereco Sistema Inicial' };
    
    const { result } = renderHook(() => 
      useTipoEnderecoSistemaComboBox(mockTipoEnderecoSistemaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






