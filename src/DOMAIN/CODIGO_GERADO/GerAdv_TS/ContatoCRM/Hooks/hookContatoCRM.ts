'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IContatoCRMService } from '../Services/ContatoCRM.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IContatoCRM } from '../Interfaces/interface.ContatoCRM';
import { isValidDate } from '@/app/tools/datetime';

export const useContatoCRMForm = (
  initialContatoCRM: IContatoCRM,
  dataService: IContatoCRMService
) => {
  const [data, setData] = useState<IContatoCRM>(initialContatoCRM);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadContatoCRM = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialContatoCRM);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchContatoCRMById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Contato C R M';
      setError(errorMessage);
      console.log('Erro ao carregar Contato C R M');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialContatoCRM]);

  const resetForm = useCallback(() => {
    setData(initialContatoCRM);
    setError(null);
  }, [initialContatoCRM]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadContatoCRM,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadContatoCRM, resetForm]);
  return returnValue;
};


export const useContatoCRMNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ContatoCRM', (entity) => {
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


export const useContatoCRMList = (dataService: IContatoCRMService) => {
  const [data, setData] = useState<IContatoCRM[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar contatocrm';
      setError(errorMessage);
      console.log('Erro ao carregar contatocrm');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useContatoCRMNotifications(
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


export function useValidationsContatoCRM() {
  function validate(data: IContatoCRM): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.assunto.length > 255) { 
                                             return { isValid: false, message: 'O campo Assunto não pode ter mais de 255 caracteres.' };
                                         } 
if (data.pessoacontato.length > 255) { 
                                             return { isValid: false, message: 'O campo PessoaContato não pode ter mais de 255 caracteres.' };
                                         } 
if (data.contato.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Contato não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}