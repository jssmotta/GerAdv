'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAgendaRepetirDiasService } from '../Services/AgendaRepetirDias.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAgendaRepetirDias } from '../Interfaces/interface.AgendaRepetirDias';
import { isValidDate } from '@/app/tools/datetime';

export const useAgendaRepetirDiasForm = (
  initialAgendaRepetirDias: IAgendaRepetirDias,
  dataService: IAgendaRepetirDiasService
) => {
  const [data, setData] = useState<IAgendaRepetirDias>(initialAgendaRepetirDias);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAgendaRepetirDias = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAgendaRepetirDias);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAgendaRepetirDiasById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Agenda Repetir Dias';
      setError(errorMessage);
      console.log('Erro ao carregar Agenda Repetir Dias');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAgendaRepetirDias]);

  const resetForm = useCallback(() => {
    setData(initialAgendaRepetirDias);
    setError(null);
  }, [initialAgendaRepetirDias]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAgendaRepetirDias,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAgendaRepetirDias, resetForm]);
  return returnValue;
};


export const useAgendaRepetirDiasNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AgendaRepetirDias', (entity) => {
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


export const useAgendaRepetirDiasList = (dataService: IAgendaRepetirDiasService) => {
  const [data, setData] = useState<IAgendaRepetirDias[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar agendarepetirdias';
      setError(errorMessage);
      console.log('Erro ao carregar agendarepetirdias');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAgendaRepetirDiasNotifications(
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


export function useValidationsAgendaRepetirDias() {
  function validate(data: IAgendaRepetirDias): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}