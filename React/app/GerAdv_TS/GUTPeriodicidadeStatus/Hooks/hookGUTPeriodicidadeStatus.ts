'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IGUTPeriodicidadeStatusService } from '../Services/GUTPeriodicidadeStatus.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IGUTPeriodicidadeStatus } from '../Interfaces/interface.GUTPeriodicidadeStatus';
import { isValidDate } from '@/app/tools/datetime';

export const useGUTPeriodicidadeStatusForm = (
  initialGUTPeriodicidadeStatus: IGUTPeriodicidadeStatus,
  dataService: IGUTPeriodicidadeStatusService
) => {
  const [data, setData] = useState<IGUTPeriodicidadeStatus>(initialGUTPeriodicidadeStatus);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadGUTPeriodicidadeStatus = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialGUTPeriodicidadeStatus);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchGUTPeriodicidadeStatusById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar G U T Periodicidade Status';
      setError(errorMessage);
      console.log('Erro ao carregar G U T Periodicidade Status');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialGUTPeriodicidadeStatus]);

  const resetForm = useCallback(() => {
    setData(initialGUTPeriodicidadeStatus);
    setError(null);
  }, [initialGUTPeriodicidadeStatus]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadGUTPeriodicidadeStatus,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadGUTPeriodicidadeStatus, resetForm]);
  return returnValue;
};


export const useGUTPeriodicidadeStatusNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('GUTPeriodicidadeStatus', (entity) => {
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


export const useGUTPeriodicidadeStatusList = (dataService: IGUTPeriodicidadeStatusService) => {
  const [data, setData] = useState<IGUTPeriodicidadeStatus[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar gutperiodicidadestatus';
      setError(errorMessage);
      console.log('Erro ao carregar gutperiodicidadestatus');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useGUTPeriodicidadeStatusNotifications(
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


export function useValidationsGUTPeriodicidadeStatus() {
  function validate(data: IGUTPeriodicidadeStatus): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}