// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useTipoValorProcessoForm, useTipoValorProcessoList, useValidationsTipoValorProcesso } from '../GerAdv_TS/TipoValorProcesso/Hooks/hookTipoValorProcesso';
import { ITipoValorProcesso } from '../GerAdv_TS/TipoValorProcesso/Interfaces/interface.TipoValorProcesso';
import { ITipoValorProcessoService } from '../GerAdv_TS/TipoValorProcesso/Services/TipoValorProcesso.service';
import { TipoValorProcessoTestEmpty } from '../GerAdv_TS/Models/TipoValorProcesso';
import { useTipoValorProcessoComboBox } from '../GerAdv_TS/TipoValorProcesso/Hooks/hookTipoValorProcesso';

// Mock do serviço
const mockTipoValorProcessoService: jest.Mocked<ITipoValorProcessoService> = {
  fetchTipoValorProcessoById: jest.fn(),
  saveTipoValorProcesso: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteTipoValorProcesso: jest.fn(),
  validateTipoValorProcesso: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialTipoValorProcesso: ITipoValorProcesso = { ...TipoValorProcessoTestEmpty() };

describe('useTipoValorProcessoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoForm(initialTipoValorProcesso, mockTipoValorProcessoService)
    );

    expect(result.current.data).toEqual(initialTipoValorProcesso);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoForm(initialTipoValorProcesso, mockTipoValorProcessoService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo Tipo Valor Processo',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo Tipo Valor Processo');
  });

   test('deve carregar Tipo Valor Processo por ID', async () => {
    const mockTipoValorProcesso = { ...initialTipoValorProcesso, id: 1, descricao: 'Tipo Valor Processo Teste' };
    mockTipoValorProcessoService.fetchTipoValorProcessoById.mockResolvedValue(mockTipoValorProcesso);

    const { result } = renderHook(() => 
      useTipoValorProcessoForm(initialTipoValorProcesso, mockTipoValorProcessoService)
    );

    await act(async () => {
      await result.current.loadTipoValorProcesso(1);
    });

    expect(mockTipoValorProcessoService.fetchTipoValorProcessoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockTipoValorProcesso);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Tipo Valor Processo', async () => {
    const errorMessage = 'Erro ao carregar Tipo Valor Processo';
    mockTipoValorProcessoService.fetchTipoValorProcessoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoValorProcessoForm(initialTipoValorProcesso, mockTipoValorProcessoService)
    );

    await act(async () => {
      await result.current.loadTipoValorProcesso(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoForm(initialTipoValorProcesso, mockTipoValorProcessoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialTipoValorProcesso, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialTipoValorProcesso);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoForm(initialTipoValorProcesso, mockTipoValorProcessoService)
    );

    await act(async () => {
      await result.current.loadTipoValorProcesso(0);
    });

    expect(mockTipoValorProcessoService.fetchTipoValorProcessoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialTipoValorProcesso);
  });
});

describe('useTipoValorProcessoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoList(mockTipoValorProcessoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialTipoValorProcesso, id: 1, descricao: 'Tipo Valor Processo 1' },
      { ...initialTipoValorProcesso, id: 2, descricao: 'Tipo Valor Processo 2' }
    ];
    mockTipoValorProcessoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoValorProcessoList(mockTipoValorProcessoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockTipoValorProcessoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockTipoValorProcessoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useTipoValorProcessoList(mockTipoValorProcessoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialTipoValorProcesso, id: 1, descricao: 'Tipo Valor Processo Filtrado' }];
    const filtro = { descricao: 'Tipo Valor Processo' };
    mockTipoValorProcessoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useTipoValorProcessoList(mockTipoValorProcessoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockTipoValorProcessoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsTipoValorProcesso', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsTipoValorProcesso());

    const validData = { ...initialTipoValorProcesso, descricao: 'Tipo Valor Processo Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsTipoValorProcesso());

    const invalidData = { ...initialTipoValorProcesso, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsTipoValorProcesso());

    const invalidData = { 
      ...initialTipoValorProcesso, 
      descricao: 'a'.repeat(100+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 100 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsTipoValorProcesso());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialTipoValorProcesso, id: 1, descricao: 'Tipo Valor Processo Teste' }];
    mockTipoValorProcessoService.getAll.mockResolvedValue(mockData);
    mockTipoValorProcessoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useTipoValorProcessoList(mockTipoValorProcessoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsTipoValorProcesso()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Valor Processo Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Tipo Valor Processo Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
}); 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Tipo Valor Processo 1' },
      { id: 2, descricao: 'Tipo Valor Processo 2' }
    ];
    mockTipoValorProcessoService.getList.mockResolvedValue(mockOptions as ITipoValorProcesso[]);


    const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Valor Processo 1' },
        { id: 2, nome: 'Tipo Valor Processo 2' }
      ]);
    });


    expect(mockTipoValorProcessoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Tipo Valor Processo ABC' },
      { id: 2, descricao: 'Tipo Valor Processo XYZ' }
    ];
    mockTipoValorProcessoService.getList.mockResolvedValue(mockOptions as ITipoValorProcesso[]);   


 const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Valor Processo ABC' },
        { id: 2, nome: 'Tipo Valor Processo XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Tipo Valor Processo ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Tipo Valor Processo ABC' },
      { id: 2, descricao: 'Tipo Valor Processo XYZ' }
    ];
    mockTipoValorProcessoService.getList.mockResolvedValue(mockOptions as ITipoValorProcesso[]);
  


    const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Tipo Valor Processo ABC' },
        { id: 2, nome: 'Tipo Valor Processo XYZ' }
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
          {id: 1, nome: 'Tipo Valor Processo ABC' },
          {id: 2, nome: 'Tipo Valor Processo XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService)
    );

    const newValue = { id: 1, descricao: 'Tipo Valor Processo Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'Tipo Valor Processo Inicial' };
    
    const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useTipoValorProcessoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'Tipo Valor Processo Inicial' };
    
    const { result } = renderHook(() => 
      useTipoValorProcessoComboBox(mockTipoValorProcessoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






