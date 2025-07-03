'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IRecadosService } from '../Services/Recados.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IRecados } from '../Interfaces/interface.Recados';
import { isValidDate } from '@/app/tools/datetime';
import { RecadosApi } from '../Apis/ApiRecados';

export const useRecadosForm = (
  initialRecados: IRecados,
  dataService: IRecadosService
) => {
  const [data, setData] = useState<IRecados>(initialRecados);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadRecados = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialRecados);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchRecadosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Recados';
      setError(errorMessage);
      console.log('Erro ao carregar Recados');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialRecados]);

  const resetForm = useCallback(() => {
    setData(initialRecados);
    setError(null);
  }, [initialRecados]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadRecados,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadRecados, resetForm]);
  return returnValue;
};


export const useRecadosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Recados', (entity) => {
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


export const useRecadosList = (dataService: IRecadosService) => {
  const [data, setData] = useState<IRecados[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar recados';
      setError(errorMessage);
      console.log('Erro ao carregar recados');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useRecadosNotifications(
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


export function useValidationsRecados() {

  async function runValidation(data: IRecados, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const recadosApi = new RecadosApi(uri ?? '', token ?? '');

    const result = await recadosApi.validation(data);

    return result;
  }

  function validate(data: IRecados): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.clientenome.length > 255) { 
                                             return { isValid: false, message: 'O campo ClienteNome não pode ter mais de 255 caracteres.' };
                                         } 
if (data.de.length > 50) { 
                                             return { isValid: false, message: 'O campo De não pode ter mais de 50 caracteres.' };
                                         } 
if (data.para.length > 50) { 
                                             return { isValid: false, message: 'O campo Para não pode ter mais de 50 caracteres.' };
                                         } 
if (data.assunto.length > 255) { 
                                             return { isValid: false, message: 'O campo Assunto não pode ter mais de 255 caracteres.' };
                                         } 
if (data.recado.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Recado não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.aguardarretornopara.length > 255) { 
                                             return { isValid: false, message: 'O campo AguardarRetornoPara não pode ter mais de 255 caracteres.' };
                                         } 
if (data.listapara.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo ListaPara não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}