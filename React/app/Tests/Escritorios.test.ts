// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useEscritoriosForm, useEscritoriosList, useValidationsEscritorios } from '../GerAdv_TS/Escritorios/Hooks/hookEscritorios';
import { IEscritorios } from '../GerAdv_TS/Escritorios/Interfaces/interface.Escritorios';
import { IEscritoriosService } from '../GerAdv_TS/Escritorios/Services/Escritorios.service';
import { EscritoriosTestEmpty } from '../GerAdv_TS/Models/Escritorios';
import { useEscritoriosComboBox } from '../GerAdv_TS/Escritorios/Hooks/hookEscritorios';

// Mock do serviço
const mockEscritoriosService: jest.Mocked<IEscritoriosService> = {
  fetchEscritoriosById: jest.fn(),
  saveEscritorios: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteEscritorios: jest.fn(),
  validateEscritorios: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialEscritorios: IEscritorios = { ...EscritoriosTestEmpty() };

describe('useEscritoriosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    expect(result.current.data).toEqual(initialEscritorios);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Escritorios',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Escritorios');
  });

   test('deve carregar Escritorios por ID', async () => {
    const mockEscritorios = { ...initialEscritorios, id: 1, nome: 'Escritorios Teste' };
    mockEscritoriosService.fetchEscritoriosById.mockResolvedValue(mockEscritorios);

    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    await act(async () => {
      await result.current.loadEscritorios(1);
    });

    expect(mockEscritoriosService.fetchEscritoriosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockEscritorios);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Escritorios', async () => {
    const errorMessage = 'Erro ao carregar Escritorios';
    mockEscritoriosService.fetchEscritoriosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    await act(async () => {
      await result.current.loadEscritorios(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialEscritorios, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialEscritorios);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    await act(async () => {
      await result.current.loadEscritorios(0);
    });

    expect(mockEscritoriosService.fetchEscritoriosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialEscritorios);
  });
});

describe('useEscritoriosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useEscritoriosList(mockEscritoriosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialEscritorios, id: 1, nome: 'Escritorios 1' },
      { ...initialEscritorios, id: 2, nome: 'Escritorios 2' }
    ];
    mockEscritoriosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useEscritoriosList(mockEscritoriosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockEscritoriosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockEscritoriosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useEscritoriosList(mockEscritoriosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialEscritorios, id: 1, nome: 'Escritorios Filtrado' }];
    const filtro = { nome: 'Escritorios' };
    mockEscritoriosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useEscritoriosList(mockEscritoriosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockEscritoriosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsEscritorios', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsEscritorios());

    const validData = { ...initialEscritorios, nome: 'Escritorios Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsEscritorios());

    const invalidData = { ...initialEscritorios, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsEscritorios());

    const invalidData = { 
      ...initialEscritorios, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsEscritorios());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialEscritorios, id: 1, nome: 'Escritorios Teste' }];
    mockEscritoriosService.getAll.mockResolvedValue(mockData);
    mockEscritoriosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useEscritoriosList(mockEscritoriosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsEscritorios()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Escritorios Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Escritorios Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useEscritoriosForm(initialEscritorios, mockEscritoriosService)
    );

    const mockEvent = {
      target: {
        name: 'casa',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.casa).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Escritorios 1' },
      { id: 2, nome: 'Escritorios 2' }
    ];
    mockEscritoriosService.getList.mockResolvedValue(mockOptions as IEscritorios[]);


    const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Escritorios 1' },
        { id: 2, nome: 'Escritorios 2' }
      ]);
    });


    expect(mockEscritoriosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Escritorios ABC' },
      { id: 2, nome: 'Escritorios XYZ' }
    ];
    mockEscritoriosService.getList.mockResolvedValue(mockOptions as IEscritorios[]);   


 const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Escritorios ABC' },
        { id: 2, nome: 'Escritorios XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Escritorios ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Escritorios ABC' },
      { id: 2, nome: 'Escritorios XYZ' }
    ];
    mockEscritoriosService.getList.mockResolvedValue(mockOptions as IEscritorios[]);
  


    const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Escritorios ABC' },
        { id: 2, nome: 'Escritorios XYZ' }
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
          {id: 1, nome: 'Escritorios ABC' },
          {id: 2, nome: 'Escritorios XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService)
    );

    const newValue = { id: 1, nome: 'Escritorios Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Escritorios Inicial' };
    
    const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useEscritoriosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Escritorios Inicial' };
    
    const { result } = renderHook(() => 
      useEscritoriosComboBox(mockEscritoriosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






