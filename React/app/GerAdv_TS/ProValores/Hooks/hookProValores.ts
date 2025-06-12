'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IProValoresService } from '../Services/ProValores.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IProValores } from '../Interfaces/interface.ProValores';
import { isValidDate } from '@/app/tools/datetime';

export const useProValoresForm = (
  initialProValores: IProValores,
  dataService: IProValoresService
) => {
  const [data, setData] = useState<IProValores>(initialProValores);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadProValores = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialProValores);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchProValoresById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Pro Valores';
      setError(errorMessage);
      console.log('Erro ao carregar Pro Valores');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialProValores]);

  const resetForm = useCallback(() => {
    setData(initialProValores);
    setError(null);
  }, [initialProValores]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadProValores,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadProValores, resetForm]);
  return returnValue;
};


export const useProValoresNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ProValores', (entity) => {
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


export const useProValoresList = (dataService: IProValoresService) => {
  const [data, setData] = useState<IProValores[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar provalores';
      setError(errorMessage);
      console.log('Erro ao carregar provalores');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useProValoresNotifications(
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


export function useValidationsProValores() {
  function validate(data: IProValores): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.indice.length > 20) { 
                                             return { isValid: false, message: 'O campo Indice não pode ter mais de 20 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}