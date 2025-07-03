'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IFornecedoresService } from '../Services/Fornecedores.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IFornecedores } from '../Interfaces/interface.Fornecedores';
import { isValidDate } from '@/app/tools/datetime';
import { FornecedoresApi } from '../Apis/ApiFornecedores';

export const useFornecedoresForm = (
  initialFornecedores: IFornecedores,
  dataService: IFornecedoresService
) => {
  const [data, setData] = useState<IFornecedores>(initialFornecedores);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadFornecedores = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialFornecedores);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchFornecedoresById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Fornecedor';
      setError(errorMessage);
      console.log('Erro ao carregar Fornecedor');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialFornecedores]);

  const resetForm = useCallback(() => {
    setData(initialFornecedores);
    setError(null);
  }, [initialFornecedores]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadFornecedores,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadFornecedores, resetForm]);
  return returnValue;
};


export const useFornecedoresNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Fornecedores', (entity) => {
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


export const useFornecedoresList = (dataService: IFornecedoresService) => {
  const [data, setData] = useState<IFornecedores[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar fornecedores';
      setError(errorMessage);
      console.log('Erro ao carregar fornecedores');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useFornecedoresNotifications(
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


export function useValidationsFornecedores() {

  async function runValidation(data: IFornecedores, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const fornecedoresApi = new FornecedoresApi(uri ?? '', token ?? '');

    const result = await fornecedoresApi.validation(data);

    return result;
  }

  function validate(data: IFornecedores): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.nome.length > 80) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 80 caracteres.' };
                                         } 
if (data.inscest.length > 15) { 
                                             return { isValid: false, message: 'O campo InscEst não pode ter mais de 15 caracteres.' };
                                         } 
if (data.rg.length > 30) { 
                                             return { isValid: false, message: 'O campo RG não pode ter mais de 30 caracteres.' };
                                         } 
if (data.endereco.length > 80) { 
                                             return { isValid: false, message: 'O campo Endereco não pode ter mais de 80 caracteres.' };
                                         } 
if (data.bairro.length > 50) { 
                                             return { isValid: false, message: 'O campo Bairro não pode ter mais de 50 caracteres.' };
                                         } 
if (data.cep.length > 10) { 
                                             return { isValid: false, message: 'O campo CEP não pode ter mais de 10 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.email.length > 150) { 
                                             return { isValid: false, message: 'O campo Email não pode ter mais de 150 caracteres.' };
                                         } 
if (data.site.length > 150) { 
                                             return { isValid: false, message: 'O campo Site não pode ter mais de 150 caracteres.' };
                                         } 
if (data.obs.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Obs não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.produtos.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Produtos não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.contatos.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Contatos não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useFornecedoresComboBox = (
  dataService: IFornecedoresService,
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

  useFornecedoresNotifications(
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