'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IContaCorrenteService } from '../Services/ContaCorrente.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IContaCorrente } from '../Interfaces/interface.ContaCorrente';
import { isValidDate } from '@/app/tools/datetime';

export const useContaCorrenteForm = (
  initialContaCorrente: IContaCorrente,
  dataService: IContaCorrenteService
) => {
  const [data, setData] = useState<IContaCorrente>(initialContaCorrente);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadContaCorrente = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialContaCorrente);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchContaCorrenteById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Conta Corrente';
      setError(errorMessage);
      console.log('Erro ao carregar Conta Corrente');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialContaCorrente]);

  const resetForm = useCallback(() => {
    setData(initialContaCorrente);
    setError(null);
  }, [initialContaCorrente]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadContaCorrente,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadContaCorrente, resetForm]);
  return returnValue;
};


export const useContaCorrenteNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ContaCorrente', (entity) => {
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


export const useContaCorrenteList = (dataService: IContaCorrenteService) => {
  const [data, setData] = useState<IContaCorrente[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar contacorrente';
      setError(errorMessage);
      console.log('Erro ao carregar contacorrente');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useContaCorrenteNotifications(
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


export function useValidationsContaCorrente() {
  function validate(data: IContaCorrente): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.historico.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Historico não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}