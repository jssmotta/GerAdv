'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IProDepositosService } from '../Services/ProDepositos.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IProDepositos } from '../Interfaces/interface.ProDepositos';
import { isValidDate } from '@/app/tools/datetime';

export const useProDepositosForm = (
  initialProDepositos: IProDepositos,
  dataService: IProDepositosService
) => {
  const [data, setData] = useState<IProDepositos>(initialProDepositos);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadProDepositos = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialProDepositos);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchProDepositosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Pro Depositos';
      setError(errorMessage);
      console.log('Erro ao carregar Pro Depositos');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialProDepositos]);

  const resetForm = useCallback(() => {
    setData(initialProDepositos);
    setError(null);
  }, [initialProDepositos]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadProDepositos,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadProDepositos, resetForm]);
  return returnValue;
};


export const useProDepositosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ProDepositos', (entity) => {
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


export const useProDepositosList = (dataService: IProDepositosService) => {
  const [data, setData] = useState<IProDepositos[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar prodepositos';
      setError(errorMessage);
      console.log('Erro ao carregar prodepositos');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useProDepositosNotifications(
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


export function useValidationsProDepositos() {
  function validate(data: IProDepositos): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}