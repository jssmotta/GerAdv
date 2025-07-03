'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IStatusBiuService } from '../Services/StatusBiu.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IStatusBiu } from '../Interfaces/interface.StatusBiu';
import { isValidDate } from '@/app/tools/datetime';
import { StatusBiuApi } from '../Apis/ApiStatusBiu';

export const useStatusBiuForm = (
  initialStatusBiu: IStatusBiu,
  dataService: IStatusBiuService
) => {
  const [data, setData] = useState<IStatusBiu>(initialStatusBiu);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadStatusBiu = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialStatusBiu);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchStatusBiuById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Status Biu';
      setError(errorMessage);
      console.log('Erro ao carregar Status Biu');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialStatusBiu]);

  const resetForm = useCallback(() => {
    setData(initialStatusBiu);
    setError(null);
  }, [initialStatusBiu]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadStatusBiu,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadStatusBiu, resetForm]);
  return returnValue;
};


export const useStatusBiuNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('StatusBiu', (entity) => {
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


export const useStatusBiuList = (dataService: IStatusBiuService) => {
  const [data, setData] = useState<IStatusBiu[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar statusbiu';
      setError(errorMessage);
      console.log('Erro ao carregar statusbiu');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useStatusBiuNotifications(
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


export function useValidationsStatusBiu() {

  async function runValidation(data: IStatusBiu, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const statusbiuApi = new StatusBiuApi(uri ?? '', token ?? '');

    const result = await statusbiuApi.validation(data);

    return result;
  }

  function validate(data: IStatusBiu): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.nome.length > 1024) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 1024 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useStatusBiuComboBox = (
  dataService: IStatusBiuService,
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

  useStatusBiuNotifications(
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