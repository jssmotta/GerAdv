'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IClientesService } from '../Services/Clientes.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IClientes } from '../Interfaces/interface.Clientes';
import { isValidDate } from '@/app/tools/datetime';

export const useClientesForm = (
  initialClientes: IClientes,
  dataService: IClientesService
) => {
  const [data, setData] = useState<IClientes>(initialClientes);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadClientes = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialClientes);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchClientesById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Clientes';
      setError(errorMessage);
      console.log('Erro ao carregar Clientes');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialClientes]);

  const resetForm = useCallback(() => {
    setData(initialClientes);
    setError(null);
  }, [initialClientes]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadClientes,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadClientes, resetForm]);
  return returnValue;
};


export const useClientesNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Clientes', (entity) => {
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


export const useClientesList = (dataService: IClientesService) => {
  const [data, setData] = useState<IClientes[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar clientes';
      setError(errorMessage);
      console.log('Erro ao carregar clientes');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useClientesNotifications(
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


export function useValidationsClientes() {
  function validate(data: IClientes): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.icone.length > 255) { 
                                             return { isValid: false, message: 'O campo Icone não pode ter mais de 255 caracteres.' };
                                         } 
if (data.nomemae.length > 80) { 
                                             return { isValid: false, message: 'O campo NomeMae não pode ter mais de 80 caracteres.' };
                                         } 
if (data.quemindicou.length > 80) { 
                                             return { isValid: false, message: 'O campo QuemIndicou não pode ter mais de 80 caracteres.' };
                                         } 
if (data.nome.length > 80) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 80 caracteres.' };
                                         } 
if (data.nomefantasia.length > 80) { 
                                             return { isValid: false, message: 'O campo NomeFantasia não pode ter mais de 80 caracteres.' };
                                         } 
if (data.class.length > 1) { 
                                             return { isValid: false, message: 'O campo Class não pode ter mais de 1 caracteres.' };
                                         } 
if (data.inscest.length > 15) { 
                                             return { isValid: false, message: 'O campo InscEst não pode ter mais de 15 caracteres.' };
                                         } 
if (data.qualificacao.length > 100) { 
                                             return { isValid: false, message: 'O campo Qualificacao não pode ter mais de 100 caracteres.' };
                                         } 
if (data.rg.length > 50) { 
                                             return { isValid: false, message: 'O campo RG não pode ter mais de 50 caracteres.' };
                                         } 
if (data.observacao.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Observacao não pode ter mais de 2147483647 caracteres.' };
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
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.homepage.length > 60) { 
                                             return { isValid: false, message: 'O campo HomePage não pode ter mais de 60 caracteres.' };
                                         } 
if (data.email.length > 255) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 255 caracteres.' };
                                         } 
if (data.nomepai.length > 80) { 
                                             return { isValid: false, message: 'O campo NomePai não pode ter mais de 80 caracteres.' };
                                         } 
if (data.rgoexpeditor.length > 30) { 
                                             return { isValid: false, message: 'O campo RGOExpeditor não pode ter mais de 30 caracteres.' };
                                         } 
if (data.cnh.length > 100) { 
                                             return { isValid: false, message: 'O campo CNH não pode ter mais de 100 caracteres.' };
                                         } 
if (data.pessoacontato.length > 120) { 
                                             return { isValid: false, message: 'O campo PessoaContato não pode ter mais de 120 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}export const useClientesComboBox = (
  dataService: IClientesService,
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

  useClientesNotifications(
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