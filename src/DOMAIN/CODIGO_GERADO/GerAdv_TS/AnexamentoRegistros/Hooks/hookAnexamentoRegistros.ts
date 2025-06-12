'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAnexamentoRegistrosService } from '../Services/AnexamentoRegistros.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAnexamentoRegistros } from '../Interfaces/interface.AnexamentoRegistros';
import { isValidDate } from '@/app/tools/datetime';

export const useAnexamentoRegistrosForm = (
  initialAnexamentoRegistros: IAnexamentoRegistros,
  dataService: IAnexamentoRegistrosService
) => {
  const [data, setData] = useState<IAnexamentoRegistros>(initialAnexamentoRegistros);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAnexamentoRegistros = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAnexamentoRegistros);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAnexamentoRegistrosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Anexamento Registros';
      setError(errorMessage);
      console.log('Erro ao carregar Anexamento Registros');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAnexamentoRegistros]);

  const resetForm = useCallback(() => {
    setData(initialAnexamentoRegistros);
    setError(null);
  }, [initialAnexamentoRegistros]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAnexamentoRegistros,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAnexamentoRegistros, resetForm]);
  return returnValue;
};


export const useAnexamentoRegistrosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AnexamentoRegistros', (entity) => {
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


export const useAnexamentoRegistrosList = (dataService: IAnexamentoRegistrosService) => {
  const [data, setData] = useState<IAnexamentoRegistros[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar anexamentoregistros';
      setError(errorMessage);
      console.log('Erro ao carregar anexamentoregistros');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAnexamentoRegistrosNotifications(
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


export function useValidationsAnexamentoRegistros() {
  function validate(data: IAnexamentoRegistros): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.guidreg.length > 100) { 
                                             return { isValid: false, message: 'O campo GUIDReg não pode ter mais de 100 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}