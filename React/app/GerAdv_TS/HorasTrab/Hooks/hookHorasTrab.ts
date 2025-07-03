'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IHorasTrabService } from '../Services/HorasTrab.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IHorasTrab } from '../Interfaces/interface.HorasTrab';
import { isValidDate } from '@/app/tools/datetime';
import { HorasTrabApi } from '../Apis/ApiHorasTrab';

export const useHorasTrabForm = (
  initialHorasTrab: IHorasTrab,
  dataService: IHorasTrabService
) => {
  const [data, setData] = useState<IHorasTrab>(initialHorasTrab);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadHorasTrab = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialHorasTrab);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchHorasTrabById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Horas Trab';
      setError(errorMessage);
      console.log('Erro ao carregar Horas Trab');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialHorasTrab]);

  const resetForm = useCallback(() => {
    setData(initialHorasTrab);
    setError(null);
  }, [initialHorasTrab]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadHorasTrab,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadHorasTrab, resetForm]);
  return returnValue;
};


export const useHorasTrabNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('HorasTrab', (entity) => {
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


export const useHorasTrabList = (dataService: IHorasTrabService) => {
  const [data, setData] = useState<IHorasTrab[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar horastrab';
      setError(errorMessage);
      console.log('Erro ao carregar horastrab');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useHorasTrabNotifications(
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


export function useValidationsHorasTrab() {

  async function runValidation(data: IHorasTrab, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const horastrabApi = new HorasTrabApi(uri ?? '', token ?? '');

    const result = await horastrabApi.validation(data);

    return result;
  }

  function validate(data: IHorasTrab): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.hrini.length > 5) { 
                                             return { isValid: false, message: 'O campo HrIni não pode ter mais de 5 caracteres.' };
                                         } 
if (data.hrfim.length > 5) { 
                                             return { isValid: false, message: 'O campo HrFim não pode ter mais de 5 caracteres.' };
                                         } 
if (data.obs.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo OBS não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.anexo.length > 255) { 
                                             return { isValid: false, message: 'O campo Anexo não pode ter mais de 255 caracteres.' };
                                         } 
if (data.anexocomp.length > 50) { 
                                             return { isValid: false, message: 'O campo AnexoComp não pode ter mais de 50 caracteres.' };
                                         } 
if (data.anexounc.length > 255) { 
                                             return { isValid: false, message: 'O campo AnexoUNC não pode ter mais de 255 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}