'use client';
import { useState, useEffect, useCallback, useRef, useMemo } from 'react';
import { IModelosDocumentosService } from '../Services/ModelosDocumentos.service';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import { IModelosDocumentos } from '../Interfaces/interface.ModelosDocumentos';
import { isValidDate } from '@/app/tools/datetime';

export const useModelosDocumentosForm = (
  initialModelosDocumentos: IModelosDocumentos,
  dataService: IModelosDocumentosService
) => {
  const [data, setData] = useState<IModelosDocumentos>(initialModelosDocumentos);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = useCallback((e: any) => {
    const { name, value, type, checked } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));    
  }, []);

  const loadModelosDocumentos = useCallback(async (id: number) => {
    if (!id || id === 0) {
      setData(initialModelosDocumentos);
      return;
    }

    setLoading(true);
    setError(null);
    
    try {
      const dados = await dataService.fetchModelosDocumentosById(id);
      setData(dados);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar Modelos Documentos';
      setError(errorMessage);
      console.log('Erro ao carregar Modelos Documentos');
    } finally {
      setLoading(false);
    }
  }, [dataService, initialModelosDocumentos]);

  const resetForm = useCallback(() => {
    setData(initialModelosDocumentos);
    setError(null);
  }, [initialModelosDocumentos]);

  const returnValue = useMemo(() => ({
    data,
    loading,
    error,
    handleChange,
    loadModelosDocumentos,
    resetForm,
    setData
  }), [data, loading, error, handleChange, loadModelosDocumentos, resetForm]);
  return returnValue;
};


export const useModelosDocumentosNotifications = (
  onUpdate?: (entity: any) => void,
  onDelete?: (entity: any) => void,
  onAdd?: (entity: any) => void
) => {
  const callbacksRef = useRef({ onUpdate, onDelete, onAdd });
  
  useEffect(() => {
    callbacksRef.current = { onUpdate, onDelete, onAdd };
  }, [onUpdate, onDelete, onAdd]);

  useEffect(() => {
    const unsubscribe = subscribeToNotifications('ModelosDocumentos', (entity) => {
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


export const useModelosDocumentosList = (dataService: IModelosDocumentosService) => {
  const [data, setData] = useState<IModelosDocumentos[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = useCallback(async (filtro?: any) => {
    setLoading(true);
    setError(null);
    
    try {
      const result = await dataService.getAll(filtro);
      setData(result);
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro ao carregar modelosdocumentos';
      setError(errorMessage);
      console.log('Erro ao carregar modelosdocumentos');
    } finally {
      setLoading(false);
    }
  }, [dataService]);

  const refreshData = useCallback(() => {
    fetchData();
  }, [fetchData]);
  
  useModelosDocumentosNotifications(
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


export function useValidationsModelosDocumentos() {
  function validate(data: IModelosDocumentos): { isValid: boolean; message: string } {
    if (!data) return { isValid: false, message: 'Dados não informados.' };
    
      try {
   
        if (data.nome.length <= 0) { 
                                             return { isValid: false, message: 'O campo Nome não pode ficar vazio.' };
                                         } 
if (data.nome.length > 50) { 
                                             return { isValid: false, message: 'O campo Nome não pode ter mais de 50 caracteres.' };
                                         } 
if (data.remuneracao.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Remuneracao não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.assinatura.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Assinatura não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.header.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Header não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.footer.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Footer não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.extra1.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Extra1 não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.extra2.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Extra2 não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.extra3.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Extra3 não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.outorgante.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Outorgante não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.outorgados.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Outorgados não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.poderes.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Poderes não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.objeto.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Objeto não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.titulo.length > 2000) { 
                                             return { isValid: false, message: 'O campo Titulo não pode ter mais de 2000 caracteres.' };
                                         } 
if (data.testemunhas.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo Testemunhas não pode ter mais de 2147483647 caracteres.' };
                                         } 
if (data.css.length > 2147483647) { 
                                             return { isValid: false, message: 'O campo CSS não pode ter mais de 2147483647 caracteres.' };
                                         } 



        return { isValid: true, message: '' };

         } catch (error) {
          return { isValid: true, message: 'Erro ao validar os dados.' };
    }

  }

  return { validate };
}export const useModelosDocumentosComboBox = (
  dataService: IModelosDocumentosService,
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

  useModelosDocumentosNotifications(
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