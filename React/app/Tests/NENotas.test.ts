// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useNENotasForm, useNENotasList, useValidationsNENotas } from '../GerAdv_TS/NENotas/Hooks/hookNENotas';
import { INENotas } from '../GerAdv_TS/NENotas/Interfaces/interface.NENotas';
import { INENotasService } from '../GerAdv_TS/NENotas/Services/NENotas.service';
import { NENotasTestEmpty } from '../GerAdv_TS/Models/NENotas';
import { useNENotasComboBox } from '../GerAdv_TS/NENotas/Hooks/hookNENotas';

// Mock do serviço
const mockNENotasService: jest.Mocked<INENotasService> = {
  fetchNENotasById: jest.fn(),
  saveNENotas: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteNENotas: jest.fn(),
  validateNENotas: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialNENotas: INENotas = { ...NENotasTestEmpty() };

describe('useNENotasForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    expect(result.current.data).toEqual(initialNENotas);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo N E Notas',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo N E Notas');
  });

   test('deve carregar N E Notas por ID', async () => {
    const mockNENotas = { ...initialNENotas, id: 1, nome: 'N E Notas Teste' };
    mockNENotasService.fetchNENotasById.mockResolvedValue(mockNENotas);

    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    await act(async () => {
      await result.current.loadNENotas(1);
    });

    expect(mockNENotasService.fetchNENotasById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockNENotas);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar N E Notas', async () => {
    const errorMessage = 'Erro ao carregar N E Notas';
    mockNENotasService.fetchNENotasById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    await act(async () => {
      await result.current.loadNENotas(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialNENotas, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialNENotas);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    await act(async () => {
      await result.current.loadNENotas(0);
    });

    expect(mockNENotasService.fetchNENotasById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialNENotas);
  });
});

describe('useNENotasList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useNENotasList(mockNENotasService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialNENotas, id: 1, nome: 'N E Notas 1' },
      { ...initialNENotas, id: 2, nome: 'N E Notas 2' }
    ];
    mockNENotasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useNENotasList(mockNENotasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockNENotasService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockNENotasService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useNENotasList(mockNENotasService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialNENotas, id: 1, nome: 'N E Notas Filtrado' }];
    const filtro = { nome: 'N E Notas' };
    mockNENotasService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useNENotasList(mockNENotasService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockNENotasService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsNENotas', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsNENotas());

    const validData = { ...initialNENotas, nome: 'N E Notas Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsNENotas());

    const invalidData = { ...initialNENotas, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsNENotas());

    const invalidData = { 
      ...initialNENotas, 
      nome: 'a'.repeat(20+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 20 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsNENotas());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialNENotas, id: 1, nome: 'N E Notas Teste' }];
    mockNENotasService.getAll.mockResolvedValue(mockData);
    mockNENotasService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useNENotasList(mockNENotasService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useNENotasComboBox(mockNENotasService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsNENotas()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'N E Notas Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'N E Notas Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useNENotasForm(initialNENotas, mockNENotasService)
    );

    const mockEvent = {
      target: {
        name: 'movpro',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.movpro).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'N E Notas 1' },
      { id: 2, nome: 'N E Notas 2' }
    ];
    mockNENotasService.getList.mockResolvedValue(mockOptions as INENotas[]);


    const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'N E Notas 1' },
        { id: 2, nome: 'N E Notas 2' }
      ]);
    });


    expect(mockNENotasService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'N E Notas ABC' },
      { id: 2, nome: 'N E Notas XYZ' }
    ];
    mockNENotasService.getList.mockResolvedValue(mockOptions as INENotas[]);   


 const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'N E Notas ABC' },
        { id: 2, nome: 'N E Notas XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'N E Notas ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'N E Notas ABC' },
      { id: 2, nome: 'N E Notas XYZ' }
    ];
    mockNENotasService.getList.mockResolvedValue(mockOptions as INENotas[]);
  


    const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'N E Notas ABC' },
        { id: 2, nome: 'N E Notas XYZ' }
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
          {id: 1, nome: 'N E Notas ABC' },
          {id: 2, nome: 'N E Notas XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService)
    );

    const newValue = { id: 1, nome: 'N E Notas Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'N E Notas Inicial' };
    
    const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useNENotasComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'N E Notas Inicial' };
    
    const { result } = renderHook(() => 
      useNENotasComboBox(mockNENotasService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






