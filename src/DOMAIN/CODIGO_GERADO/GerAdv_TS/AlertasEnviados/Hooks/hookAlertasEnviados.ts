'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAlertasEnviadosService } from '../Services/AlertasEnviados.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAlertasEnviados } from '../Interfaces/interface.AlertasEnviados';
import { isValidDate } from '@/app/tools/datetime';
import { AlertasEnviadosApi } from '../Apis/ApiAlertasEnviados';

export const useAlertasEnviadosForm = (
  initialAlertasEnviados: IAlertasEnviados,
  dataService: IAlertasEnviadosService
) => {
  const [data, setData] = useState<IAlertasEnviados>(initialAlertasEnviados);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAlertasEnviados = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAlertasEnviados);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAlertasEnviadosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Alertas Enviados';
      setError(errorMessage);
      console.log('Erro ao carregar Alertas Enviados');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAlertasEnviados]);

  const resetForm = useCallback(() => {
    setData(initialAlertasEnviados);
    setError(null);
  }, [initialAlertasEnviados]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAlertasEnviados,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAlertasEnviados, resetForm]);
  return returnValue;
};


export const useAlertasEnviadosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AlertasEnviados', (entity) => {
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


export const useAlertasEnviadosList = (dataService: IAlertasEnviadosService) => {
  const [data, setData] = useState<IAlertasEnviados[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar alertasenviados';
      setError(errorMessage);
      console.log('Erro ao carregar alertasenviados');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAlertasEnviadosNotifications(
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


export function useValidationsAlertasEnviados() {

  async function runValidation(data: IAlertasEnviados, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const alertasenviadosApi = new AlertasEnviadosApi(uri ?? '', token ?? '');

    const result = await alertasenviadosApi.validation(data);

    return result;
  }

  function validate(data: IAlertasEnviados): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}