"use client";
import { useState, useEffect, useCallback, useRef } from 'react';
import { GridColumnState } from '@progress/kendo-react-grid';

interface UseHiddenColumnsProps {
  gridColumns?: React.ReactElement[];
  columnMap?: Record<string, React.ReactElement>; 
  systemContextId?: number;
  tableName: string;
  defaultHiddenColumns?: string[];
}

// Estendendo GridColumnState para incluir title
interface ExtendedGridColumnState extends GridColumnState {
  title?: string;
}

interface UseHiddenColumnsReturn {
  columnsState: ExtendedGridColumnState[];
  initialized: boolean;
  handleColumnsStateChange: (newState: ExtendedGridColumnState[]) => void;
}

export const useHiddenColumns = ({
  gridColumns = [],
  columnMap,
  systemContextId,
  tableName,
  defaultHiddenColumns = []
}: UseHiddenColumnsProps): UseHiddenColumnsReturn => {
  const [columnsState, setColumnsState] = useState<ExtendedGridColumnState[]>([]);
  const [initialized, setInitialized] = useState(false);
  
  // Refs para evitar loops infinitos
  const defaultHiddenRef = useRef(defaultHiddenColumns);
  const storageKeyRef = useRef('');
  const initializeOnceRef = useRef(false);

  // Atualizar refs
  defaultHiddenRef.current = defaultHiddenColumns;
  
  // Gerar chave de storage estável
  if (!storageKeyRef.current) {
    const baseKey = `${tableName}-columns-state`;
    const contextKey = systemContextId ? `${baseKey}-${systemContextId}` : baseKey;
    storageKeyRef.current = btoa(contextKey);
  }

  // Handler para mudanças no estado das colunas
  const handleColumnsStateChange = useCallback((newState: ExtendedGridColumnState[]) => {
    setColumnsState(newState);
    
    try {
      localStorage.setItem(storageKeyRef.current, JSON.stringify(newState));
    } catch (error) {
      console.warn('Erro ao salvar estado das colunas no localStorage:', error);
    }
  }, []);

  // Função para criar todas as colunas possíveis - agora capturando field e title
  const createAllPossibleFields = useCallback((): Array<{field: string, title: string}> => {
    // Extrair campos e títulos dos gridColumns base
    const baseFieldsWithTitles = gridColumns
      .map(column => {
        const props = column.props as { field?: string; title?: string };
        const field = props?.field;
        const title = props?.title;
        
        if (typeof field === 'string') {
          return {
            field,
            title: title || field // Se não houver title, usar o field
          };
        }
        return null;
      })
      .filter((item): item is {field: string, title: string} => item !== null);

    // Se temos columnMap, combinar com os campos base
    if (columnMap && Object.keys(columnMap).length > 0) {
      const columnMapFieldsWithTitles = Object.entries(columnMap).map(([key, column]) => {
        const props = column.props as { field?: string; title?: string };
        const field = props?.field || key;
        const title = props?.title || field;
        
        return { field, title };
      });

      // Criar um Map para evitar duplicatas, priorizando columnMap
      const fieldsMap = new Map<string, {field: string, title: string}>();
      
      // Adicionar campos base primeiro
      baseFieldsWithTitles.forEach(item => {
        fieldsMap.set(item.field, item);
      });
      
      // Sobrescrever com campos do columnMap (prioridade)
      columnMapFieldsWithTitles.forEach(item => {
        fieldsMap.set(item.field, item);
      });
      
      return Array.from(fieldsMap.values());
    }

    // Se não temos columnMap, usar apenas os gridColumns extraídos
    return baseFieldsWithTitles;
  }, [gridColumns, columnMap]);

  // Carregar estado salvo
  const loadSavedState = useCallback((): ExtendedGridColumnState[] | null => {
    try {
      const stored = localStorage.getItem(storageKeyRef.current);
      if (stored) {
        const parsed = JSON.parse(stored);
        if (Array.isArray(parsed) && parsed.length > 0) {
          return parsed.map(state => ({
            id: state.id ?? state.field,
            field: state.field,
            title: state.title, // Preservar title salvo
            hidden: Boolean(state.hidden),
            width: state.width,
            orderIndex: state.orderIndex
          }));
        }
      }
    } catch (error) {
      console.warn('Erro ao carregar estado das colunas:', error);
    }
    return null;
  }, []);

  // Inicialização - executar apenas uma vez
  useEffect(() => {
    if (initializeOnceRef.current) {
      return;
    }

    const availableFieldsWithTitles = createAllPossibleFields();
    
    if (availableFieldsWithTitles.length === 0) {
      setInitialized(true);
      return;
    }

    // Carregar estado salvo
    const savedState = loadSavedState();
    
    let finalState: ExtendedGridColumnState[];
    
    if (savedState && savedState.length > 0) {
      // Sincronizar estado salvo com campos disponíveis
      const stateMap = new Map(savedState.map(state => [state.field, state]));
      
      finalState = availableFieldsWithTitles.map(({field, title}) => {
        const existing = stateMap.get(field);
        if (existing) {
          // Atualizar title se necessário (pode ter mudado no código)
          return {
            ...existing,
            title: title
          };
        }
        
        return {
          id: field,
          field,
          title,
          hidden: defaultHiddenRef.current.includes(field),
          width: undefined,
          orderIndex: undefined
        };
      });
    } else {
      // Criar estado inicial
      finalState = availableFieldsWithTitles.map(({field, title}) => ({
        id: field,
        field,
        title,
        hidden: defaultHiddenRef.current.includes(field),
        width: undefined,
        orderIndex: undefined
      }));
    }
    
    // Salvar estado
    try {
      localStorage.setItem(storageKeyRef.current, JSON.stringify(finalState));
    } catch (error) {
      console.warn('Erro ao salvar estado:', error);
    }
    
    setColumnsState(finalState);
    setInitialized(true);
    initializeOnceRef.current = true;
    
  }, [createAllPossibleFields, loadSavedState]);

  return {
    columnsState,
    initialized,
    handleColumnsStateChange
  };
};