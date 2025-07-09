'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IFuncionariosService } from '../Services/Funcionarios.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IFuncionarios } from '../Interfaces/interface.Funcionarios';
import { isValidDate } from '@/app/tools/datetime';
import { FuncionariosApi } from '../Apis/ApiFuncionarios';

export const useFuncionariosForm = (
  initialFuncionarios: IFuncionarios,
  dataService: IFuncionariosService
) => {
  const [data, setData] = useState<IFuncionarios>(initialFuncionarios);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadFuncionarios = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialFuncionarios);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchFuncionariosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Colaborador';
      setError(errorMessage);
      console.log('Erro ao carregar Colaborador');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialFuncionarios]);

  const resetForm = useCallback(() => {
    setData(initialFuncionarios);
    setError(null);
  }, [initialFuncionarios]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadFuncionarios,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadFuncionarios, resetForm]);
  return returnValue;
};


export const useFuncionariosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Funcionarios', (entity) => {
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


export const useFuncionariosList = (dataService: IFuncionariosService) => {
  const [data, setData] = useState<IFuncionarios[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar funcionarios';
      setError(errorMessage);
      console.log('Erro ao carregar funcionarios');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useFuncionariosNotifications(
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


export function useValidationsFuncionarios() {

  async function runValidation(data: IFuncionarios, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const funcionariosApi = new FuncionariosApi(uri ?? '', token ?? '');

    const result = await funcionariosApi.validation(data);

    return result;
  }

  function validate(data: IFuncionarios): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.emailpro.length > 255) { 
                                             return { isValid: false, message: 'O campo EMailPro não pode ter mais de 255 caracteres.' };
                                         } 
if (data.nome.length > 60) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 60 caracteres.' };
                                         } 
if (data.registro.length > 20) { 
                                             return { isValid: false, message: 'O campo Registro não pode ter mais de 20 caracteres.' };
                                         } 
if (data.rg.length > 30) { 
                                             return { isValid: false, message: 'O campo RG não pode ter mais de 30 caracteres.' };
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
if (data.contato.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Contato não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.email.length > 60) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 60 caracteres.' };
                                         } 
if (data.ctpsnumero.length > 15) { 
                                             return { isValid: false, message: 'O campo CTPSNumero não pode ter mais de 15 caracteres.' };
                                         } 
if (data.ctpsserie.length > 10) { 
                                             return { isValid: false, message: 'O campo CTPSSerie não pode ter mais de 10 caracteres.' };
                                         } 
if (data.pis.length > 20) { 
                                             return { isValid: false, message: 'O campo PIS não pode ter mais de 20 caracteres.' };
                                         } 
if (data.pasta.length > 200) { 
                                             return { isValid: false, message: 'O campo Pasta não pode ter mais de 200 caracteres.' };
                                         } 
if (data.class.length > 1) { 
                                             return { isValid: false, message: 'O campo Class não pode ter mais de 1 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

 return { validate, runValidation };
}export const useFuncionariosComboBox = (
  dataService: IFuncionariosService,
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

  useFuncionariosNotifications(
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