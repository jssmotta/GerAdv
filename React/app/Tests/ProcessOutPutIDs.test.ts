// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useProcessOutPutIDsForm, useProcessOutPutIDsList, useValidationsProcessOutPutIDs } from '../GerAdv_TS/ProcessOutPutIDs/Hooks/hookProcessOutPutIDs';
import { IProcessOutPutIDs } from '../GerAdv_TS/ProcessOutPutIDs/Interfaces/interface.ProcessOutPutIDs';
import { IProcessOutPutIDsService } from '../GerAdv_TS/ProcessOutPutIDs/Services/ProcessOutPutIDs.service';
import { ProcessOutPutIDsTestEmpty } from '../GerAdv_TS/Models/ProcessOutPutIDs';
import { useProcessOutPutIDsComboBox } from '../GerAdv_TS/ProcessOutPutIDs/Hooks/hookProcessOutPutIDs';

// Mock do serviço
const mockProcessOutPutIDsService: jest.Mocked<IProcessOutPutIDsService> = {
  fetchProcessOutPutIDsById: jest.fn(),
  saveProcessOutPutIDs: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteProcessOutPutIDs: jest.fn(),
  validateProcessOutPutIDs: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialProcessOutPutIDs: IProcessOutPutIDs = { ...ProcessOutPutIDsTestEmpty() };

describe('useProcessOutPutIDsForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsForm(initialProcessOutPutIDs, mockProcessOutPutIDsService)
    );

    expect(result.current.data).toEqual(initialProcessOutPutIDs);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsForm(initialProcessOutPutIDs, mockProcessOutPutIDsService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Process Out Put I Ds',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Process Out Put I Ds');
  });

   test('deve carregar Process Out Put I Ds por ID', async () => {
    const mockProcessOutPutIDs = { ...initialProcessOutPutIDs, id: 1, nome: 'Process Out Put I Ds Teste' };
    mockProcessOutPutIDsService.fetchProcessOutPutIDsById.mockResolvedValue(mockProcessOutPutIDs);

    const { result } = renderHook(() => 
      useProcessOutPutIDsForm(initialProcessOutPutIDs, mockProcessOutPutIDsService)
    );

    await act(async () => {
      await result.current.loadProcessOutPutIDs(1);
    });

    expect(mockProcessOutPutIDsService.fetchProcessOutPutIDsById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockProcessOutPutIDs);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Process Out Put I Ds', async () => {
    const errorMessage = 'Erro ao carregar Process Out Put I Ds';
    mockProcessOutPutIDsService.fetchProcessOutPutIDsById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessOutPutIDsForm(initialProcessOutPutIDs, mockProcessOutPutIDsService)
    );

    await act(async () => {
      await result.current.loadProcessOutPutIDs(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsForm(initialProcessOutPutIDs, mockProcessOutPutIDsService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialProcessOutPutIDs, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialProcessOutPutIDs);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsForm(initialProcessOutPutIDs, mockProcessOutPutIDsService)
    );

    await act(async () => {
      await result.current.loadProcessOutPutIDs(0);
    });

    expect(mockProcessOutPutIDsService.fetchProcessOutPutIDsById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialProcessOutPutIDs);
  });
});

describe('useProcessOutPutIDsList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsList(mockProcessOutPutIDsService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialProcessOutPutIDs, id: 1, nome: 'Process Out Put I Ds 1' },
      { ...initialProcessOutPutIDs, id: 2, nome: 'Process Out Put I Ds 2' }
    ];
    mockProcessOutPutIDsService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessOutPutIDsList(mockProcessOutPutIDsService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockProcessOutPutIDsService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockProcessOutPutIDsService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useProcessOutPutIDsList(mockProcessOutPutIDsService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialProcessOutPutIDs, id: 1, nome: 'Process Out Put I Ds Filtrado' }];
    const filtro = { nome: 'Process Out Put I Ds' };
    mockProcessOutPutIDsService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useProcessOutPutIDsList(mockProcessOutPutIDsService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockProcessOutPutIDsService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsProcessOutPutIDs', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsProcessOutPutIDs());

    const validData = { ...initialProcessOutPutIDs, nome: 'Process Out Put I Ds Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsProcessOutPutIDs());

    const invalidData = { ...initialProcessOutPutIDs, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsProcessOutPutIDs());

    const invalidData = { 
      ...initialProcessOutPutIDs, 
      nome: 'a'.repeat(80+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 80 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsProcessOutPutIDs());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialProcessOutPutIDs, id: 1, nome: 'Process Out Put I Ds Teste' }];
    mockProcessOutPutIDsService.getAll.mockResolvedValue(mockData);
    mockProcessOutPutIDsService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useProcessOutPutIDsList(mockProcessOutPutIDsService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsProcessOutPutIDs()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Process Out Put I Ds Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Process Out Put I Ds Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Process Out Put I Ds 1' },
      { id: 2, nome: 'Process Out Put I Ds 2' }
    ];
    mockProcessOutPutIDsService.getList.mockResolvedValue(mockOptions as IProcessOutPutIDs[]);


    const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Process Out Put I Ds 1' },
        { id: 2, nome: 'Process Out Put I Ds 2' }
      ]);
    });

    expect(mockProcessOutPutIDsService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Process Out Put I Ds ABC' },
      { id: 2, nome: 'Process Out Put I Ds XYZ' }
    ];
    mockProcessOutPutIDsService.getList.mockResolvedValue(mockOptions as IProcessOutPutIDs[]);   


 const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Process Out Put I Ds ABC' },
        { id: 2, nome: 'Process Out Put I Ds XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Process Out Put I Ds ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Process Out Put I Ds ABC' },
      { id: 2, nome: 'Process Out Put I Ds XYZ' }
    ];
    mockProcessOutPutIDsService.getList.mockResolvedValue(mockOptions as IProcessOutPutIDs[]);
  


    const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Process Out Put I Ds ABC' },
        { id: 2, nome: 'Process Out Put I Ds XYZ' }
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
          {id: 1, nome: 'Process Out Put I Ds ABC' },
          {id: 2, nome: 'Process Out Put I Ds XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService)
    );

    const newValue = { id: 1, nome: 'Process Out Put I Ds Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Process Out Put I Ds Inicial' };
    
    const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useProcessOutPutIDsComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Process Out Put I Ds Inicial' };
    
    const { result } = renderHook(() => 
      useProcessOutPutIDsComboBox(mockProcessOutPutIDsService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






