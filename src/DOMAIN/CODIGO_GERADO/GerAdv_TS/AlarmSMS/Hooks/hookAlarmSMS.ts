'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAlarmSMSService } from '../Services/AlarmSMS.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAlarmSMS } from '../Interfaces/interface.AlarmSMS';
import { isValidDate } from '@/app/tools/datetime';
import { AlarmSMSApi } from '../Apis/ApiAlarmSMS';

export const useAlarmSMSForm = (
  initialAlarmSMS: IAlarmSMS,
  dataService: IAlarmSMSService
) => {
  const [data, setData] = useState<IAlarmSMS>(initialAlarmSMS);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAlarmSMS = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAlarmSMS);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAlarmSMSById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Alarm S M S';
      setError(errorMessage);
      console.log('Erro ao carregar Alarm S M S');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAlarmSMS]);

  const resetForm = useCallback(() => {
    setData(initialAlarmSMS);
    setError(null);
  }, [initialAlarmSMS]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAlarmSMS,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAlarmSMS, resetForm]);
  return returnValue;
};


export const useAlarmSMSNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('AlarmSMS', (entity) => {
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


export const useAlarmSMSList = (dataService: IAlarmSMSService) => {
  const [data, setData] = useState<IAlarmSMS[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar alarmsms';
      setError(errorMessage);
      console.log('Erro ao carregar alarmsms');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAlarmSMSNotifications(
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


export function useValidationsAlarmSMS() {

  async function runValidation(data: IAlarmSMS, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const alarmsmsApi = new AlarmSMSApi(uri ?? '', token ?? '');

    const result = await alarmsmsApi.validation(data);

    return result;
  }

  function validate(data: IAlarmSMS): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.descricao.length <= 0) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ficar vazio.' };
                                         } 
if (data.descricao.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.email.length > 50) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 50 caracteres.' };
                                         } 
if (data.guidexo.length > 100) { 
                                             return { isValid: false, message: 'O campo GuidExo não pode ter mais de 100 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useAlarmSMSComboBox = (
  dataService: IAlarmSMSService,
  initialValue?: any
) => {
  const [options, setOptions] = useState<any[]>([]);
  const [filteredOptions, setFilteredOptions] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);
  const [selectedValue, setSelectedValue] = useState(initialValue);
  const [hasLoaded, setHasLoaded] = useState(false);

  const fetchOptions = useCallback(async () => {
    if (loading) return; // Evita múltiplas requisições simultâneas
    
    setLoading(true);
    try {
      const response = await dataService.getList();
      const mappedOptions = response.map(item => ({
        id: item.id,
        nome: item.descricao
      }));
      setOptions(mappedOptions);
      setFilteredOptions(mappedOptions);
      setHasLoaded(true);
    } catch (err) {
      console.log('Erro ao buscar opções do ComboBox');
    } finally {
      setLoading(false);
    }
  }, [dataService, loading]);

  const handleFilter = useCallback((filterText: string) => {
    if (!filterText) {
      setFilteredOptions(options);
      return;
    }
    
    const filter = filterText.toLowerCase();
    const filtered = options.filter(option =>
      option.nome.toLowerCase().includes(filter)
    );
    setFilteredOptions(filtered);
  }, [options]);

  const handleValueChange = useCallback((newValue: any) => {
    setSelectedValue(newValue);
  }, []);
  
  useEffect(() => {
    if (!hasLoaded) {
      fetchOptions();
    }
  }, [fetchOptions, hasLoaded]);

  const refreshCallback = useCallback(() => {
    if (hasLoaded) {
      fetchOptions();
    }
  }, [fetchOptions, hasLoaded]);

  useAlarmSMSNotifications(
    refreshCallback, // onUpdate
    refreshCallback, // onDelete
    refreshCallback  // onAdd
  );

  return {
    options: filteredOptions,
    loading,
    selectedValue,
    handleFilter,
    handleValueChange,
    refreshOptions: fetchOptions,
    clearValue: () => setSelectedValue(null)
  };
};