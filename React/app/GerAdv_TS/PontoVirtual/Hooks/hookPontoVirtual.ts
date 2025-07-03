'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IPontoVirtualService } from '../Services/PontoVirtual.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IPontoVirtual } from '../Interfaces/interface.PontoVirtual';
import { isValidDate } from '@/app/tools/datetime';
import { PontoVirtualApi } from '../Apis/ApiPontoVirtual';

export const usePontoVirtualForm = (
  initialPontoVirtual: IPontoVirtual,
  dataService: IPontoVirtualService
) => {
  const [data, setData] = useState<IPontoVirtual>(initialPontoVirtual);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadPontoVirtual = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialPontoVirtual);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchPontoVirtualById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Ponto Virtual';
      setError(errorMessage);
      console.log('Erro ao carregar Ponto Virtual');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialPontoVirtual]);

  const resetForm = useCallback(() => {
    setData(initialPontoVirtual);
    setError(null);
  }, [initialPontoVirtual]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadPontoVirtual,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadPontoVirtual, resetForm]);
  return returnValue;
};


export const usePontoVirtualNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('PontoVirtual', (entity) => {
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


export const usePontoVirtualList = (dataService: IPontoVirtualService) => {
  const [data, setData] = useState<IPontoVirtual[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar pontovirtual';
      setError(errorMessage);
      console.log('Erro ao carregar pontovirtual');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  usePontoVirtualNotifications(
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


export function useValidationsPontoVirtual() {

  async function runValidation(data: IPontoVirtual, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const pontovirtualApi = new PontoVirtualApi(uri ?? '', token ?? '');

    const result = await pontovirtualApi.validation(data);

    return result;
  }

  function validate(data: IPontoVirtual): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.key.length > 23) { 
                                             return { isValid: false, message: 'O campo Key não pode ter mais de 23 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}