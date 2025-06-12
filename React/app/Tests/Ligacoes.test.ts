// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useLigacoesForm, useLigacoesList, useValidationsLigacoes } from '../GerAdv_TS/Ligacoes/Hooks/hookLigacoes';
import { ILigacoes } from '../GerAdv_TS/Ligacoes/Interfaces/interface.Ligacoes';
import { ILigacoesService } from '../GerAdv_TS/Ligacoes/Services/Ligacoes.service';
import { LigacoesTestEmpty } from '../GerAdv_TS/Models/Ligacoes';
import { useLigacoesComboBox } from '../GerAdv_TS/Ligacoes/Hooks/hookLigacoes';

// Mock do serviço
const mockLigacoesService: jest.Mocked<ILigacoesService> = {
  fetchLigacoesById: jest.fn(),
  saveLigacoes: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteLigacoes: jest.fn(),
  validateLigacoes: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialLigacoes: ILigacoes = { ...LigacoesTestEmpty() };

describe('useLigacoesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    expect(result.current.data).toEqual(initialLigacoes);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Ligacoes',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Ligacoes');
  });

   test('deve carregar Ligacoes por ID', async () => {
    const mockLigacoes = { ...initialLigacoes, id: 1, nome: 'Ligacoes Teste' };
    mockLigacoesService.fetchLigacoesById.mockResolvedValue(mockLigacoes);

    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    await act(async () => {
      await result.current.loadLigacoes(1);
    });

    expect(mockLigacoesService.fetchLigacoesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockLigacoes);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Ligacoes', async () => {
    const errorMessage = 'Erro ao carregar Ligacoes';
    mockLigacoesService.fetchLigacoesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    await act(async () => {
      await result.current.loadLigacoes(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialLigacoes, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialLigacoes);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    await act(async () => {
      await result.current.loadLigacoes(0);
    });

    expect(mockLigacoesService.fetchLigacoesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialLigacoes);
  });
});

describe('useLigacoesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useLigacoesList(mockLigacoesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialLigacoes, id: 1, nome: 'Ligacoes 1' },
      { ...initialLigacoes, id: 2, nome: 'Ligacoes 2' }
    ];
    mockLigacoesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useLigacoesList(mockLigacoesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockLigacoesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockLigacoesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useLigacoesList(mockLigacoesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialLigacoes, id: 1, nome: 'Ligacoes Filtrado' }];
    const filtro = { nome: 'Ligacoes' };
    mockLigacoesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useLigacoesList(mockLigacoesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockLigacoesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsLigacoes', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsLigacoes());

    const validData = { ...initialLigacoes, nome: 'Ligacoes Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsLigacoes());

    const invalidData = { ...initialLigacoes, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsLigacoes());

    const invalidData = { 
      ...initialLigacoes, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsLigacoes());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialLigacoes, id: 1, nome: 'Ligacoes Teste' }];
    mockLigacoesService.getAll.mockResolvedValue(mockData);
    mockLigacoesService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useLigacoesList(mockLigacoesService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsLigacoes()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Ligacoes Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Ligacoes Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useLigacoesForm(initialLigacoes, mockLigacoesService)
    );

    const mockEvent = {
      target: {
        name: 'celular',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.celular).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Ligacoes 1' },
      { id: 2, nome: 'Ligacoes 2' }
    ];
    mockLigacoesService.getList.mockResolvedValue(mockOptions as ILigacoes[]);


    const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Ligacoes 1' },
        { id: 2, nome: 'Ligacoes 2' }
      ]);
    });

    expect(mockLigacoesService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Ligacoes ABC' },
      { id: 2, nome: 'Ligacoes XYZ' }
    ];
    mockLigacoesService.getList.mockResolvedValue(mockOptions as ILigacoes[]);   


 const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Ligacoes ABC' },
        { id: 2, nome: 'Ligacoes XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Ligacoes ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Ligacoes ABC' },
      { id: 2, nome: 'Ligacoes XYZ' }
    ];
    mockLigacoesService.getList.mockResolvedValue(mockOptions as ILigacoes[]);
  


    const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Ligacoes ABC' },
        { id: 2, nome: 'Ligacoes XYZ' }
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
          {id: 1, nome: 'Ligacoes ABC' },
          {id: 2, nome: 'Ligacoes XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService)
    );

    const newValue = { id: 1, nome: 'Ligacoes Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Ligacoes Inicial' };
    
    const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useLigacoesComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Ligacoes Inicial' };
    
    const { result } = renderHook(() => 
      useLigacoesComboBox(mockLigacoesService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






