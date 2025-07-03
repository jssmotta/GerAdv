'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { ITiposAcaoService } from '../Services/TiposAcao.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { ITiposAcao } from '../Interfaces/interface.TiposAcao';
import { isValidDate } from '@/app/tools/datetime';
import { TiposAcaoApi } from '../Apis/ApiTiposAcao';

export const useTiposAcaoForm = (
  initialTiposAcao: ITiposAcao,
  dataService: ITiposAcaoService
) => {
  const [data, setData] = useState<ITiposAcao>(initialTiposAcao);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadTiposAcao = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialTiposAcao);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchTiposAcaoById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Tipos Acao';
      setError(errorMessage);
      console.log('Erro ao carregar Tipos Acao');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialTiposAcao]);

  const resetForm = useCallback(() => {
    setData(initialTiposAcao);
    setError(null);
  }, [initialTiposAcao]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadTiposAcao,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadTiposAcao, resetForm]);
  return returnValue;
};


export const useTiposAcaoNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('TiposAcao', (entity) => {
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


export const useTiposAcaoList = (dataService: ITiposAcaoService) => {
  const [data, setData] = useState<ITiposAcao[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar tiposacao';
      setError(errorMessage);
      console.log('Erro ao carregar tiposacao');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useTiposAcaoNotifications(
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


export function useValidationsTiposAcao() {

  async function runValidation(data: ITiposAcao, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const tiposacaoApi = new TiposAcaoApi(uri ?? '', token ?? '');

    const result = await tiposacaoApi.validation(data);

    return result;
  }

  function validate(data: ITiposAcao): { isValid: boolean; message: string } {
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
}export const useTiposAcaoComboBox = (
  dataService: ITiposAcaoService,
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

  useTiposAcaoNotifications(
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