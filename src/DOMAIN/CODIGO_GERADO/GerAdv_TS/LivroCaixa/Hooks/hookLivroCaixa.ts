'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { ILivroCaixaService } from '../Services/LivroCaixa.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { ILivroCaixa } from '../Interfaces/interface.LivroCaixa';
import { isValidDate } from '@/app/tools/datetime';

export const useLivroCaixaForm = (
  initialLivroCaixa: ILivroCaixa,
  dataService: ILivroCaixaService
) => {
  const [data, setData] = useState<ILivroCaixa>(initialLivroCaixa);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadLivroCaixa = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialLivroCaixa);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchLivroCaixaById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Livro Caixa';
      setError(errorMessage);
      console.log('Erro ao carregar Livro Caixa');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialLivroCaixa]);

  const resetForm = useCallback(() => {
    setData(initialLivroCaixa);
    setError(null);
  }, [initialLivroCaixa]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadLivroCaixa,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadLivroCaixa, resetForm]);
  return returnValue;
};


export const useLivroCaixaNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('LivroCaixa', (entity) => {
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


export const useLivroCaixaList = (dataService: ILivroCaixaService) => {
  const [data, setData] = useState<ILivroCaixa[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar livrocaixa';
      setError(errorMessage);
      console.log('Erro ao carregar livrocaixa');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useLivroCaixaNotifications(
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


export function useValidationsLivroCaixa() {
  function validate(data: ILivroCaixa): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.historico.length > 255) { 
                                             return { isValid: false, message: 'O campo Historico não pode ter mais de 255 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}