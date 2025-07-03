'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAreaService } from '../Services/Area.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IArea } from '../Interfaces/interface.Area';
import { isValidDate } from '@/app/tools/datetime';
import { AreaApi } from '../Apis/ApiArea';

export const useAreaForm = (
  initialArea: IArea,
  dataService: IAreaService
) => {
  const [data, setData] = useState<IArea>(initialArea);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadArea = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialArea);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAreaById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Area';
      setError(errorMessage);
      console.log('Erro ao carregar Area');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialArea]);

  const resetForm = useCallback(() => {
    setData(initialArea);
    setError(null);
  }, [initialArea]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadArea,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadArea, resetForm]);
  return returnValue;
};


export const useAreaNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Area', (entity) => {
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


export const useAreaList = (dataService: IAreaService) => {
  const [data, setData] = useState<IArea[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar area';
      setError(errorMessage);
      console.log('Erro ao carregar area');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAreaNotifications(
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


export function useValidationsArea() {

  async function runValidation(data: IArea, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const areaApi = new AreaApi(uri ?? '', token ?? '');

    const result = await areaApi.validation(data);

    return result;
  }

  function validate(data: IArea): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.descricao.length <= 0) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ficar vazio.' };
                                         } 
if (data.descricao.length > 40) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ter mais de 40 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useAreaComboBox = (
  dataService: IAreaService,
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

  useAreaNotifications(
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