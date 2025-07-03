'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IPosicaoOutrasPartesService } from '../Services/PosicaoOutrasPartes.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IPosicaoOutrasPartes } from '../Interfaces/interface.PosicaoOutrasPartes';
import { isValidDate } from '@/app/tools/datetime';
import { PosicaoOutrasPartesApi } from '../Apis/ApiPosicaoOutrasPartes';

export const usePosicaoOutrasPartesForm = (
  initialPosicaoOutrasPartes: IPosicaoOutrasPartes,
  dataService: IPosicaoOutrasPartesService
) => {
  const [data, setData] = useState<IPosicaoOutrasPartes>(initialPosicaoOutrasPartes);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadPosicaoOutrasPartes = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialPosicaoOutrasPartes);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchPosicaoOutrasPartesById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Posicao Outras Partes';
      setError(errorMessage);
      console.log('Erro ao carregar Posicao Outras Partes');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialPosicaoOutrasPartes]);

  const resetForm = useCallback(() => {
    setData(initialPosicaoOutrasPartes);
    setError(null);
  }, [initialPosicaoOutrasPartes]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadPosicaoOutrasPartes,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadPosicaoOutrasPartes, resetForm]);
  return returnValue;
};


export const usePosicaoOutrasPartesNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('PosicaoOutrasPartes', (entity) => {
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


export const usePosicaoOutrasPartesList = (dataService: IPosicaoOutrasPartesService) => {
  const [data, setData] = useState<IPosicaoOutrasPartes[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar posicaooutraspartes';
      setError(errorMessage);
      console.log('Erro ao carregar posicaooutraspartes');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  usePosicaoOutrasPartesNotifications(
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


export function useValidationsPosicaoOutrasPartes() {

  async function runValidation(data: IPosicaoOutrasPartes, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const posicaooutraspartesApi = new PosicaoOutrasPartesApi(uri ?? '', token ?? '');

    const result = await posicaooutraspartesApi.validation(data);

    return result;
  }

  function validate(data: IPosicaoOutrasPartes): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.descricao.length <= 0) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ficar vazio.' };
                                         } 
if (data.descricao.length > 30) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ter mais de 30 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const usePosicaoOutrasPartesComboBox = (
  dataService: IPosicaoOutrasPartesService,
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

  usePosicaoOutrasPartesNotifications(
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