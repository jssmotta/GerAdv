// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useDocsRecebidosItensForm, useDocsRecebidosItensList, useValidationsDocsRecebidosItens } from '../GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens';
import { IDocsRecebidosItens } from '../GerAdv_TS/DocsRecebidosItens/Interfaces/interface.DocsRecebidosItens';
import { IDocsRecebidosItensService } from '../GerAdv_TS/DocsRecebidosItens/Services/DocsRecebidosItens.service';
import { DocsRecebidosItensTestEmpty } from '../GerAdv_TS/Models/DocsRecebidosItens';
import { useDocsRecebidosItensComboBox } from '../GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens';

// Mock do serviço
const mockDocsRecebidosItensService: jest.Mocked<IDocsRecebidosItensService> = {
  fetchDocsRecebidosItensById: jest.fn(),
  saveDocsRecebidosItens: jest.fn(),
  getList: jest.fn(),
  getAll: jest.fn(),
  deleteDocsRecebidosItens: jest.fn(),
  validateDocsRecebidosItens: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialDocsRecebidosItens: IDocsRecebidosItens = { ...DocsRecebidosItensTestEmpty() };

describe('useDocsRecebidosItensForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    expect(result.current.data).toEqual(initialDocsRecebidosItens);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    const mockEvent = {
      target: {
        name: 'nome',
        value: 'Novo Docs Recebidos Itens',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.nome).toBe('Novo Docs Recebidos Itens');
  });

   test('deve carregar Docs Recebidos Itens por ID', async () => {
    const mockDocsRecebidosItens = { ...initialDocsRecebidosItens, id: 1, nome: 'Docs Recebidos Itens Teste' };
    mockDocsRecebidosItensService.fetchDocsRecebidosItensById.mockResolvedValue(mockDocsRecebidosItens);

    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    await act(async () => {
      await result.current.loadDocsRecebidosItens(1);
    });

    expect(mockDocsRecebidosItensService.fetchDocsRecebidosItensById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockDocsRecebidosItens);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Docs Recebidos Itens', async () => {
    const errorMessage = 'Erro ao carregar Docs Recebidos Itens';
    mockDocsRecebidosItensService.fetchDocsRecebidosItensById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    await act(async () => {
      await result.current.loadDocsRecebidosItens(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialDocsRecebidosItens, nome: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialDocsRecebidosItens);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    await act(async () => {
      await result.current.loadDocsRecebidosItens(0);
    });

    expect(mockDocsRecebidosItensService.fetchDocsRecebidosItensById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialDocsRecebidosItens);
  });
});

