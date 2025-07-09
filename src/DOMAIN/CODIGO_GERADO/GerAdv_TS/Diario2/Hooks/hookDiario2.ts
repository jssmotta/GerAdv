'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IDiario2Service } from '../Services/Diario2.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IDiario2 } from '../Interfaces/interface.Diario2';
import { isValidDate } from '@/app/tools/datetime';
import { Diario2Api } from '../Apis/ApiDiario2';

export const useDiario2Form = (
  initialDiario2: IDiario2,
  dataService: IDiario2Service
) => {
  const [data, setData] = useState<IDiario2>(initialDiario2);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadDiario2 = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialDiario2);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchDiario2ById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Diário';
      setError(errorMessage);
      console.log('Erro ao carregar Diário');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialDiario2]);

  const resetForm = useCallback(() => {
    setData(initialDiario2);
    setError(null);
  }, [initialDiario2]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadDiario2,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadDiario2, resetForm]);
  return returnValue;
};


export const useDiario2Notifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Diario2', (entity) => {
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


export const useDiario2List = (dataService: IDiario2Service) => {
  const [data, setData] = useState<IDiario2[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar diario2';
      setError(errorMessage);
      console.log('Erro ao carregar diario2');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useDiario2Notifications(
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


export function useValidationsDiario2() {

  async function runValidation(data: IDiario2, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const diario2Api = new Diario2Api(uri ?? '', token ?? '');

    const result = await diario2Api.validation(data);

    return result;
  }

  function validate(data: IDiario2): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.nome.length > 150) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 150 caracteres.' };
                                         } 
if (data.ocorrencia.length > 2048) { 
                                             return { isValid: false, message: 'O campo Ocorrencia não pode ter mais de 2048 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useDiario2ComboBox = (
  dataService: IDiario2Service,
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
        nome: item.nome
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

  useDiario2Notifications(
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