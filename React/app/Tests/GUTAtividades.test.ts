// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useGUTAtividadesForm, useGUTAtividadesList, useValidationsGUTAtividades } from '../GerAdv_TS/GUTAtividades/Hooks/hookGUTAtividades';
import { IGUTAtividades } from '../GerAdv_TS/GUTAtividades/Interfaces/interface.GUTAtividades';
import { IGUTAtividadesService } from '../GerAdv_TS/GUTAtividades/Services/GUTAtividades.service';
import { GUTAtividadesTestEmpty } from '../GerAdv_TS/Models/GUTAtividades';
import { useGUTAtividadesComboBox } from '../GerAdv_TS/GUTAtividades/Hooks/hookGUTAtividades';

// Mock do serviço
const mockGUTAtividadesService: jest.Mocked<IGUTAtividadesService> = {
  fetchGUTAtividadesById: jest.fn(),
  saveGUTAtividades: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteGUTAtividades: jest.fn(),
  validateGUTAtividades: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialGUTAtividades: IGUTAtividades = { ...GUTAtividadesTestEmpty() };

describe('useGUTAtividadesForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    expect(result.current.data).toEqual(initialGUTAtividades);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo G U T Atividades',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo G U T Atividades');
  });

   test('deve carregar G U T Atividades por ID', async () => {
    const mockGUTAtividades = { ...initialGUTAtividades, id: 1, nome: 'G U T Atividades Teste' };
    mockGUTAtividadesService.fetchGUTAtividadesById.mockResolvedValue(mockGUTAtividades);

    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    await act(async () => {
      await result.current.loadGUTAtividades(1);
    });

    expect(mockGUTAtividadesService.fetchGUTAtividadesById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockGUTAtividades);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar G U T Atividades', async () => {
    const errorMessage = 'Erro ao carregar G U T Atividades';
    mockGUTAtividadesService.fetchGUTAtividadesById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    await act(async () => {
      await result.current.loadGUTAtividades(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialGUTAtividades, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialGUTAtividades);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    await act(async () => {
      await result.current.loadGUTAtividades(0);
    });

    expect(mockGUTAtividadesService.fetchGUTAtividadesById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialGUTAtividades);
  });
});

describe('useGUTAtividadesList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesList(mockGUTAtividadesService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialGUTAtividades, id: 1, nome: 'G U T Atividades 1' },
      { ...initialGUTAtividades, id: 2, nome: 'G U T Atividades 2' }
    ];
    mockGUTAtividadesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTAtividadesList(mockGUTAtividadesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockGUTAtividadesService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockGUTAtividadesService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useGUTAtividadesList(mockGUTAtividadesService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialGUTAtividades, id: 1, nome: 'G U T Atividades Filtrado' }];
    const filtro = { nome: 'G U T Atividades' };
    mockGUTAtividadesService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useGUTAtividadesList(mockGUTAtividadesService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockGUTAtividadesService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsGUTAtividades', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsGUTAtividades());

    const validData = { ...initialGUTAtividades, nome: 'G U T Atividades Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsGUTAtividades());

    const invalidData = { ...initialGUTAtividades, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsGUTAtividades());

    const invalidData = { 
      ...initialGUTAtividades, 
      nome: 'a'.repeat(255+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 255 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsGUTAtividades());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialGUTAtividades, id: 1, nome: 'G U T Atividades Teste' }];
    mockGUTAtividadesService.getAll.mockResolvedValue(mockData);
    mockGUTAtividadesService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useGUTAtividadesList(mockGUTAtividadesService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsGUTAtividades()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'G U T Atividades Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'G U T Atividades Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesForm(initialGUTAtividades, mockGUTAtividadesService)
    );

    const mockEvent = {
      target: {
        name: 'concluido',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.concluido).toBe(true);
  });


 
test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'G U T Atividades 1' },
      { id: 2, nome: 'G U T Atividades 2' }
    ];
    mockGUTAtividadesService.getList.mockResolvedValue(mockOptions as IGUTAtividades[]);


    const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'G U T Atividades 1' },
        { id: 2, nome: 'G U T Atividades 2' }
      ]);
    });


    expect(mockGUTAtividadesService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'G U T Atividades ABC' },
      { id: 2, nome: 'G U T Atividades XYZ' }
    ];
    mockGUTAtividadesService.getList.mockResolvedValue(mockOptions as IGUTAtividades[]);   


 const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'G U T Atividades ABC' },
        { id: 2, nome: 'G U T Atividades XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'G U T Atividades ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'G U T Atividades ABC' },
      { id: 2, nome: 'G U T Atividades XYZ' }
    ];
    mockGUTAtividadesService.getList.mockResolvedValue(mockOptions as IGUTAtividades[]);
  


    const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'G U T Atividades ABC' },
        { id: 2, nome: 'G U T Atividades XYZ' }
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
          {id: 1, nome: 'G U T Atividades ABC' },
          {id: 2, nome: 'G U T Atividades XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService)
    );

    const newValue = { id: 1, nome: 'G U T Atividades Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'G U T Atividades Inicial' };
    
    const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useGUTAtividadesComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'G U T Atividades Inicial' };
    
    const { result } = renderHook(() => 
      useGUTAtividadesComboBox(mockGUTAtividadesService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






