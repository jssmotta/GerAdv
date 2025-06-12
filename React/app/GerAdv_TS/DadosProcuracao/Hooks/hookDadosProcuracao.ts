'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IDadosProcuracaoService } from '../Services/DadosProcuracao.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IDadosProcuracao } from '../Interfaces/interface.DadosProcuracao';
import { isValidDate } from '@/app/tools/datetime';

export const useDadosProcuracaoForm = (
  initialDadosProcuracao: IDadosProcuracao,
  dataService: IDadosProcuracaoService
) => {
  const [data, setData] = useState<IDadosProcuracao>(initialDadosProcuracao);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadDadosProcuracao = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialDadosProcuracao);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchDadosProcuracaoById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Dados Procuracao';
      setError(errorMessage);
      console.log('Erro ao carregar Dados Procuracao');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialDadosProcuracao]);

  const resetForm = useCallback(() => {
    setData(initialDadosProcuracao);
    setError(null);
  }, [initialDadosProcuracao]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadDadosProcuracao,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadDadosProcuracao, resetForm]);
  return returnValue;
};


export const useDadosProcuracaoNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('DadosProcuracao', (entity) => {
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


export const useDadosProcuracaoList = (dataService: IDadosProcuracaoService) => {
  const [data, setData] = useState<IDadosProcuracao[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar dadosprocuracao';
      setError(errorMessage);
      console.log('Erro ao carregar dadosprocuracao');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useDadosProcuracaoNotifications(
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


export function useValidationsDadosProcuracao() {
  function validate(data: IDadosProcuracao): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.estadocivil.length > 100) { 
                                             return { isValid: false, message: 'O campo EstadoCivil não pode ter mais de 100 caracteres.' };
                                         } 
if (data.nacionalidade.length > 100) { 
                                             return { isValid: false, message: 'O campo Nacionalidade não pode ter mais de 100 caracteres.' };
                                         } 
if (data.profissao.length > 100) { 
                                             return { isValid: false, message: 'O campo Profissao não pode ter mais de 100 caracteres.' };
                                         } 
if (data.ctps.length > 100) { 
                                             return { isValid: false, message: 'O campo CTPS não pode ter mais de 100 caracteres.' };
                                         } 
if (data.pispasep.length > 100) { 
                                             return { isValid: false, message: 'O campo PisPasep não pode ter mais de 100 caracteres.' };
                                         } 
if (data.remuneracao.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Remuneracao não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.objeto.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Objeto não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}