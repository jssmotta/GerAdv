'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IProcessosService } from '../Services/Processos.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IProcessos } from '../Interfaces/interface.Processos';
import { isValidDate } from '@/app/tools/datetime';
import { ProcessosApi } from '../Apis/ApiProcessos';

export const useProcessosForm = (
  initialProcessos: IProcessos,
  dataService: IProcessosService
) => {
  const [data, setData] = useState<IProcessos>(initialProcessos);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadProcessos = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialProcessos);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchProcessosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Processos';
      setError(errorMessage);
      console.log('Erro ao carregar Processos');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialProcessos]);

  const resetForm = useCallback(() => {
    setData(initialProcessos);
    setError(null);
  }, [initialProcessos]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadProcessos,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadProcessos, resetForm]);
  return returnValue;
};


export const useProcessosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Processos', (entity) => {
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


export const useProcessosList = (dataService: IProcessosService) => {
  const [data, setData] = useState<IProcessos[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar processos';
      setError(errorMessage);
      console.log('Erro ao carregar processos');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useProcessosNotifications(
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


export function useValidationsProcessos() {

  async function runValidation(data: IProcessos, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const processosApi = new ProcessosApi(uri ?? '', token ?? '');

    const result = await processosApi.validation(data);

    return result;
  }

  function validate(data: IProcessos): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nropasta.length <= 0) { 
                                             return { isValid: false, message: 'O campo NroPasta não pode ficar vazio.' };
                                         } 
if (data.obsbcx.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo ObsBCX não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.nroextra.length > 35) { 
                                             return { isValid: false, message: 'O campo NroExtra não pode ter mais de 35 caracteres.' };
                                         } 
if (data.nrocaixa.length > 20) { 
                                             return { isValid: false, message: 'O campo NroCaixa não pode ter mais de 20 caracteres.' };
                                         } 
if (data.fato.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fato não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.nropasta.length > 10) { 
                                             return { isValid: false, message: 'O campo NroPasta não pode ter mais de 10 caracteres.' };
                                         } 
if (data.caixamorto.length > 10) { 
                                             return { isValid: false, message: 'O campo CaixaMorto não pode ter mais de 10 caracteres.' };
                                         } 
if (data.motivobaixa.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo MotivoBaixa não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.obs.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo OBS não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.zkey.length > 20) { 
                                             return { isValid: false, message: 'O campo ZKey não pode ter mais de 20 caracteres.' };
                                         } 
if (data.resumo.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Resumo não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.nrocontrato.length > 100) { 
                                             return { isValid: false, message: 'O campo NroContrato não pode ter mais de 100 caracteres.' };
                                         } 
if (data.percprobexitojustificativa.length > 1024) { 
                                             return { isValid: false, message: 'O campo PercProbExitoJustificativa não pode ter mais de 1024 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}