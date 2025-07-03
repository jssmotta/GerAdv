// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useAdvogadosForm, useAdvogadosList, useValidationsAdvogados } from '../GerAdv_TS/Advogados/Hooks/hookAdvogados';
import { IAdvogados } from '../GerAdv_TS/Advogados/Interfaces/interface.Advogados';
import { IAdvogadosService } from '../GerAdv_TS/Advogados/Services/Advogados.service';
import { AdvogadosTestEmpty } from '../GerAdv_TS/Models/Advogados';
import { useAdvogadosComboBox } from '../GerAdv_TS/Advogados/Hooks/hookAdvogados';

// Mock do serviço
const mockAdvogadosService: jest.Mocked<IAdvogadosService> = {
  fetchAdvogadosById: jest.fn(),
  saveAdvogados: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteAdvogados: jest.fn(),
  validateAdvogados: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialAdvogados: IAdvogados = { ...AdvogadosTestEmpty() };

describe('useAdvogadosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
    );

    expect(result.current.data).toEqual(initialAdvogados);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Advogados',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Advogados');
  });

   test('deve carregar Advogados por ID', async () => {
    const mockAdvogados = { ...initialAdvogados, id: 1, nome: 'Advogados Teste' };
    mockAdvogadosService.fetchAdvogadosById.mockResolvedValue(mockAdvogados);

    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
    );

    await act(async () => {
      await result.current.loadAdvogados(1);
    });

    expect(mockAdvogadosService.fetchAdvogadosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockAdvogados);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Advogados', async () => {
    const errorMessage = 'Erro ao carregar Advogados';
    mockAdvogadosService.fetchAdvogadosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
    );

    await act(async () => {
      await result.current.loadAdvogados(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialAdvogados, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialAdvogados);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
    );

    await act(async () => {
      await result.current.loadAdvogados(0);
    });

    expect(mockAdvogadosService.fetchAdvogadosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialAdvogados);
  });
});

describe('useAdvogadosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAdvogadosList(mockAdvogadosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialAdvogados, id: 1, nome: 'Advogados 1' },
      { ...initialAdvogados, id: 2, nome: 'Advogados 2' }
    ];
    mockAdvogadosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAdvogadosList(mockAdvogadosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockAdvogadosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockAdvogadosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useAdvogadosList(mockAdvogadosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialAdvogados, id: 1, nome: 'Advogados Filtrado' }];
    const filtro = { nome: 'Advogados' };
    mockAdvogadosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useAdvogadosList(mockAdvogadosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockAdvogadosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsAdvogados', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsAdvogados());

    const validData = { ...initialAdvogados, nome: 'Advogados Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsAdvogados());

    const invalidData = { ...initialAdvogados, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsAdvogados());

    const invalidData = { 
      ...initialAdvogados, 
      nome: 'a'.repeat(50+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 50 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsAdvogados());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialAdvogados, id: 1, nome: 'Advogados Teste' }];
    mockAdvogadosService.getAll.mockResolvedValue(mockData);
    mockAdvogadosService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useAdvogadosList(mockAdvogadosService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsAdvogados()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Advogados Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Advogados Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useAdvogadosForm(initialAdvogados, mockAdvogadosService)
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
      { id: 1, nome: 'Advogados 1' },
      { id: 2, nome: 'Advogados 2' }
    ];
    mockAdvogadosService.getList.mockResolvedValue(mockOptions as IAdvogados[]);


    const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Advogados 1' },
        { id: 2, nome: 'Advogados 2' }
      ]);
    });


    expect(mockAdvogadosService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Advogados ABC' },
      { id: 2, nome: 'Advogados XYZ' }
    ];
    mockAdvogadosService.getList.mockResolvedValue(mockOptions as IAdvogados[]);   


 const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService)
    );
    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Advogados ABC' },
        { id: 2, nome: 'Advogados XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Advogados ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Advogados ABC' },
      { id: 2, nome: 'Advogados XYZ' }
    ];
    mockAdvogadosService.getList.mockResolvedValue(mockOptions as IAdvogados[]);
  


    const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService)
    );
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Advogados ABC' },
        { id: 2, nome: 'Advogados XYZ' }
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
          {id: 1, nome: 'Advogados ABC' },
          {id: 2, nome: 'Advogados XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService)
    );

    const newValue = { id: 1, nome: 'Advogados Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Advogados Inicial' };
    
    const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useAdvogadosComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Advogados Inicial' };
    
    const { result } = renderHook(() => 
      useAdvogadosComboBox(mockAdvogadosService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






