// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useInstanciaForm, useInstanciaList, useValidationsInstancia } from '../GerAdv_TS/Instancia/Hooks/hookInstancia';
import { IInstancia } from '../GerAdv_TS/Instancia/Interfaces/interface.Instancia';
import { IInstanciaService } from '../GerAdv_TS/Instancia/Services/Instancia.service';
import { InstanciaTestEmpty } from '../GerAdv_TS/Models/Instancia';
import { useInstanciaComboBox } from '../GerAdv_TS/Instancia/Hooks/hookInstancia';

// Mock do serviço
const mockInstanciaService: jest.Mocked<IInstanciaService> = {
  fetchInstanciaById: jest.fn(),
  saveInstancia: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteInstancia: jest.fn(),
  validateInstancia: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialInstancia: IInstancia = { ...InstanciaTestEmpty() };

describe('useInstanciaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    expect(result.current.data).toEqual(initialInstancia);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    const mockEvent = {
      target: {
        name: 'nroprocesso',
        value: 'Novo Instancia',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nroprocesso).toBe('Novo Instancia');
  });

   test('deve carregar Instancia por ID', async () => {
    const mockInstancia = { ...initialInstancia, id: 1, nroprocesso: 'Instancia Teste' };
    mockInstanciaService.fetchInstanciaById.mockResolvedValue(mockInstancia);

    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    await act(async () => {
      await result.current.loadInstancia(1);
    });

    expect(mockInstanciaService.fetchInstanciaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockInstancia);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Instancia', async () => {
    const errorMessage = 'Erro ao carregar Instancia';
    mockInstanciaService.fetchInstanciaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    await act(async () => {
      await result.current.loadInstancia(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialInstancia, nroprocesso: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialInstancia);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    await act(async () => {
      await result.current.loadInstancia(0);
    });

    expect(mockInstanciaService.fetchInstanciaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialInstancia);
  });
});

describe('useInstanciaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useInstanciaList(mockInstanciaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialInstancia, id: 1, nroprocesso: 'Instancia 1' },
      { ...initialInstancia, id: 2, nroprocesso: 'Instancia 2' }
    ];
    mockInstanciaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useInstanciaList(mockInstanciaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockInstanciaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockInstanciaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useInstanciaList(mockInstanciaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialInstancia, id: 1, nroprocesso: 'Instancia Filtrado' }];
    const filtro = { nroprocesso: 'Instancia' };
    mockInstanciaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useInstanciaList(mockInstanciaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockInstanciaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsInstancia', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsInstancia());

    const validData = { ...initialInstancia, nroprocesso: 'Instancia Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nroprocesso vazio', () => {
    const { result } = renderHook(() => useValidationsInstancia());

    const invalidData = { ...initialInstancia, nroprocesso: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo NroProcesso não pode ficar vazio.');
  });

  
  test('deve invalidar nroprocesso muito longo', () => {
    const { result } = renderHook(() => useValidationsInstancia());

    const invalidData = { 
      ...initialInstancia, 
      nroprocesso: 'a'.repeat(25+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo NroProcesso não pode ter mais de 25 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsInstancia());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialInstancia, id: 1, nroprocesso: 'Instancia Teste' }];
    mockInstanciaService.getAll.mockResolvedValue(mockData);
    mockInstanciaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useInstanciaList(mockInstanciaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsInstancia()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Instancia Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Instancia Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useInstanciaForm(initialInstancia, mockInstanciaService)
    );

    const mockEvent = {
      target: {
        name: 'liminarpendente',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.liminarpendente).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nroprocesso: 'Instancia 1' },
      { id: 2, nroprocesso: 'Instancia 2' }
    ];
    mockInstanciaService.getList.mockResolvedValue(mockOptions as IInstancia[]);


    const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Instancia 1' },
        { id: 2, nome: 'Instancia 2' }
      ]);
    });

    expect(mockInstanciaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nroprocesso: 'Instancia ABC' },
      { id: 2, nroprocesso: 'Instancia XYZ' }
    ];
    mockInstanciaService.getList.mockResolvedValue(mockOptions as IInstancia[]);   


 const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Instancia ABC' },
        { id: 2, nome: 'Instancia XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Instancia ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nroprocesso: 'Instancia ABC' },
      { id: 2, nroprocesso: 'Instancia XYZ' }
    ];
    mockInstanciaService.getList.mockResolvedValue(mockOptions as IInstancia[]);
  


    const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Instancia ABC' },
        { id: 2, nome: 'Instancia XYZ' }
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
          {id: 1, nome: 'Instancia ABC' },
          {id: 2, nome: 'Instancia XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService)
    );

    const newValue = { id: 1, nroprocesso: 'Instancia Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nroprocesso: 'Instancia Inicial' };
    
    const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useInstanciaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nroprocesso: 'Instancia Inicial' };
    
    const { result } = renderHook(() => 
      useInstanciaComboBox(mockInstanciaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






