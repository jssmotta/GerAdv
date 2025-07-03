'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IPontoVirtualAcessosService } from '../Services/PontoVirtualAcessos.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IPontoVirtualAcessos } from '../Interfaces/interface.PontoVirtualAcessos';
import { isValidDate } from '@/app/tools/datetime';
import { PontoVirtualAcessosApi } from '../Apis/ApiPontoVirtualAcessos';

export const usePontoVirtualAcessosForm = (
  initialPontoVirtualAcessos: IPontoVirtualAcessos,
  dataService: IPontoVirtualAcessosService
) => {
  const [data, setData] = useState<IPontoVirtualAcessos>(initialPontoVirtualAcessos);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadPontoVirtualAcessos = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialPontoVirtualAcessos);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchPontoVirtualAcessosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Ponto Virtual Acessos';
      setError(errorMessage);
      console.log('Erro ao carregar Ponto Virtual Acessos');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialPontoVirtualAcessos]);

  const resetForm = useCallback(() => {
    setData(initialPontoVirtualAcessos);
    setError(null);
  }, [initialPontoVirtualAcessos]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadPontoVirtualAcessos,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadPontoVirtualAcessos, resetForm]);
  return returnValue;
};


export const usePontoVirtualAcessosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('PontoVirtualAcessos', (entity) => {
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


export const usePontoVirtualAcessosList = (dataService: IPontoVirtualAcessosService) => {
  const [data, setData] = useState<IPontoVirtualAcessos[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar pontovirtualacessos';
      setError(errorMessage);
      console.log('Erro ao carregar pontovirtualacessos');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  usePontoVirtualAcessosNotifications(
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


export function useValidationsPontoVirtualAcessos() {

  async function runValidation(data: IPontoVirtualAcessos, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const pontovirtualacessosApi = new PontoVirtualAcessosApi(uri ?? '', token ?? '');

    const result = await pontovirtualacessosApi.validation(data);

    return result;
  }

  function validate(data: IPontoVirtualAcessos): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.origem.length > 150) { 
                                             return { isValid: false, message: 'O campo Origem não pode ter mais de 150 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}