describe('useDocsRecebidosItensList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensList(mockDocsRecebidosItensService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialDocsRecebidosItens, id: 1, nome: 'Docs Recebidos Itens 1' },
      { ...initialDocsRecebidosItens, id: 2, nome: 'Docs Recebidos Itens 2' }
    ];
    mockDocsRecebidosItensService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useDocsRecebidosItensList(mockDocsRecebidosItensService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockDocsRecebidosItensService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockDocsRecebidosItensService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useDocsRecebidosItensList(mockDocsRecebidosItensService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialDocsRecebidosItens, id: 1, nome: 'Docs Recebidos Itens Filtrado' }];
    const filtro = { nome: 'Docs Recebidos Itens' };
    mockDocsRecebidosItensService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useDocsRecebidosItensList(mockDocsRecebidosItensService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockDocsRecebidosItensService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsDocsRecebidosItens', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsDocsRecebidosItens());

    const validData = { ...initialDocsRecebidosItens, nome: 'Docs Recebidos Itens Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


    test('deve invalidar nome vazio', () => {
    const { result } = renderHook(() => useValidationsDocsRecebidosItens());

    const invalidData = { ...initialDocsRecebidosItens, nome: '' };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ficar vazio.');
  });

  
  test('deve invalidar nome muito longo', () => {
    const { result } = renderHook(() => useValidationsDocsRecebidosItens());

    const invalidData = { 
      ...initialDocsRecebidosItens, 
      nome: 'a'.repeat(255+1)
    };
    const validation = result.current.validate(invalidData);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('O campo Nome não pode ter mais de 255 caracteres.');
  });


  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsDocsRecebidosItens());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialDocsRecebidosItens, id: 1, nome: 'Docs Recebidos Itens Teste' }];
    mockDocsRecebidosItensService.getAll.mockResolvedValue(mockData);
    mockDocsRecebidosItensService.getList.mockResolvedValue(mockData);

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useDocsRecebidosItensList(mockDocsRecebidosItensService)
    );
    
     const { result: comboResult } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService)
    );   

    const { result: validationResult } = renderHook(() => 
      useValidationsDocsRecebidosItens()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

     
    // Aguarda carregar opções no combo
    
      expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Docs Recebidos Itens Teste' }]);
    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
     expect(comboResult.current.options).toEqual([{ id: 1, nome: 'Docs Recebidos Itens Teste' }]);
  
    expect(validation.isValid).toBe(true);
  });
});  test('deve lidar com checkbox no handleChange', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensForm(initialDocsRecebidosItens, mockDocsRecebidosItensService)
    );

    const mockEvent = {
      target: {
        name: 'devolvido',
        value: '',
        type: 'checkbox',
        checked: true
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.devolvido).toBe(true);
  });


  test('deve carregar opções na inicialização', async () => {
    const mockOptions = [
      { id: 1, nome: 'Docs Recebidos Itens 1' },
      { id: 2, nome: 'Docs Recebidos Itens 2' }
    ];
    mockDocsRecebidosItensService.getList.mockResolvedValue(mockOptions as IDocsRecebidosItens[]);


    const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService)
    );

    await waitFor(() => {
      // Aguarda carregar as opções antes de verificar
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Docs Recebidos Itens 1' },
        { id: 2, nome: 'Docs Recebidos Itens 2' }
      ]);
    });

    expect(mockDocsRecebidosItensService.getList).toHaveBeenCalled();
  });

  test('deve filtrar opções', async () => {
    const mockOptions = [
      { id: 1, nome: 'Docs Recebidos Itens ABC' },
      { id: 2, nome: 'Docs Recebidos Itens XYZ' }
    ];
    mockDocsRecebidosItensService.getList.mockResolvedValue(mockOptions as IDocsRecebidosItens[]);   


 const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService)
    );


    // Aguarda carregar as opções
    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Docs Recebidos Itens ABC' },
        { id: 2, nome: 'Docs Recebidos Itens XYZ' }
      ]);
    });

    // Aplica filtro
    act(() => {
      result.current.handleFilter('ABC');
    });

    expect(result.current.options).toEqual([{ id: 1, nome: 'Docs Recebidos Itens ABC' }]);
  });


  test('deve limpar filtro quando texto vazio', async () => {
    const mockOptions = [
      { id: 1, nome: 'Docs Recebidos Itens ABC' },
      { id: 2, nome: 'Docs Recebidos Itens XYZ' }
    ];
    mockDocsRecebidosItensService.getList.mockResolvedValue(mockOptions as IDocsRecebidosItens[]);
  


    const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService)
    );


    await waitFor(() => {
      expect(result.current.options).toEqual([
        { id: 1, nome: 'Docs Recebidos Itens ABC' },
        { id: 2, nome: 'Docs Recebidos Itens XYZ' }
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
          {id: 1, nome: 'Docs Recebidos Itens ABC' },
          {id: 2, nome: 'Docs Recebidos Itens XYZ' }
        ]);

  });



 test('deve alterar valor selecionado', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService)
    );

    const newValue = { id: 1, nome: 'Docs Recebidos Itens Selecionado' };

    act(() => {
      result.current.handleValueChange(newValue);
    });

    expect(result.current.selectedValue).toEqual(newValue);
  });

  test('deve limpar valor selecionado', () => {
    const initialValue = { id: 1, nome: 'Docs Recebidos Itens Inicial' };
    
    const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService, initialValue)
    );

    act(() => {
      result.current.clearValue();
    });

    expect(result.current.selectedValue).toBe(null);
  });


describe('useDocsRecebidosItensComboBox', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService)
    );

    expect(result.current.options).toEqual([]);
    expect(result.current.loading).toBe(true);
    expect(result.current.selectedValue).toBeUndefined();
  });

 
  test('deve inicializar com valor inicial', () => {
    const initialValue = { id: 1, nome: 'Docs Recebidos Itens Inicial' };
    
    const { result } = renderHook(() => 
      useDocsRecebidosItensComboBox(mockDocsRecebidosItensService, initialValue)
    );

    expect(result.current.selectedValue).toEqual(initialValue);
  });
});






