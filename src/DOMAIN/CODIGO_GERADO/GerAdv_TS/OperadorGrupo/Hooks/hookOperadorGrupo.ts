'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IOperadorGrupoService } from '../Services/OperadorGrupo.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IOperadorGrupo } from '../Interfaces/interface.OperadorGrupo';
import { isValidDate } from '@/app/tools/datetime';

export const useOperadorGrupoForm = (
  initialOperadorGrupo: IOperadorGrupo,
  dataService: IOperadorGrupoService
) => {
  const [data, setData] = useState<IOperadorGrupo>(initialOperadorGrupo);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadOperadorGrupo = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialOperadorGrupo);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchOperadorGrupoById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Operador Grupo';
      setError(errorMessage);
      console.log('Erro ao carregar Operador Grupo');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialOperadorGrupo]);

  const resetForm = useCallback(() => {
    setData(initialOperadorGrupo);
    setError(null);
  }, [initialOperadorGrupo]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadOperadorGrupo,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadOperadorGrupo, resetForm]);
  return returnValue;
};


export const useOperadorGrupoNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('OperadorGrupo', (entity) => {
      try {
        const { onUpdate, onDelete, onAdd } = callbacksRef.current;
        
        switch (entity.action) {
          case NotifySystemActions.DELETE:
            onDelete?.(entity);
            break;
          case NotifySystemActions.UPDATE:
            onUpdate?.(entity);
            break;
          case NotifySystemActions.ADD:
            onAdd?.(entity);
            break;
        }
      } catch (err) {
        console.log('Erro no listener de notificações.');
      }
    });

    return () => {
      unsubscribe();
    };
  }, []);
};


export const useOperadorGrupoList = (dataService: IOperadorGrupoService) => {
  const [data, setData] = useState<IOperadorGrupo[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar operadorgrupo';
      setError(errorMessage);
      console.log('Erro ao carregar operadorgrupo');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useOperadorGrupoNotifications(
    refreshData, // onUpdate
    refreshData, // onDelete  
    refreshData  // onAdd
  );
   

  return {
    data,
    loading,
    error,
    fetchData,
    refreshData
  };
};


export function useValidationsOperadorGrupo() {
  function validate(data: IOperadorGrupo): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}