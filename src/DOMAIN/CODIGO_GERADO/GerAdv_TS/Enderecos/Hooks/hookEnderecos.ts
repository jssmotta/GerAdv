'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IEnderecosService } from '../Services/Enderecos.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IEnderecos } from '../Interfaces/interface.Enderecos';
import { isValidDate } from '@/app/tools/datetime';
import { EnderecosApi } from '../Apis/ApiEnderecos';

export const useEnderecosForm = (
  initialEnderecos: IEnderecos,
  dataService: IEnderecosService
) => {
  const [data, setData] = useState<IEnderecos>(initialEnderecos);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadEnderecos = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialEnderecos);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchEnderecosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Endereço';
      setError(errorMessage);
      console.log('Erro ao carregar Endereço');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialEnderecos]);

  const resetForm = useCallback(() => {
    setData(initialEnderecos);
    setError(null);
  }, [initialEnderecos]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadEnderecos,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadEnderecos, resetForm]);
  return returnValue;
};


export const useEnderecosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Enderecos', (entity) => {
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


export const useEnderecosList = (dataService: IEnderecosService) => {
  const [data, setData] = useState<IEnderecos[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar enderecos';
      setError(errorMessage);
      console.log('Erro ao carregar enderecos');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useEnderecosNotifications(
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


export function useValidationsEnderecos() {

  async function runValidation(data: IEnderecos, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const enderecosApi = new EnderecosApi(uri ?? '', token ?? '');

    const result = await enderecosApi.validation(data);

    return result;
  }

  function validate(data: IEnderecos): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.descricao.length <= 0) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ficar vazio.' };
                                         } 
if (data.descricao.length > 50) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ter mais de 50 caracteres.' };
                                         } 
if (data.contato.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Contato não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.endereco.length > 50) { 
                                             return { isValid: false, message: 'O campo Endereco não pode ter mais de 50 caracteres.' };
                                         } 
if (data.bairro.length > 30) { 
                                             return { isValid: false, message: 'O campo Bairro não pode ter mais de 30 caracteres.' };
                                         } 
if (data.cep.length > 10) { 
                                             return { isValid: false, message: 'O campo CEP não pode ter mais de 10 caracteres.' };
                                         } 
if (data.oab.length > 20) { 
                                             return { isValid: false, message: 'O campo OAB não pode ter mais de 20 caracteres.' };
                                         } 
if (data.obs.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo OBS não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.tratamento.length > 20) { 
                                             return { isValid: false, message: 'O campo Tratamento não pode ter mais de 20 caracteres.' };
                                         } 
if (data.site.length > 200) { 
                                             return { isValid: false, message: 'O campo Site não pode ter mais de 200 caracteres.' };
                                         } 
if (data.email.length > 255) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 255 caracteres.' };
                                         } 
if (data.quemindicou.length > 150) { 
                                             return { isValid: false, message: 'O campo QuemIndicou não pode ter mais de 150 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useEnderecosComboBox = (
  dataService: IEnderecosService,
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

  useEnderecosNotifications(
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