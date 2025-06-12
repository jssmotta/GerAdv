'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { ILivroCaixaClientesService } from '../Services/LivroCaixaClientes.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { ILivroCaixaClientes } from '../Interfaces/interface.LivroCaixaClientes';
import { isValidDate } from '@/app/tools/datetime';

export const useLivroCaixaClientesForm = (
  initialLivroCaixaClientes: ILivroCaixaClientes,
  dataService: ILivroCaixaClientesService
) => {
  const [data, setData] = useState<ILivroCaixaClientes>(initialLivroCaixaClientes);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadLivroCaixaClientes = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialLivroCaixaClientes);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchLivroCaixaClientesById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Livro Caixa Clientes';
      setError(errorMessage);
      console.log('Erro ao carregar Livro Caixa Clientes');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialLivroCaixaClientes]);

  const resetForm = useCallback(() => {
    setData(initialLivroCaixaClientes);
    setError(null);
  }, [initialLivroCaixaClientes]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadLivroCaixaClientes,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadLivroCaixaClientes, resetForm]);
  return returnValue;
};


export const useLivroCaixaClientesNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('LivroCaixaClientes', (entity) => {
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


export const useLivroCaixaClientesList = (dataService: ILivroCaixaClientesService) => {
  const [data, setData] = useState<ILivroCaixaClientes[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar livrocaixaclientes';
      setError(errorMessage);
      console.log('Erro ao carregar livrocaixaclientes');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useLivroCaixaClientesNotifications(
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


export function useValidationsLivroCaixaClientes() {
  function validate(data: ILivroCaixaClientes): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        


        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}