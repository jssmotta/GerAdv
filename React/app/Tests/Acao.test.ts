// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAcaoForm, useAcaoList, useValidationsAcao } from '../GerAdv_TS/Acao/Hooks/hookAcao';
import { IAcao } from '../GerAdv_TS/Acao/Interfaces/interface.Acao';
import { IAcaoService } from '../GerAdv_TS/Acao/Services/Acao.service';
import { AcaoTestEmpty } from '../GerAdv_TS/Models/Acao';
import { useAcaoComboBox } from '../GerAdv_TS/Acao/Hooks/hookAcao';

// Mock do serviço
const mockAcaoService: jest.Mocked<IAcaoService> = {
  fetchAcaoById: jest.fn(),
  saveAcao: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteAcao: jest.fn(),
  validateAcao: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAcao: IAcao = { ...AcaoTestEmpty() };

describe('useAcaoForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAcaoForm(initialAcao, mockAcaoService)
    );

    expect(result.current.data).toEqual(initialAcao);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAcaoForm(initialAcao, mockAcaoService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo Acao',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo Acao');
  });

   test('deve carregar Acao por ID', async () => {
    const mockAcao = { ...initialAcao, id: 1, descricao: 'Acao Teste' };
    mockAcaoService.fetchAcaoById.mockResolvedValue(mockAcao);

    const { result } = renderHook(() => 
      useAcaoForm(initialAcao, mockAcaoService)
    );

    await act(async () => {
      await result.current.loadAcao(1);
    });

    expect(mockAcaoService.fetchAcaoById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAcao);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Acao', async () => {
    const errorMessage = 'Erro ao carregar Acao';
    mockAcaoService.fetchAcaoById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAcaoForm(initialAcao, mockAcaoService)
    );

    await act(async () => {
      await result.current.loadAcao(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAcaoForm(initialAcao, mockAcaoService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAcao, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAcao);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAcaoForm(initialAcao, mockAcaoService)
    );

    await act(async () => {
      await result.current.loadAcao(0);
    });

    expect(mockAcaoService.fetchAcaoById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAcao);
  });
});

describe('useAcaoList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAcaoList(mockAcaoService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAcao, id: 1, descricao: 'Acao 1' },
      { ...initialAcao, id: 2, descricao: 'Acao 2' }
    ];
    mockAcaoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAcaoList(mockAcaoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAcaoService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAcaoService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAcaoList(mockAcaoService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAcao, id: 1, descricao: 'Acao Filtrado' }];
    const filtro = { descricao: 'Acao' };
    mockAcaoService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAcaoList(mockAcaoService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAcaoService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAcao', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAcao());

    const validData = { ...initialAcao, descricao: 'Acao Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsAcao());

    const invalidData = { ...initialAcao, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsAcao());

    const invalidData = { 
      ...initialAcao, 
      descricao: 'a'.repeat(255+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 255 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAcao());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAcao, id: 1, descricao: 'Acao Teste' }];
    mockAcaoService.getAll.mockResolvedValue(mockData);
    mockAcaoService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAcaoList(mockAcaoService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useAcaoComboBox(mockAcaoService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsAcao()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Acao Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Acao Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Acao 1' },
      { id: 2, descricao: 'Acao 2' }
    ];
    mockAcaoService.getList.mockResolvedValue(mockOptions as IAcao[]);


    const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Acao 1' },
        { id: 2, nome: 'Acao 2' }
      ]);
    });

    expect(mockAcaoService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Acao ABC' },
      { id: 2, descricao: 'Acao XYZ' }
    ];
    mockAcaoService.getList.mockResolvedValue(mockOptions as IAcao[]);   


 const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Acao ABC' },
        { id: 2, nome: 'Acao XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Acao ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Acao ABC' },
      { id: 2, descricao: 'Acao XYZ' }
    ];
    mockAcaoService.getList.mockResolvedValue(mockOptions as IAcao[]);
  


    const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Acao ABC' },
        { id: 2, nome: 'Acao XYZ' }
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
          {id: 1, nome: 'Acao ABC' },
          {id: 2, nome: 'Acao XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService)
    );

    const newValue = { id: 1, descricao: 'Acao Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'Acao Inicial' };
    
    const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useAcaoComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'Acao Inicial' };
    
    const { result } = renderHook(() => 
      useAcaoComboBox(mockAcaoService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






