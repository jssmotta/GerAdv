"use client";
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-all';
import { ColaboradoresEmpty } from '../../Models/Colaboradores';
import { ColaboradoresApi } from '../Apis/ApiColaboradores';
import { NomeID } from '@/app/models/NomeID';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
import ColaboradoresWindow from '../Crud/Grids/ColaboradoresWindow';
import { IColaboradores } from '../Interfaces/interface.Colaboradores';
import { pencilIcon, plusIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';

const ColaboradoresComboBox: React.FC<DadosSelectProps> = ({ name, value, setValue, label }) => {
    const cssDado = 'colaboradoresInput';
    const { systemContext } = useSystemContext();
    const dadoApi = new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
    const [dados, setDados] = React.useState<NomeID[] | null>([]);    
    const [displayValue, setDisplayValue] = useState<any>(value);
    const [isOpen, setIsOpen] = useState(false);
    const [addValue, setAddValue] = useState<IColaboradores | null>(null);
    const [action, setAction] = useState('Adicionar');
    const [editar, setEditar] = useState<IColaboradores | null>(null);
    const [refresh, setRefresh] = useState(false);

    useEffect(() => {       
        if (typeof value === 'number' && !isNaN(value)) {
            const fetchData = async () => {
                const response = await dadoApi.getById(value); 
                setDisplayValue({ id: response.data.id, nome: response.data.nome });
                setEditar(response.data as IColaboradores);
                setAction('Editar');
                setRefresh(false);
            };
            fetchData();
        }
        else {
            setAction('Adicionar');
            setDisplayValue(value);
        }
    }, [value, refresh]);

    useEffect(() => {       
        if (displayValue && !isNaN(displayValue.id) && displayValue.id > 0) {
            const fetchData = async () => {
                const response = await dadoApi.getById(displayValue.id);   
                setEditar(response.data as IColaboradores);
                setAction('Editar'); 
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
        const unsubscribe = subscribeToNotifications("Colaboradores", (entity) => {
            fetchDados();
            setRefresh(true);
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
        if (action === 'Editar') {
            setIsOpen(true);
            return;
        }
        const inputValue = getValueCurrent();
        const add = ColaboradoresEmpty();
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
            setAction('Adicionar');
        }
    }, [displayValue]);

    return (
        <>
          {(editar || addValue) && isOpen && (
            <ColaboradoresWindow
                isOpen={isOpen}
                onClose={onClose}                     
                onSuccess={onClose}
                onError={onClose}
                selectedColaboradores={editar ?? addValue ?? ColaboradoresEmpty()} /> 
            )}

            <div className={`${cssDado} inputCombobox input-container`}>
                <div className='comboboxLabel'>
                    <span className='k-floating-label'>{label}
                        <label className='input-combobox-action-svg-label' style={{display: 'block', float: 'right', width: '20px', marginRight: '5px', fontSize: '7.5pt'}} onClick={handleAddClick}>{<SvgIcon icon={action==="Editar" ? pencilIcon : plusIcon} />}</label>
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
                    />
                </div>
            </div>
            
        </>
    );
};

export default ColaboradoresComboBox;