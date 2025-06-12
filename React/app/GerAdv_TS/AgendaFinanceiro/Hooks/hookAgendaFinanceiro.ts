'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAgendaFinanceiroService } from '../Services/AgendaFinanceiro.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAgendaFinanceiro } from '../Interfaces/interface.AgendaFinanceiro';
import { isValidDate } from '@/app/tools/datetime';

export const useAgendaFinanceiroForm = (
  initialAgendaFinanceiro: IAgendaFinanceiro,
  dataService: IAgendaFinanceiroService
) => {
  const [data, setData] = useState<IAgendaFinanceiro>(initialAgendaFinanceiro);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAgendaFinanceiro = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAgendaFinanceiro);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAgendaFinanceiroById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Agenda Financeiro';
      setError(errorMessage);
      console.log('Erro ao carregar Agenda Financeiro');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAgendaFinanceiro]);

  const resetForm = useCallback(() => {
    setData(initialAgendaFinanceiro);
    setError(null);
  }, [initialAgendaFinanceiro]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAgendaFinanceiro,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAgendaFinanceiro, resetForm]);
  return returnValue;
};


export const useAgendaFinanceiroNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AgendaFinanceiro', (entity) => {
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


export const useAgendaFinanceiroList = (dataService: IAgendaFinanceiroService) => {
  const [data, setData] = useState<IAgendaFinanceiro[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar agendafinanceiro';
      setError(errorMessage);
      console.log('Erro ao carregar agendafinanceiro');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAgendaFinanceiroNotifications(
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


export function useValidationsAgendaFinanceiro() {
  function validate(data: IAgendaFinanceiro): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.compromisso.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Compromisso não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.status.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Status não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.compromissohtml.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo CompromissoHTML não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.decisao.length > 2048) { 
                                             return { isValid: false, message: 'O campo Decisao não pode ter mais de 2048 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}