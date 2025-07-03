'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAgendaRelatorioService } from '../Services/AgendaRelatorio.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAgendaRelatorio } from '../Interfaces/interface.AgendaRelatorio';
import { isValidDate } from '@/app/tools/datetime';
import { AgendaRelatorioApi } from '../Apis/ApiAgendaRelatorio';

export const useAgendaRelatorioForm = (
  initialAgendaRelatorio: IAgendaRelatorio,
  dataService: IAgendaRelatorioService
) => {
  const [data, setData] = useState<IAgendaRelatorio>(initialAgendaRelatorio);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAgendaRelatorio = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAgendaRelatorio);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAgendaRelatorioById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Agenda Relatorio';
      setError(errorMessage);
      console.log('Erro ao carregar Agenda Relatorio');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAgendaRelatorio]);

  const resetForm = useCallback(() => {
    setData(initialAgendaRelatorio);
    setError(null);
  }, [initialAgendaRelatorio]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAgendaRelatorio,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAgendaRelatorio, resetForm]);
  return returnValue;
};


export const useAgendaRelatorioNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AgendaRelatorio', (entity) => {
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


export const useAgendaRelatorioList = (dataService: IAgendaRelatorioService) => {
  const [data, setData] = useState<IAgendaRelatorio[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar agendarelatorio';
      setError(errorMessage);
      console.log('Erro ao carregar agendarelatorio');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAgendaRelatorioNotifications(
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


export function useValidationsAgendaRelatorio() {

  async function runValidation(data: IAgendaRelatorio, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const agendarelatorioApi = new AgendaRelatorioApi(uri ?? '', token ?? '');

    const result = await agendarelatorioApi.validation(data);

    return result;
  }

  function validate(data: IAgendaRelatorio): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}