'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IProTipoBaixaService } from '../Services/ProTipoBaixa.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IProTipoBaixa } from '../Interfaces/interface.ProTipoBaixa';
import { isValidDate } from '@/app/tools/datetime';
import { ProTipoBaixaApi } from '../Apis/ApiProTipoBaixa';

export const useProTipoBaixaForm = (
  initialProTipoBaixa: IProTipoBaixa,
  dataService: IProTipoBaixaService
) => {
  const [data, setData] = useState<IProTipoBaixa>(initialProTipoBaixa);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadProTipoBaixa = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialProTipoBaixa);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchProTipoBaixaById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Pro Tipo Baixa';
      setError(errorMessage);
      console.log('Erro ao carregar Pro Tipo Baixa');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialProTipoBaixa]);

  const resetForm = useCallback(() => {
    setData(initialProTipoBaixa);
    setError(null);
  }, [initialProTipoBaixa]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadProTipoBaixa,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadProTipoBaixa, resetForm]);
  return returnValue;
};


export const useProTipoBaixaNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ProTipoBaixa', (entity) => {
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


export const useProTipoBaixaList = (dataService: IProTipoBaixaService) => {
  const [data, setData] = useState<IProTipoBaixa[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar protipobaixa';
      setError(errorMessage);
      console.log('Erro ao carregar protipobaixa');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useProTipoBaixaNotifications(
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


export function useValidationsProTipoBaixa() {

  async function runValidation(data: IProTipoBaixa, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const protipobaixaApi = new ProTipoBaixaApi(uri ?? '', token ?? '');

    const result = await protipobaixaApi.validation(data);

    return result;
  }

  function validate(data: IProTipoBaixa): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.nome.length > 80) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 80 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useProTipoBaixaComboBox = (
  dataService: IProTipoBaixaService,
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

  useProTipoBaixaNotifications(
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