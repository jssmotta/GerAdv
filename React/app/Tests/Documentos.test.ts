// Tests.tsx.txt
import { renderHook, act, waitFor } from '@testing-library/react';
import { jest, describe, beforeEach, test, expect } from '@jest/globals';
import { useDocumentosForm, useDocumentosList, useValidationsDocumentos } from '../GerAdv_TS/Documentos/Hooks/hookDocumentos';
import { IDocumentos } from '../GerAdv_TS/Documentos/Interfaces/interface.Documentos';
import { IDocumentosService } from '../GerAdv_TS/Documentos/Services/Documentos.service';
import { DocumentosTestEmpty } from '../GerAdv_TS/Models/Documentos';


// Mock do serviço
const mockDocumentosService: jest.Mocked<IDocumentosService> = {
  fetchDocumentosById: jest.fn(),
  saveDocumentos: jest.fn(),
  
  getAll: jest.fn(),
  deleteDocumentos: jest.fn(),
  validateDocumentos: jest.fn(),
};

beforeAll(() => {
  jest.spyOn(console, 'log').mockImplementation(() => {});
  jest.spyOn(console, 'error').mockImplementation(() => {});
});

// Mock dos dados iniciais
const initialDocumentos: IDocumentos = { ...DocumentosTestEmpty() };

describe('useDocumentosForm', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com dados corretos', () => {
    const { result } = renderHook(() => 
      useDocumentosForm(initialDocumentos, mockDocumentosService)
    );

    expect(result.current.data).toEqual(initialDocumentos);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve atualizar dados com handleChange', () => {
    const { result } = renderHook(() => 
      useDocumentosForm(initialDocumentos, mockDocumentosService)
    );

    const mockEvent = {
      target: {
        name: 'observacao',
        value: 'Novo Documentos',
        type: 'text',
        checked: false
      }
    };

    act(() => {
      result.current.handleChange(mockEvent);
    });

    expect(result.current.data.observacao).toBe('Novo Documentos');
  });

   test('deve carregar Documentos por ID', async () => {
    const mockDocumentos = { ...initialDocumentos, id: 1, observacao: 'Documentos Teste' };
    mockDocumentosService.fetchDocumentosById.mockResolvedValue(mockDocumentos);

    const { result } = renderHook(() => 
      useDocumentosForm(initialDocumentos, mockDocumentosService)
    );

    await act(async () => {
      await result.current.loadDocumentos(1);
    });

    expect(mockDocumentosService.fetchDocumentosById).toHaveBeenCalledWith(1);
    expect(result.current.data).toEqual(mockDocumentos);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro ao carregar Documentos', async () => {
    const errorMessage = 'Erro ao carregar Documentos';
    mockDocumentosService.fetchDocumentosById.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useDocumentosForm(initialDocumentos, mockDocumentosService)
    );

    await act(async () => {
      await result.current.loadDocumentos(1);
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve resetar formulário', () => {
    const { result } = renderHook(() => 
      useDocumentosForm(initialDocumentos, mockDocumentosService)
    );

    // Primeiro, modifica os dados
    act(() => {
      result.current.setData({ ...initialDocumentos, observacao: 'Teste' });
    });

    // Depois reseta
    act(() => {
      result.current.resetForm();
    });

    expect(result.current.data).toEqual(initialDocumentos);
    expect(result.current.error).toBe(null);
  });

  test('não deve carregar quando ID é 0', async () => {
    const { result } = renderHook(() => 
      useDocumentosForm(initialDocumentos, mockDocumentosService)
    );

    await act(async () => {
      await result.current.loadDocumentos(0);
    });

    expect(mockDocumentosService.fetchDocumentosById).not.toHaveBeenCalled();
    expect(result.current.data).toEqual(initialDocumentos);
  });
});

describe('useDocumentosList', () => {
  beforeEach(() => {
    jest.clearAllMocks();
  });

  test('deve inicializar com estado correto', () => {
    const { result } = renderHook(() => 
      useDocumentosList(mockDocumentosService)
    );

    expect(result.current.data).toEqual([]);
    expect(result.current.loading).toBe(false);
    expect(result.current.error).toBe(null);
  });

  test('deve buscar dados com fetchData', async () => {
    const mockData = [
      { ...initialDocumentos, id: 1, observacao: 'Documentos 1' },
      { ...initialDocumentos, id: 2, observacao: 'Documentos 2' }
    ];
    mockDocumentosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useDocumentosList(mockDocumentosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(mockDocumentosService.getAll).toHaveBeenCalled();
    expect(result.current.data).toEqual(mockData);
    expect(result.current.loading).toBe(false);
  });

  test('deve lidar com erro na busca', async () => {
    const errorMessage = 'Erro ao carregar lista';
    mockDocumentosService.getAll.mockRejectedValue(new Error(errorMessage));

    const { result } = renderHook(() => 
      useDocumentosList(mockDocumentosService)
    );

    await act(async () => {
      await result.current.fetchData();
    });

    expect(result.current.error).toBe(errorMessage);
    expect(result.current.loading).toBe(false);
  });

  test('deve buscar dados com filtro', async () => {
    const mockData = [{ ...initialDocumentos, id: 1, observacao: 'Documentos Filtrado' }];
    const filtro = { observacao: 'Documentos' };
    mockDocumentosService.getAll.mockResolvedValue(mockData);

    const { result } = renderHook(() => 
      useDocumentosList(mockDocumentosService)
    );

    await act(async () => {
      await result.current.fetchData(filtro);
    });

    expect(mockDocumentosService.getAll).toHaveBeenCalledWith(filtro);
    expect(result.current.data).toEqual(mockData);
  });
});

describe('useValidationsDocumentos', () => {
  test('deve validar dados corretos', () => {
    const { result } = renderHook(() => useValidationsDocumentos());

    const validData = { ...initialDocumentos, observacao: 'Documentos Válido' };
    const validation = result.current.validate(validData);

    expect(validation.isValid).toBe(true);
    expect(validation.message).toBe('');
  });


  

  

  test('deve invalidar dados nulos', () => {
    const { result } = renderHook(() => useValidationsDocumentos());

    const validation = result.current.validate(null as any);

    expect(validation.isValid).toBe(false);
    expect(validation.message).toBe('Dados não informados.');
  });
});


// Teste de integração para múltiplos hooks
describe('Integração de hooks', () => {
  test('deve funcionar em conjunto', async () => {
    const mockData = [{ ...initialDocumentos, id: 1, observacao: 'Documentos Teste' }];
    mockDocumentosService.getAll.mockResolvedValue(mockData);
    

    // Usa múltiplos hooks
    const { result: listResult } = renderHook(() => 
      useDocumentosList(mockDocumentosService)
    );
    
       

    const { result: validationResult } = renderHook(() => 
      useValidationsDocumentos()
    );

    // Busca dados na lista
    await act(async () => {
      await listResult.current.fetchData();
    });

    
   

    // Valida dados
    const validation = validationResult.current.validate(mockData[0]);

    expect(listResult.current.data).toEqual(mockData);
    
  
    expect(validation.isValid).toBe(true);
  });
});