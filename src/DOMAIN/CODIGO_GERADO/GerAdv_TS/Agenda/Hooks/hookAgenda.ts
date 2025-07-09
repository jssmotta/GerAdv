'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAgendaService } from '../Services/Agenda.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAgenda } from '../Interfaces/interface.Agenda';
import { isValidDate } from '@/app/tools/datetime';
import { AgendaApi } from '../Apis/ApiAgenda';

export const useAgendaForm = (
  initialAgenda: IAgenda,
  dataService: IAgendaService
) => {
  const [data, setData] = useState<IAgenda>(initialAgenda);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAgenda = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAgenda);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAgendaById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Compromisso';
      setError(errorMessage);
      console.log('Erro ao carregar Compromisso');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAgenda]);

  const resetForm = useCallback(() => {
    setData(initialAgenda);
    setError(null);
  }, [initialAgenda]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAgenda,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAgenda, resetForm]);
  return returnValue;
};


export const useAgendaNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Agenda', (entity) => {
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


export const useAgendaList = (dataService: IAgendaService) => {
  const [data, setData] = useState<IAgenda[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar agenda';
      setError(errorMessage);
      console.log('Erro ao carregar agenda');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAgendaNotifications(
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


export function useValidationsAgenda() {

  async function runValidation(data: IAgenda, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const agendaApi = new AgendaApi(uri ?? '', token ?? '');

    const result = await agendaApi.validation(data);

    return result;
  }

  function validate(data: IAgenda): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.compromisso.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Compromisso não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.status.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Status não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.decisao.length > 2048) { 
                                             return { isValid: false, message: 'O campo Decisao não pode ter mais de 2048 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}