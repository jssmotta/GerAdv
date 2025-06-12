'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IApenso2Service } from '../Services/Apenso2.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IApenso2 } from '../Interfaces/interface.Apenso2';
import { isValidDate } from '@/app/tools/datetime';

export const useApenso2Form = (
  initialApenso2: IApenso2,
  dataService: IApenso2Service
) => {
  const [data, setData] = useState<IApenso2>(initialApenso2);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadApenso2 = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialApenso2);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchApenso2ById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Apenso2';
      setError(errorMessage);
      console.log('Erro ao carregar Apenso2');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialApenso2]);

  const resetForm = useCallback(() => {
    setData(initialApenso2);
    setError(null);
  }, [initialApenso2]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadApenso2,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadApenso2, resetForm]);
  return returnValue;
};


export const useApenso2Notifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Apenso2', (entity) => {
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


export const useApenso2List = (dataService: IApenso2Service) => {
  const [data, setData] = useState<IApenso2[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar apenso2';
      setError(errorMessage);
      console.log('Erro ao carregar apenso2');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useApenso2Notifications(
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


export function useValidationsApenso2() {
  function validate(data: IApenso2): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}