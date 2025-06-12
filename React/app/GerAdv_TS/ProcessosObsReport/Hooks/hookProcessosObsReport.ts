'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IProcessosObsReportService } from '../Services/ProcessosObsReport.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IProcessosObsReport } from '../Interfaces/interface.ProcessosObsReport';
import { isValidDate } from '@/app/tools/datetime';

export const useProcessosObsReportForm = (
  initialProcessosObsReport: IProcessosObsReport,
  dataService: IProcessosObsReportService
) => {
  const [data, setData] = useState<IProcessosObsReport>(initialProcessosObsReport);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadProcessosObsReport = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialProcessosObsReport);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchProcessosObsReportById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Processos Obs Report';
      setError(errorMessage);
      console.log('Erro ao carregar Processos Obs Report');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialProcessosObsReport]);

  const resetForm = useCallback(() => {
    setData(initialProcessosObsReport);
    setError(null);
  }, [initialProcessosObsReport]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadProcessosObsReport,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadProcessosObsReport, resetForm]);
  return returnValue;
};


export const useProcessosObsReportNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ProcessosObsReport', (entity) => {
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


export const useProcessosObsReportList = (dataService: IProcessosObsReportService) => {
  const [data, setData] = useState<IProcessosObsReport[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar processosobsreport';
      setError(errorMessage);
      console.log('Erro ao carregar processosobsreport');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useProcessosObsReportNotifications(
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


export function useValidationsProcessosObsReport() {
  function validate(data: IProcessosObsReport): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.observacao.length > 2048) { 
                                             return { isValid: false, message: 'O campo Observacao não pode ter mais de 2048 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}