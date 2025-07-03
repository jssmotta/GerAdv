'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IAdvogadosService } from '../Services/Advogados.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IAdvogados } from '../Interfaces/interface.Advogados';
import { isValidDate } from '@/app/tools/datetime';
import { AdvogadosApi } from '../Apis/ApiAdvogados';

export const useAdvogadosForm = (
  initialAdvogados: IAdvogados,
  dataService: IAdvogadosService
) => {
  const [data, setData] = useState<IAdvogados>(initialAdvogados);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadAdvogados = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialAdvogados);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchAdvogadosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Advogados';
      setError(errorMessage);
      console.log('Erro ao carregar Advogados');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialAdvogados]);

  const resetForm = useCallback(() => {
    setData(initialAdvogados);
    setError(null);
  }, [initialAdvogados]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadAdvogados,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadAdvogados, resetForm]);
  return returnValue;
};


export const useAdvogadosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('Advogados', (entity) => {
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


export const useAdvogadosList = (dataService: IAdvogadosService) => {
  const [data, setData] = useState<IAdvogados[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar advogados';
      setError(errorMessage);
      console.log('Erro ao carregar advogados');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useAdvogadosNotifications(
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


export function useValidationsAdvogados() {

  async function runValidation(data: IAdvogados, uri?: string, token?: string): Promise<{ isValid: boolean; message: string } | null> {

    const advogadosApi = new AdvogadosApi(uri ?? '', token ?? '');

    const result = await advogadosApi.validation(data);

    return result;
  }

  function validate(data: IAdvogados): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.emailpro.length > 255) { 
                                             return { isValid: false, message: 'O campo EMailPro não pode ter mais de 255 caracteres.' };
                                         } 
if (data.nome.length > 50) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 50 caracteres.' };
                                         } 
if (data.rg.length > 30) { 
                                             return { isValid: false, message: 'O campo RG não pode ter mais de 30 caracteres.' };
                                         } 
if (data.nomemae.length > 80) { 
                                             return { isValid: false, message: 'O campo NomeMae não pode ter mais de 80 caracteres.' };
                                         } 
if (data.oab.length > 12) { 
                                             return { isValid: false, message: 'O campo OAB não pode ter mais de 12 caracteres.' };
                                         } 
if (data.nomecompleto.length > 50) { 
                                             return { isValid: false, message: 'O campo NomeCompleto não pode ter mais de 50 caracteres.' };
                                         } 
if (data.endereco.length > 80) { 
                                             return { isValid: false, message: 'O campo Endereco não pode ter mais de 80 caracteres.' };
                                         } 
if (data.cep.length > 10) { 
                                             return { isValid: false, message: 'O campo CEP não pode ter mais de 10 caracteres.' };
                                         } 
if (data.bairro.length > 50) { 
                                             return { isValid: false, message: 'O campo Bairro não pode ter mais de 50 caracteres.' };
                                         } 
if (data.ctpsserie.length > 10) { 
                                             return { isValid: false, message: 'O campo CTPSSerie não pode ter mais de 10 caracteres.' };
                                         } 
if (data.ctps.length > 15) { 
                                             return { isValid: false, message: 'O campo CTPS não pode ter mais de 15 caracteres.' };
                                         } 
if (data.fone.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fone não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.fax.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Fax não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.secretaria.length > 20) { 
                                             return { isValid: false, message: 'O campo Secretaria não pode ter mais de 20 caracteres.' };
                                         } 
if (data.textoprocuracao.length > 200) { 
                                             return { isValid: false, message: 'O campo TextoProcuracao não pode ter mais de 200 caracteres.' };
                                         } 
if (data.email.length > 100) { 
                                             return { isValid: false, message: 'O campo EMail não pode ter mais de 100 caracteres.' };
                                         } 
if (data.especializacao.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Especializacao não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.pasta.length > 200) { 
                                             return { isValid: false, message: 'O campo Pasta não pode ter mais de 200 caracteres.' };
                                         } 
if (data.observacao.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Observacao não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.contabancaria.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo ContaBancaria não pode ter mais de 2147483647 caracteres.' };
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
}export const useAdvogadosComboBox = (
  dataService: IAdvogadosService,
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

  useAdvogadosNotifications(
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