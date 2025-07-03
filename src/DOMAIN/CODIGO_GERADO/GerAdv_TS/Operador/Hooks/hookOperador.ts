'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IOperadorService } from '../Services/Operador.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IOperador } from '../Interfaces/interface.Operador';
import { isValidDate } from '@/app/tools/datetime';
import { OperadorApi } from '../Apis/ApiOperador';

export const useOperadorForm = (
  initialOperador: IOperador,
  dataService: IOperadorService
) => {
  const [data, setData] = useState<IOperador>(initialOperador);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadOperador = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialOperador);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchOperadorById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Operador';
      setError(errorMessage);
      console.log('Erro ao carregar Operador');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialOperador]);

  const resetForm = useCallback(() => {
    setData(initialOperador);
    setError(null);
  }, [initialOperador]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadOperador,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadOperador, resetForm]);
  return returnValue;
};


export const useOperadorNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Operador', (entity) => {
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


export const useOperadorList = (dataService: IOperadorService) => {
  const [data, setData] = useState<IOperador[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar operador';
      setError(errorMessage);
      console.log('Erro ao carregar operador');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useOperadorNotifications(
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


export function useValidationsOperador() {

  async function runValidation(data: IOperador, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const operadorApi = new OperadorApi(uri ?? '', token ?? '');

    const result = await operadorApi.validation(data);

    return result;
  }

  function validate(data: IOperador): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.email.length > 150) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 150 caracteres.' };
                                         } 
if (data.pasta.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Pasta não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.nome.length > 40) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 40 caracteres.' };
                                         } 
if (data.nick.length > 50) { 
                                             return { isValid: false, message: 'O campo Nick não pode ter mais de 50 caracteres.' };
                                         } 
if (data.minhadescricao.length > 255) { 
                                             return { isValid: false, message: 'O campo MinhaDescricao não pode ter mais de 255 caracteres.' };
                                         } 
if (data.emailnet.length > 100) { 
                                             return { isValid: false, message: 'O campo EMailNet não pode ter mais de 100 caracteres.' };
                                         } 
if (data.senha256.length > 4000) { 
                                             return { isValid: false, message: 'O campo Senha256 não pode ter mais de 4000 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useOperadorComboBox = (
  dataService: IOperadorService,
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

  useOperadorNotifications(
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