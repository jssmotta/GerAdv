'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IOperadorEMailPopupService } from '../Services/OperadorEMailPopup.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IOperadorEMailPopup } from '../Interfaces/interface.OperadorEMailPopup';
import { isValidDate } from '@/app/tools/datetime';

export const useOperadorEMailPopupForm = (
  initialOperadorEMailPopup: IOperadorEMailPopup,
  dataService: IOperadorEMailPopupService
) => {
  const [data, setData] = useState<IOperadorEMailPopup>(initialOperadorEMailPopup);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadOperadorEMailPopup = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialOperadorEMailPopup);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchOperadorEMailPopupById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Operador E Mail Popup';
      setError(errorMessage);
      console.log('Erro ao carregar Operador E Mail Popup');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialOperadorEMailPopup]);

  const resetForm = useCallback(() => {
    setData(initialOperadorEMailPopup);
    setError(null);
  }, [initialOperadorEMailPopup]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadOperadorEMailPopup,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadOperadorEMailPopup, resetForm]);
  return returnValue;
};


export const useOperadorEMailPopupNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('OperadorEMailPopup', (entity) => {
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


export const useOperadorEMailPopupList = (dataService: IOperadorEMailPopupService) => {
  const [data, setData] = useState<IOperadorEMailPopup[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar operadoremailpopup';
      setError(errorMessage);
      console.log('Erro ao carregar operadoremailpopup');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useOperadorEMailPopupNotifications(
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


export function useValidationsOperadorEMailPopup() {
  function validate(data: IOperadorEMailPopup): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.nome.length > 80) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 80 caracteres.' };
                                         } 
if (data.senha.length > 50) { 
                                             return { isValid: false, message: 'O campo Senha não pode ter mais de 50 caracteres.' };
                                         } 
if (data.smtp.length > 255) { 
                                             return { isValid: false, message: 'O campo SMTP não pode ter mais de 255 caracteres.' };
                                         } 
if (data.pop3.length > 255) { 
                                             return { isValid: false, message: 'O campo POP3 não pode ter mais de 255 caracteres.' };
                                         } 
if (data.descricao.length > 100) { 
                                             return { isValid: false, message: 'O campo Descricao não pode ter mais de 100 caracteres.' };
                                         } 
if (data.usuario.length > 50) { 
                                             return { isValid: false, message: 'O campo Usuario não pode ter mais de 50 caracteres.' };
                                         } 
if (data.assinatura.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Assinatura não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.senha256.length > 4000) { 
                                             return { isValid: false, message: 'O campo Senha256 não pode ter mais de 4000 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}export const useOperadorEMailPopupComboBox = (
  dataService: IOperadorEMailPopupService,
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

  useOperadorEMailPopupNotifications(
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