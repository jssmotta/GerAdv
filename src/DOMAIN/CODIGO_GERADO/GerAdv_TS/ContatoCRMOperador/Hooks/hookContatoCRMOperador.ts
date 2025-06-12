'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IContatoCRMOperadorService } from '../Services/ContatoCRMOperador.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IContatoCRMOperador } from '../Interfaces/interface.ContatoCRMOperador';
import { isValidDate } from '@/app/tools/datetime';

export const useContatoCRMOperadorForm = (
  initialContatoCRMOperador: IContatoCRMOperador,
  dataService: IContatoCRMOperadorService
) => {
  const [data, setData] = useState<IContatoCRMOperador>(initialContatoCRMOperador);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadContatoCRMOperador = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialContatoCRMOperador);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchContatoCRMOperadorById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Contato C R M Operador';
      setError(errorMessage);
      console.log('Erro ao carregar Contato C R M Operador');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialContatoCRMOperador]);

  const resetForm = useCallback(() => {
    setData(initialContatoCRMOperador);
    setError(null);
  }, [initialContatoCRMOperador]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadContatoCRMOperador,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadContatoCRMOperador, resetForm]);
  return returnValue;
};


export const useContatoCRMOperadorNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ContatoCRMOperador', (entity) => {
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


export const useContatoCRMOperadorList = (dataService: IContatoCRMOperadorService) => {
  const [data, setData] = useState<IContatoCRMOperador[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar contatocrmoperador';
      setError(errorMessage);
      console.log('Erro ao carregar contatocrmoperador');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useContatoCRMOperadorNotifications(
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


export function useValidationsContatoCRMOperador() {
  function validate(data: IContatoCRMOperador): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}