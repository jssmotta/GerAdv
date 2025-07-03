'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IParteClienteOutrasService } from '../Services/ParteClienteOutras.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IParteClienteOutras } from '../Interfaces/interface.ParteClienteOutras';
import { isValidDate } from '@/app/tools/datetime';
import { ParteClienteOutrasApi } from '../Apis/ApiParteClienteOutras';

export const useParteClienteOutrasForm = (
  initialParteClienteOutras: IParteClienteOutras,
  dataService: IParteClienteOutrasService
) => {
  const [data, setData] = useState<IParteClienteOutras>(initialParteClienteOutras);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadParteClienteOutras = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialParteClienteOutras);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchParteClienteOutrasById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Parte Cliente Outras';
      setError(errorMessage);
      console.log('Erro ao carregar Parte Cliente Outras');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialParteClienteOutras]);

  const resetForm = useCallback(() => {
    setData(initialParteClienteOutras);
    setError(null);
  }, [initialParteClienteOutras]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadParteClienteOutras,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadParteClienteOutras, resetForm]);
  return returnValue;
};


export const useParteClienteOutrasNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ParteClienteOutras', (entity) => {
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


export const useParteClienteOutrasList = (dataService: IParteClienteOutrasService) => {
  const [data, setData] = useState<IParteClienteOutras[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar parteclienteoutras';
      setError(errorMessage);
      console.log('Erro ao carregar parteclienteoutras');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useParteClienteOutrasNotifications(
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


export function useValidationsParteClienteOutras() {

  async function runValidation(data: IParteClienteOutras, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const parteclienteoutrasApi = new ParteClienteOutrasApi(uri ?? '', token ?? '');

    const result = await parteclienteoutrasApi.validation(data);

    return result;
  }

  function validate(data: IParteClienteOutras): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}