"use client"; 
import React, { useEffect, useState, useRef } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { StatusAndamentoEmpty } from '../../Models/StatusAndamento';
import { StatusAndamentoApi } from '../Apis/ApiStatusAndamento';
import { NomeID } from '@/app/models/NomeID';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
import StatusAndamentoWindow from '../Crud/Grids/StatusAndamentoWindow';
import { IStatusAndamento } from '../Interfaces/interface.StatusAndamento';
import { pencilIcon, plusIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';

const StatusAndamentoComboBox: React.FC<DadosSelectProps> = ({ name, value, setValue, label, dataForm }) => {
    const cssDado = 'statusandamentoInput';
    const { systemContext } = useSystemContext();
    const dadoApi = new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
    const [dados, setDados] = React.useState<NomeID[] | null>([]);    
    const [displayValue, setDisplayValue] = useState<any>(value);
    const [isOpen, setIsOpen] = useState(false);
    const [addValue, setAddValue] = useState<IStatusAndamento | null>(null);
    const [action, setAction] = useState(ActionAdicionar);
    const [editar, setEditar] = useState<IStatusAndamento | null>(null);    
    const [waitChanges, setWaitChanges] = useState(false);
    const waitChangesRef = useRef(waitChanges);

    useEffect(() => {
        waitChangesRef.current = waitChanges;
    }, [waitChanges]);

    useEffect(() => {       
        if (typeof value === 'number' && !isNaN(value) && value > 0) {
            const fetchData = async () => {
                const response = await dadoApi.getById(value); 
                setDisplayValue({ id: response.data.id, nome: response.data.nome });
                setEditar(response.data as IStatusAndamento);
                setAction(ActionEditar);                
            };
            fetchData();
        }
        else {
            setAction(ActionAdicionar);
            setDisplayValue(value);
        }
    }, [value]);

    useEffect(() => {       
        if (displayValue && !isNaN(displayValue.id) && displayValue.id > 0) {
            const fetchData = async () => {
                const response = await dadoApi.getById(displayValue.id);   
                setEditar(response.data as IStatusAndamento);
                setAction(ActionEditar); 
            };
            fetchData();
        } 
    }, [displayValue]);

    const fetchDados = async () => {
        try {
            const response = await dadoApi.getListN(5000);
            const dado = response.data ?? [];
            setDados(dado);
            setFilteredDados(dado);

        } catch (error) {
            console.error('Erro ao buscar dados:', error);
        }
    };

    React.useEffect(() => {
        fetchDados();
    }, []);

    React.useEffect(() => {
        const unsubscribe = subscribeToNotifications("StatusAndamento", (entity) => {
      try {
                fetchDados();                

                if (entity.action === NotifySystemActions.DELETE) {
                    setDisplayValue({ id: 0, nome: "" });
                }
                else {
                    if (waitChangesRef.current) {
                        setWaitChanges(false);
                        const PTimetToRefresh = 500;
                        setTimeout(() => {
                            const fetchData = async () => {
                                const response = await dadoApi.getById(entity.id);
                                setDisplayValue({ id: response.data.id, nome: response.data.nome });
                                setEditar(response.data as IStatusAndamento);
                                setAction(ActionEditar);                                
                            };
                            fetchData();
                        }, PTimetToRefresh);
                    }
                }
            } catch (err) {
                console.error("Erro no listener de notifica\u00e7\u00f5es:", err);
            }

            });  
            
        return () => {
            unsubscribe();
        };
    }, []);
   
    const [filteredDados, setFilteredDados] = useState(dados ?? []);

    const handleFilterChange = (event: any) => {
        const filter = event.filter.value.toLowerCase();
        const filteredData = (dados ?? []).filter(dado =>
            dado.nome.toLowerCase().includes(filter)
        );
        setFilteredDados(filteredData);        
    };

    const getValueCurrent = (): string => {
        const inputElement = document.querySelector(`.${cssDado} input`) as HTMLInputElement;

        if (inputElement) {
            return inputElement.value;
        }
        return '';
    }

    const onClose = () => {
        setIsOpen(false);
    };

    const handleAddClick = () => {
        if (action === ActionEditar) {
            setIsOpen(true);
            return;
        }
        const inputValue = getValueCurrent();
        const add = StatusAndamentoEmpty();
        add.nome = inputValue.toUpperCase();       
        setEditar(null);
        setAddValue(add);
        setIsOpen(true);
    }

    const handleChange = (e: any) => {
        const newValue = e.target.value;
    
        if (newValue && typeof newValue === 'object' && 'id' in newValue && 'nome' in newValue) { 
            setDisplayValue(newValue);
            setValue(newValue);
        } else if (typeof newValue === 'string' && newValue.trim() !== '') { 
            const tempValue = { id: 0, nome: newValue };
            setDisplayValue(tempValue);
     
            const matchingItem = dados?.find(item => 
                item.nome.toLowerCase() === newValue.toLowerCase());
                
            if (matchingItem) { 
                setDisplayValue(matchingItem);
                setValue(matchingItem);
            }            
            
        } else { 
            setDisplayValue(null);
            setValue(null);
        }
    };

    useEffect(() => { 
        if (displayValue===null) {
            setAction(ActionAdicionar);
        }
    }, [displayValue]);

    return (
        <>
          {(editar || addValue) && isOpen && (
            <StatusAndamentoWindow
                isOpen={isOpen}
                onClose={onClose}                     
                onSuccess={onClose}
                onError={onClose}
                selectedStatusAndamento={editar ?? addValue ?? StatusAndamentoEmpty()} /> 
            )}

            <div className={`${cssDado} inputCombobox input-container`}>
                <div className='comboboxLabel'>
                    <span className='k-floating-label'>{label}                        
                    </span>
                </div>
                <div className='comboboxBox'>
                    <ComboBox
                        name={name}
                        data={filteredDados ?? []}
                        textField="nome"
                        dataItemKey="id"
                        value={displayValue}
                        className={cssDado}
                        allowCustom={true}
                        filterable={true}
                        onFilterChange={handleFilterChange}
                        onChange={handleChange}
                    /><label title={action==="Editar" ? "Editar o item atual" : "Incluir/Adicionar novo item"} className={`input-combobox-action-svg-label-${action.toLocaleLowerCase()}`} onClick={handleAddClick}>{<SvgIcon icon={action==="Editar" ? pencilIcon : plusIcon} />}</label>
                </div>
            </div>
            
        </>
    );
};

export default StatusAndamentoComboBox;