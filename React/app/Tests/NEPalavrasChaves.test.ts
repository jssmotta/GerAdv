// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useNEPalavrasChavesForm, useNEPalavrasChavesList, useValidationsNEPalavrasChaves } from '../GerAdv_TS/NEPalavrasChaves/Hooks/hookNEPalavrasChaves';
import { INEPalavrasChaves } from '../GerAdv_TS/NEPalavrasChaves/Interfaces/interface.NEPalavrasChaves';
import { INEPalavrasChavesService } from '../GerAdv_TS/NEPalavrasChaves/Services/NEPalavrasChaves.service';
import { NEPalavrasChavesTestEmpty } from '../GerAdv_TS/Models/NEPalavrasChaves';
import { useNEPalavrasChavesComboBox } from '../GerAdv_TS/NEPalavrasChaves/Hooks/hookNEPalavrasChaves';

// Mock do serviço
const mockNEPalavrasChavesService: jest.Mocked<INEPalavrasChavesService> = {
  fetchNEPalavrasChavesById: jest.fn(),
  saveNEPalavrasChaves: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteNEPalavrasChaves: jest.fn(),
  validateNEPalavrasChaves: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialNEPalavrasChaves: INEPalavrasChaves = { ...NEPalavrasChavesTestEmpty() };

describe('useNEPalavrasChavesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesForm(initialNEPalavrasChaves, mockNEPalavrasChavesService)
    );

    expect(result.current.data).toEqual(initialNEPalavrasChaves);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesForm(initialNEPalavrasChaves, mockNEPalavrasChavesService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo N E Palavras Chaves',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo N E Palavras Chaves');
  });

   test('deve carregar N E Palavras Chaves por ID', async () => {
    const mockNEPalavrasChaves = { ...initialNEPalavrasChaves, id: 1, nome: 'N E Palavras Chaves Teste' };
    mockNEPalavrasChavesService.fetchNEPalavrasChavesById.mockResolvedValue(mockNEPalavrasChaves);

    const { result } = renderHook(() => 
      useNEPalavrasChavesForm(initialNEPalavrasChaves, mockNEPalavrasChavesService)
    );

    await act(async () => {
      await result.current.loadNEPalavrasChaves(1);
    });

    expect(mockNEPalavrasChavesService.fetchNEPalavrasChavesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockNEPalavrasChaves);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar N E Palavras Chaves', async () => {
    const errorMessage = 'Erro ao carregar N E Palavras Chaves';
    mockNEPalavrasChavesService.fetchNEPalavrasChavesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useNEPalavrasChavesForm(initialNEPalavrasChaves, mockNEPalavrasChavesService)
    );

    await act(async () => {
      await result.current.loadNEPalavrasChaves(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesForm(initialNEPalavrasChaves, mockNEPalavrasChavesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialNEPalavrasChaves, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialNEPalavrasChaves);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesForm(initialNEPalavrasChaves, mockNEPalavrasChavesService)
    );

    await act(async () => {
      await result.current.loadNEPalavrasChaves(0);
    });

    expect(mockNEPalavrasChavesService.fetchNEPalavrasChavesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialNEPalavrasChaves);
  });
});

describe('useNEPalavrasChavesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesList(mockNEPalavrasChavesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialNEPalavrasChaves, id: 1, nome: 'N E Palavras Chaves 1' },
      { ...initialNEPalavrasChaves, id: 2, nome: 'N E Palavras Chaves 2' }
    ];
    mockNEPalavrasChavesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useNEPalavrasChavesList(mockNEPalavrasChavesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockNEPalavrasChavesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockNEPalavrasChavesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useNEPalavrasChavesList(mockNEPalavrasChavesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialNEPalavrasChaves, id: 1, nome: 'N E Palavras Chaves Filtrado' }];
    const filtro = { nome: 'N E Palavras Chaves' };
    mockNEPalavrasChavesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useNEPalavrasChavesList(mockNEPalavrasChavesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockNEPalavrasChavesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsNEPalavrasChaves', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsNEPalavrasChaves());

    const validData = { ...initialNEPalavrasChaves, nome: 'N E Palavras Chaves Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsNEPalavrasChaves());

    const invalidData = { ...initialNEPalavrasChaves, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsNEPalavrasChaves());

    const invalidData = { 
      ...initialNEPalavrasChaves, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsNEPalavrasChaves());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialNEPalavrasChaves, id: 1, nome: 'N E Palavras Chaves Teste' }];
    mockNEPalavrasChavesService.getAll.mockResolvedValue(mockData);
    mockNEPalavrasChavesService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useNEPalavrasChavesList(mockNEPalavrasChavesService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsNEPalavrasChaves()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'N E Palavras Chaves Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'N E Palavras Chaves Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'N E Palavras Chaves 1' },
      { id: 2, nome: 'N E Palavras Chaves 2' }
    ];
    mockNEPalavrasChavesService.getList.mockResolvedValue(mockOptions as INEPalavrasChaves[]);


    const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'N E Palavras Chaves 1' },
        { id: 2, nome: 'N E Palavras Chaves 2' }
      ]);
    });

    expect(mockNEPalavrasChavesService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'N E Palavras Chaves ABC' },
      { id: 2, nome: 'N E Palavras Chaves XYZ' }
    ];
    mockNEPalavrasChavesService.getList.mockResolvedValue(mockOptions as INEPalavrasChaves[]);   


 const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'N E Palavras Chaves ABC' },
        { id: 2, nome: 'N E Palavras Chaves XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'N E Palavras Chaves ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'N E Palavras Chaves ABC' },
      { id: 2, nome: 'N E Palavras Chaves XYZ' }
    ];
    mockNEPalavrasChavesService.getList.mockResolvedValue(mockOptions as INEPalavrasChaves[]);
  


    const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'N E Palavras Chaves ABC' },
        { id: 2, nome: 'N E Palavras Chaves XYZ' }
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
          {id: 1, nome: 'N E Palavras Chaves ABC' },
          {id: 2, nome: 'N E Palavras Chaves XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService)
    );

    const newValue = { id: 1, nome: 'N E Palavras Chaves Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'N E Palavras Chaves Inicial' };
    
    const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useNEPalavrasChavesComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'N E Palavras Chaves Inicial' };
    
    const { result } = renderHook(() => 
      useNEPalavrasChavesComboBox(mockNEPalavrasChavesService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






