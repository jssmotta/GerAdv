'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAgendaRepetirService } from '../Services/AgendaRepetir.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAgendaRepetir } from '../Interfaces/interface.AgendaRepetir';
import { isValidDate } from '@/app/tools/datetime';

export const useAgendaRepetirForm = (
  initialAgendaRepetir: IAgendaRepetir,
  dataService: IAgendaRepetirService
) => {
  const [data, setData] = useState<IAgendaRepetir>(initialAgendaRepetir);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAgendaRepetir = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAgendaRepetir);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAgendaRepetirById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Agenda Repetir';
      setError(errorMessage);
      console.log('Erro ao carregar Agenda Repetir');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAgendaRepetir]);

  const resetForm = useCallback(() => {
    setData(initialAgendaRepetir);
    setError(null);
  }, [initialAgendaRepetir]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAgendaRepetir,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAgendaRepetir, resetForm]);
  return returnValue;
};


export const useAgendaRepetirNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AgendaRepetir', (entity) => {
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


export const useAgendaRepetirList = (dataService: IAgendaRepetirService) => {
  const [data, setData] = useState<IAgendaRepetir[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar agendarepetir';
      setError(errorMessage);
      console.log('Erro ao carregar agendarepetir');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAgendaRepetirNotifications(
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


export function useValidationsAgendaRepetir() {
  function validate(data: IAgendaRepetir): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.mensagem.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Mensagem não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}