'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IDivisaoTribunalService } from '../Services/DivisaoTribunal.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IDivisaoTribunal } from '../Interfaces/interface.DivisaoTribunal';
import { isValidDate } from '@/app/tools/datetime';
import { DivisaoTribunalApi } from '../Apis/ApiDivisaoTribunal';

export const useDivisaoTribunalForm = (
  initialDivisaoTribunal: IDivisaoTribunal,
  dataService: IDivisaoTribunalService
) => {
  const [data, setData] = useState<IDivisaoTribunal>(initialDivisaoTribunal);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadDivisaoTribunal = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialDivisaoTribunal);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchDivisaoTribunalById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Divisao Tribunal';
      setError(errorMessage);
      console.log('Erro ao carregar Divisao Tribunal');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialDivisaoTribunal]);

  const resetForm = useCallback(() => {
    setData(initialDivisaoTribunal);
    setError(null);
  }, [initialDivisaoTribunal]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadDivisaoTribunal,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadDivisaoTribunal, resetForm]);
  return returnValue;
};


export const useDivisaoTribunalNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('DivisaoTribunal', (entity) => {
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


export const useDivisaoTribunalList = (dataService: IDivisaoTribunalService) => {
  const [data, setData] = useState<IDivisaoTribunal[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar divisaotribunal';
      setError(errorMessage);
      console.log('Erro ao carregar divisaotribunal');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useDivisaoTribunalNotifications(
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


export function useValidationsDivisaoTribunal() {

  async function runValidation(data: IDivisaoTribunal, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const divisaotribunalApi = new DivisaoTribunalApi(uri ?? '', token ?? '');

    const result = await divisaotribunalApi.validation(data);

    return result;
  }

  function validate(data: IDivisaoTribunal): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nomeespecial.length > 255) { 
                                             return { isValid: false, message: 'O campo NomeEspecial não pode ter mais de 255 caracteres.' };
                                         } 
if (data.codigodiv.length > 5) { 
                                             return { isValid: false, message: 'O campo CodigoDiv não pode ter mais de 5 caracteres.' };
                                         } 
if (data.endereco.length > 40) { 
                                             return { isValid: false, message: 'O campo Endereco não pode ter mais de 40 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.cep.length > 10) { 
                                             return { isValid: false, message: 'O campo CEP não pode ter mais de 10 caracteres.' };
                                         } 
if (data.obs.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Obs não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.email.length > 150) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 150 caracteres.' };
                                         } 
if (data.andar.length > 12) { 
                                             return { isValid: false, message: 'O campo Andar não pode ter mais de 12 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}