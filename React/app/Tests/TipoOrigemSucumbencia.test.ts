// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoOrigemSucumbenciaForm, useTipoOrigemSucumbenciaList, useValidationsTipoOrigemSucumbencia } from '../GerAdv_TS/TipoOrigemSucumbencia/Hooks/hookTipoOrigemSucumbencia';
import { ITipoOrigemSucumbencia } from '../GerAdv_TS/TipoOrigemSucumbencia/Interfaces/interface.TipoOrigemSucumbencia';
import { ITipoOrigemSucumbenciaService } from '../GerAdv_TS/TipoOrigemSucumbencia/Services/TipoOrigemSucumbencia.service';
import { TipoOrigemSucumbenciaTestEmpty } from '../GerAdv_TS/Models/TipoOrigemSucumbencia';
import { useTipoOrigemSucumbenciaComboBox } from '../GerAdv_TS/TipoOrigemSucumbencia/Hooks/hookTipoOrigemSucumbencia';

// Mock do serviço
const mockTipoOrigemSucumbenciaService: jest.Mocked<ITipoOrigemSucumbenciaService> = {
  fetchTipoOrigemSucumbenciaById: jest.fn(),
  saveTipoOrigemSucumbencia: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoOrigemSucumbencia: jest.fn(),
  validateTipoOrigemSucumbencia: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoOrigemSucumbencia: ITipoOrigemSucumbencia = { ...TipoOrigemSucumbenciaTestEmpty() };

describe('useTipoOrigemSucumbenciaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaForm(initialTipoOrigemSucumbencia, mockTipoOrigemSucumbenciaService)
    );

    expect(result.current.data).toEqual(initialTipoOrigemSucumbencia);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaForm(initialTipoOrigemSucumbencia, mockTipoOrigemSucumbenciaService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Tipo Origem Sucumbencia',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Tipo Origem Sucumbencia');
  });

   test('deve carregar Tipo Origem Sucumbencia por ID', async () => {
    const mockTipoOrigemSucumbencia = { ...initialTipoOrigemSucumbencia, id: 1, nome: 'Tipo Origem Sucumbencia Teste' };
    mockTipoOrigemSucumbenciaService.fetchTipoOrigemSucumbenciaById.mockResolvedValue(mockTipoOrigemSucumbencia);

    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaForm(initialTipoOrigemSucumbencia, mockTipoOrigemSucumbenciaService)
    );

    await act(async () => {
      await result.current.loadTipoOrigemSucumbencia(1);
    });

    expect(mockTipoOrigemSucumbenciaService.fetchTipoOrigemSucumbenciaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoOrigemSucumbencia);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo Origem Sucumbencia', async () => {
    const errorMessage = 'Erro ao carregar Tipo Origem Sucumbencia';
    mockTipoOrigemSucumbenciaService.fetchTipoOrigemSucumbenciaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaForm(initialTipoOrigemSucumbencia, mockTipoOrigemSucumbenciaService)
    );

    await act(async () => {
      await result.current.loadTipoOrigemSucumbencia(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaForm(initialTipoOrigemSucumbencia, mockTipoOrigemSucumbenciaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoOrigemSucumbencia, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoOrigemSucumbencia);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaForm(initialTipoOrigemSucumbencia, mockTipoOrigemSucumbenciaService)
    );

    await act(async () => {
      await result.current.loadTipoOrigemSucumbencia(0);
    });

    expect(mockTipoOrigemSucumbenciaService.fetchTipoOrigemSucumbenciaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoOrigemSucumbencia);
  });
});

describe('useTipoOrigemSucumbenciaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaList(mockTipoOrigemSucumbenciaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoOrigemSucumbencia, id: 1, nome: 'Tipo Origem Sucumbencia 1' },
      { ...initialTipoOrigemSucumbencia, id: 2, nome: 'Tipo Origem Sucumbencia 2' }
    ];
    mockTipoOrigemSucumbenciaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaList(mockTipoOrigemSucumbenciaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoOrigemSucumbenciaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoOrigemSucumbenciaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaList(mockTipoOrigemSucumbenciaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoOrigemSucumbencia, id: 1, nome: 'Tipo Origem Sucumbencia Filtrado' }];
    const filtro = { nome: 'Tipo Origem Sucumbencia' };
    mockTipoOrigemSucumbenciaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaList(mockTipoOrigemSucumbenciaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoOrigemSucumbenciaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoOrigemSucumbencia', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoOrigemSucumbencia());

    const validData = { ...initialTipoOrigemSucumbencia, nome: 'Tipo Origem Sucumbencia Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsTipoOrigemSucumbencia());

    const invalidData = { ...initialTipoOrigemSucumbencia, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoOrigemSucumbencia());

    const invalidData = { 
      ...initialTipoOrigemSucumbencia, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoOrigemSucumbencia());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoOrigemSucumbencia, id: 1, nome: 'Tipo Origem Sucumbencia Teste' }];
    mockTipoOrigemSucumbenciaService.getAll.mockResolvedValue(mockData);
    mockTipoOrigemSucumbenciaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoOrigemSucumbenciaList(mockTipoOrigemSucumbenciaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoOrigemSucumbencia()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Origem Sucumbencia Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Origem Sucumbencia Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Origem Sucumbencia 1' },
      { id: 2, nome: 'Tipo Origem Sucumbencia 2' }
    ];
    mockTipoOrigemSucumbenciaService.getList.mockResolvedValue(mockOptions as ITipoOrigemSucumbencia[]);


    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Origem Sucumbencia 1' },
        { id: 2, nome: 'Tipo Origem Sucumbencia 2' }
      ]);
    });


    expect(mockTipoOrigemSucumbenciaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Origem Sucumbencia ABC' },
      { id: 2, nome: 'Tipo Origem Sucumbencia XYZ' }
    ];
    mockTipoOrigemSucumbenciaService.getList.mockResolvedValue(mockOptions as ITipoOrigemSucumbencia[]);   


 const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Origem Sucumbencia ABC' },
        { id: 2, nome: 'Tipo Origem Sucumbencia XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo Origem Sucumbencia ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Tipo Origem Sucumbencia ABC' },
      { id: 2, nome: 'Tipo Origem Sucumbencia XYZ' }
    ];
    mockTipoOrigemSucumbenciaService.getList.mockResolvedValue(mockOptions as ITipoOrigemSucumbencia[]);
  


    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Origem Sucumbencia ABC' },
        { id: 2, nome: 'Tipo Origem Sucumbencia XYZ' }
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
          {id: 1, nome: 'Tipo Origem Sucumbencia ABC' },
          {id: 2, nome: 'Tipo Origem Sucumbencia XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService)
    );

    const newValue = { id: 1, nome: 'Tipo Origem Sucumbencia Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Tipo Origem Sucumbencia Inicial' };
    
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoOrigemSucumbenciaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Tipo Origem Sucumbencia Inicial' };
    
    const { result } = renderHook(() => 
      useTipoOrigemSucumbenciaComboBox(mockTipoOrigemSucumbenciaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






