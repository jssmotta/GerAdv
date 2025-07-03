'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { ITribEnderecosService } from '../Services/TribEnderecos.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { ITribEnderecos } from '../Interfaces/interface.TribEnderecos';
import { isValidDate } from '@/app/tools/datetime';
import { TribEnderecosApi } from '../Apis/ApiTribEnderecos';

export const useTribEnderecosForm = (
  initialTribEnderecos: ITribEnderecos,
  dataService: ITribEnderecosService
) => {
  const [data, setData] = useState<ITribEnderecos>(initialTribEnderecos);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadTribEnderecos = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialTribEnderecos);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchTribEnderecosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Trib Endereços';
      setError(errorMessage);
      console.log('Erro ao carregar Trib Endereços');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialTribEnderecos]);

  const resetForm = useCallback(() => {
    setData(initialTribEnderecos);
    setError(null);
  }, [initialTribEnderecos]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadTribEnderecos,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadTribEnderecos, resetForm]);
  return returnValue;
};


export const useTribEnderecosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('TribEnderecos', (entity) => {
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


export const useTribEnderecosList = (dataService: ITribEnderecosService) => {
  const [data, setData] = useState<ITribEnderecos[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar tribenderecos';
      setError(errorMessage);
      console.log('Erro ao carregar tribenderecos');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useTribEnderecosNotifications(
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


export function useValidationsTribEnderecos() {

  async function runValidation(data: ITribEnderecos, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const tribenderecosApi = new TribEnderecosApi(uri ?? '', token ?? '');

    const result = await tribenderecosApi.validation(data);

    return result;
  }

  function validate(data: ITribEnderecos): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.endereco.length > 80) { 
                                             return { isValid: false, message: 'O campo Endereco não pode ter mais de 80 caracteres.' };
                                         } 
if (data.cep.length > 10) { 
                                             return { isValid: false, message: 'O campo CEP não pode ter mais de 10 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.obs.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo OBS não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}