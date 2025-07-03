// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAreaForm, useAreaList, useValidationsArea } from '../GerAdv_TS/Area/Hooks/hookArea';
import { IArea } from '../GerAdv_TS/Area/Interfaces/interface.Area';
import { IAreaService } from '../GerAdv_TS/Area/Services/Area.service';
import { AreaTestEmpty } from '../GerAdv_TS/Models/Area';
import { useAreaComboBox } from '../GerAdv_TS/Area/Hooks/hookArea';

// Mock do serviço
const mockAreaService: jest.Mocked<IAreaService> = {
  fetchAreaById: jest.fn(),
  saveArea: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteArea: jest.fn(),
  validateArea: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialArea: IArea = { ...AreaTestEmpty() };

describe('useAreaForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    expect(result.current.data).toEqual(initialArea);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    const mockEvent = {
      target: {
        name: 'descricao',
        value: 'Novo Area',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.descricao).toBe('Novo Area');
  });

   test('deve carregar Area por ID', async () => {
    const mockArea = { ...initialArea, id: 1, descricao: 'Area Teste' };
    mockAreaService.fetchAreaById.mockResolvedValue(mockArea);

    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    await act(async () => {
      await result.current.loadArea(1);
    });

    expect(mockAreaService.fetchAreaById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockArea);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Area', async () => {
    const errorMessage = 'Erro ao carregar Area';
    mockAreaService.fetchAreaById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    await act(async () => {
      await result.current.loadArea(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialArea, descricao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialArea);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    await act(async () => {
      await result.current.loadArea(0);
    });

    expect(mockAreaService.fetchAreaById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialArea);
  });
});

describe('useAreaList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAreaList(mockAreaService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialArea, id: 1, descricao: 'Area 1' },
      { ...initialArea, id: 2, descricao: 'Area 2' }
    ];
    mockAreaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAreaList(mockAreaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAreaService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAreaService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAreaList(mockAreaService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialArea, id: 1, descricao: 'Area Filtrado' }];
    const filtro = { descricao: 'Area' };
    mockAreaService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAreaList(mockAreaService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAreaService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsArea', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsArea());

    const validData = { ...initialArea, descricao: 'Area Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar descricao vazio', () => {
    const { result } = renderHook(() => useValidationsArea());

    const invalidData = { ...initialArea, descricao: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ficar vazio.');
  });

  
  test('deve invalidar descricao muito longo', () => {
    const { result } = renderHook(() => useValidationsArea());

    const invalidData = { 
      ...initialArea, 
      descricao: 'a'.repeat(40+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Descricao não pode ter mais de 40 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsArea());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialArea, id: 1, descricao: 'Area Teste' }];
    mockAreaService.getAll.mockResolvedValue(mockData);
    mockAreaService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAreaList(mockAreaService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useAreaComboBox(mockAreaService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsArea()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Area Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Area Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useAreaForm(initialArea, mockAreaService)
    );

    const mockEvent = {
      target: {
        name: 'top',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.top).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Area 1' },
      { id: 2, descricao: 'Area 2' }
    ];
    mockAreaService.getList.mockResolvedValue(mockOptions as IArea[]);


    const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Area 1' },
        { id: 2, nome: 'Area 2' }
      ]);
    });


    expect(mockAreaService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Area ABC' },
      { id: 2, descricao: 'Area XYZ' }
    ];
    mockAreaService.getList.mockResolvedValue(mockOptions as IArea[]);   


 const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Area ABC' },
        { id: 2, nome: 'Area XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Area ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, descricao: 'Area ABC' },
      { id: 2, descricao: 'Area XYZ' }
    ];
    mockAreaService.getList.mockResolvedValue(mockOptions as IArea[]);
  


    const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Area ABC' },
        { id: 2, nome: 'Area XYZ' }
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
          {id: 1, nome: 'Area ABC' },
          {id: 2, nome: 'Area XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService)
    );

    const newValue = { id: 1, descricao: 'Area Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, descricao: 'Area Inicial' };
    
    const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useAreaComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, descricao: 'Area Inicial' };
    
    const { result } = renderHook(() => 
      useAreaComboBox(mockAreaService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






