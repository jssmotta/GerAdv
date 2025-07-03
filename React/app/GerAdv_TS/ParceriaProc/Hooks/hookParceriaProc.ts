'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IParceriaProcService } from '../Services/ParceriaProc.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IParceriaProc } from '../Interfaces/interface.ParceriaProc';
import { isValidDate } from '@/app/tools/datetime';
import { ParceriaProcApi } from '../Apis/ApiParceriaProc';

export const useParceriaProcForm = (
  initialParceriaProc: IParceriaProc,
  dataService: IParceriaProcService
) => {
  const [data, setData] = useState<IParceriaProc>(initialParceriaProc);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadParceriaProc = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialParceriaProc);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchParceriaProcById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Parceria Proc';
      setError(errorMessage);
      console.log('Erro ao carregar Parceria Proc');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialParceriaProc]);

  const resetForm = useCallback(() => {
    setData(initialParceriaProc);
    setError(null);
  }, [initialParceriaProc]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadParceriaProc,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadParceriaProc, resetForm]);
  return returnValue;
};


export const useParceriaProcNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ParceriaProc', (entity) => {
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


export const useParceriaProcList = (dataService: IParceriaProcService) => {
  const [data, setData] = useState<IParceriaProc[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar parceriaproc';
      setError(errorMessage);
      console.log('Erro ao carregar parceriaproc');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useParceriaProcNotifications(
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


export function useValidationsParceriaProc() {

  async function runValidation(data: IParceriaProc, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const parceriaprocApi = new ParceriaProcApi(uri ?? '', token ?? '');

    const result = await parceriaprocApi.validation(data);

    return result;
  }

  function validate(data: IParceriaProc): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}