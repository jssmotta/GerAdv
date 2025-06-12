// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useJusticaForm, useJusticaList, useValidationsJustica } from '../GerAdv_TS/Justica/Hooks/hookJustica';
import { IJustica } from '../GerAdv_TS/Justica/Interfaces/interface.Justica';
import { IJusticaService } from '../GerAdv_TS/Justica/Services/Justica.service';
import { JusticaTestEmpty } from '../GerAdv_TS/Models/Justica';
import { useJusticaComboBox } from '../GerAdv_TS/Justica/Hooks/hookJustica';

// Mock do serviço
const mockJusticaService: jest.Mocked<IJusticaService> = {
  fetchJusticaById: jest.fn(),
  saveJustica: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteJustica: jest.fn(),
  validateJustica: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialJustica: IJustica = { ...JusticaTestEmpty() };

describe('useJusticaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useJusticaForm(initialJustica, mockJusticaService)
    );

    expect(result.current.data).toEqual(initialJustica);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useJusticaForm(initialJustica, mockJusticaService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Justica',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Justica');
  });

   test('deve carregar Justica por ID', async () => {
    const mockJustica = { ...initialJustica, id: 1, nome: 'Justica Teste' };
    mockJusticaService.fetchJusticaById.mockResolvedValue(mockJustica);

    const { result } = renderHook(() => 
      useJusticaForm(initialJustica, mockJusticaService)
    );

    await act(async () => {
      await result.current.loadJustica(1);
    });

    expect(mockJusticaService.fetchJusticaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockJustica);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Justica', async () => {
    const errorMessage = 'Erro ao carregar Justica';
    mockJusticaService.fetchJusticaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useJusticaForm(initialJustica, mockJusticaService)
    );

    await act(async () => {
      await result.current.loadJustica(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useJusticaForm(initialJustica, mockJusticaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialJustica, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialJustica);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useJusticaForm(initialJustica, mockJusticaService)
    );

    await act(async () => {
      await result.current.loadJustica(0);
    });

    expect(mockJusticaService.fetchJusticaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialJustica);
  });
});

describe('useJusticaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useJusticaList(mockJusticaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialJustica, id: 1, nome: 'Justica 1' },
      { ...initialJustica, id: 2, nome: 'Justica 2' }
    ];
    mockJusticaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useJusticaList(mockJusticaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockJusticaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockJusticaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useJusticaList(mockJusticaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialJustica, id: 1, nome: 'Justica Filtrado' }];
    const filtro = { nome: 'Justica' };
    mockJusticaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useJusticaList(mockJusticaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockJusticaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsJustica', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsJustica());

    const validData = { ...initialJustica, nome: 'Justica Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsJustica());

    const invalidData = { ...initialJustica, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsJustica());

    const invalidData = { 
      ...initialJustica, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsJustica());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialJustica, id: 1, nome: 'Justica Teste' }];
    mockJusticaService.getAll.mockResolvedValue(mockData);
    mockJusticaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useJusticaList(mockJusticaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useJusticaComboBox(mockJusticaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsJustica()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Justica Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Justica Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Justica 1' },
      { id: 2, nome: 'Justica 2' }
    ];
    mockJusticaService.getList.mockResolvedValue(mockOptions as IJustica[]);


    const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Justica 1' },
        { id: 2, nome: 'Justica 2' }
      ]);
    });

    expect(mockJusticaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Justica ABC' },
      { id: 2, nome: 'Justica XYZ' }
    ];
    mockJusticaService.getList.mockResolvedValue(mockOptions as IJustica[]);   


 const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Justica ABC' },
        { id: 2, nome: 'Justica XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Justica ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Justica ABC' },
      { id: 2, nome: 'Justica XYZ' }
    ];
    mockJusticaService.getList.mockResolvedValue(mockOptions as IJustica[]);
  


    const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Justica ABC' },
        { id: 2, nome: 'Justica XYZ' }
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
          {id: 1, nome: 'Justica ABC' },
          {id: 2, nome: 'Justica XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService)
    );

    const newValue = { id: 1, nome: 'Justica Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Justica Inicial' };
    
    const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useJusticaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Justica Inicial' };
    
    const { result } = renderHook(() => 
      useJusticaComboBox(mockJusticaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






