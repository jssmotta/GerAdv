'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IGUTAtividadesMatrizService } from '../Services/GUTAtividadesMatriz.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IGUTAtividadesMatriz } from '../Interfaces/interface.GUTAtividadesMatriz';
import { isValidDate } from '@/app/tools/datetime';
import { GUTAtividadesMatrizApi } from '../Apis/ApiGUTAtividadesMatriz';

export const useGUTAtividadesMatrizForm = (
  initialGUTAtividadesMatriz: IGUTAtividadesMatriz,
  dataService: IGUTAtividadesMatrizService
) => {
  const [data, setData] = useState<IGUTAtividadesMatriz>(initialGUTAtividadesMatriz);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadGUTAtividadesMatriz = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialGUTAtividadesMatriz);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchGUTAtividadesMatrizById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar G U T Atividades Matriz';
      setError(errorMessage);
      console.log('Erro ao carregar G U T Atividades Matriz');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialGUTAtividadesMatriz]);

  const resetForm = useCallback(() => {
    setData(initialGUTAtividadesMatriz);
    setError(null);
  }, [initialGUTAtividadesMatriz]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadGUTAtividadesMatriz,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadGUTAtividadesMatriz, resetForm]);
  return returnValue;
};


export const useGUTAtividadesMatrizNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('GUTAtividadesMatriz', (entity) => {
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


export const useGUTAtividadesMatrizList = (dataService: IGUTAtividadesMatrizService) => {
  const [data, setData] = useState<IGUTAtividadesMatriz[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar gutatividadesmatriz';
      setError(errorMessage);
      console.log('Erro ao carregar gutatividadesmatriz');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useGUTAtividadesMatrizNotifications(
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


export function useValidationsGUTAtividadesMatriz() {

  async function runValidation(data: IGUTAtividadesMatriz, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const gutatividadesmatrizApi = new GUTAtividadesMatrizApi(uri ?? '', token ?? '');

    const result = await gutatividadesmatrizApi.validation(data);

    return result;
  }

  function validate(data: IGUTAtividadesMatriz): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}