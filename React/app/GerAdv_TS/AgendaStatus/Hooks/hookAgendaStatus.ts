'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAgendaStatusService } from '../Services/AgendaStatus.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAgendaStatus } from '../Interfaces/interface.AgendaStatus';
import { isValidDate } from '@/app/tools/datetime';
import { AgendaStatusApi } from '../Apis/ApiAgendaStatus';

export const useAgendaStatusForm = (
  initialAgendaStatus: IAgendaStatus,
  dataService: IAgendaStatusService
) => {
  const [data, setData] = useState<IAgendaStatus>(initialAgendaStatus);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAgendaStatus = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAgendaStatus);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAgendaStatusById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Agenda Status';
      setError(errorMessage);
      console.log('Erro ao carregar Agenda Status');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAgendaStatus]);

  const resetForm = useCallback(() => {
    setData(initialAgendaStatus);
    setError(null);
  }, [initialAgendaStatus]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAgendaStatus,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAgendaStatus, resetForm]);
  return returnValue;
};


export const useAgendaStatusNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AgendaStatus', (entity) => {
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


export const useAgendaStatusList = (dataService: IAgendaStatusService) => {
  const [data, setData] = useState<IAgendaStatus[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar agendastatus';
      setError(errorMessage);
      console.log('Erro ao carregar agendastatus');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAgendaStatusNotifications(
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


export function useValidationsAgendaStatus() {

  async function runValidation(data: IAgendaStatus, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const agendastatusApi = new AgendaStatusApi(uri ?? '', token ?? '');

    const result = await agendastatusApi.validation(data);

    return result;
  }

  function validate(data: IAgendaStatus): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}