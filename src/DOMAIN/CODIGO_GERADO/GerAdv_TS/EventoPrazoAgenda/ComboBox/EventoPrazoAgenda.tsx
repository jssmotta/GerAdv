"use client";
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { EventoPrazoAgenda } from '../../Models/EventoPrazoAgenda';
import { UpperCaseDefault } from '@/app/components/UpperCases';
import ModalInput from '@/app/components/Modalnput';
import { IEventoPrazoAgenda } from '../Interfaces/interface.EventoPrazoAgenda';
import { EventoPrazoAgendaApi } from '../Apis/ApiEventoPrazoAgenda';
import { NomeID } from '@/app/models/NomeID';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';

const EventoPrazoAgendaComboBox: React.FC<DadosSelectProps> = ({ name, value, setValue, label }) => {
    const cssDado = 'eventoprazoagendaInput';
    const { systemContext } = useSystemContext();
    const dadoApi = new EventoPrazoAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
    const [dados, setDados] = React.useState<NomeID[] | null>([]);
    const [autoClick, setAutoClick] = useState(false);
    const [displayValue, setDisplayValue] = useState<any>(value);
    
    useEffect(() => {       
        if (typeof value === 'number' && !isNaN(value)) {
            const fetchData = async () => {
                const response = await dadoApi.getById(value); 
                setDisplayValue({ id: response.data.id, nome: response.data.nome });
            };
            fetchData();
        }
        else {
            setDisplayValue(value);
        }
    }, [value]);

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

    const handleAddDado = async (descricao: string) => {

        setAutoClick(false);

        const pesquisa = await dadoApi.getByName(descricao);

        if (pesquisa.data && pesquisa.data.id > 0) {
            setValue(pesquisa.data);
            return;
        }

        const nova = { id: 0, nome: (UpperCaseDefault ? descricao.toUpperCase() : descricao) } as EventoPrazoAgenda;
        const novoDado = await dadoApi.addAndUpdate(nova as IEventoPrazoAgenda);
        const add = { id: novoDado.data.id, nome: novoDado.data.nome } as NomeID;
        setDados((prev) => [...(prev ?? []), add]);
        setValue(add);
    };
    const [filteredDados, setFilteredDados] = useState(dados ?? []);

    const handleFilterChange = (event: any) => {
        const filter = event.filter.value.toLowerCase();
        const filteredData = (dados ?? []).filter(dado =>
            dado.nome.toLowerCase().includes(filter)
        );
        setFilteredDados(filteredData);
        if (filteredData.length === 0) {
            setAutoClick(true);
        }
    };

    const getValueCurrent = (): string => {
        const inputElement = document.querySelector(`.${cssDado} input`) as HTMLInputElement;

        if (inputElement) {
            return inputElement.value;
        }
        return '';
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
            } else { 
                setAutoClick(true);
            }
        } else { 
            setDisplayValue(null);
            setValue(null);
        }
    };

    return (
        <>
            <style>
                {`
                    .${cssDado} { width: 390px; height: 38px; }                
                `}
            </style>

            <div style={{ display: 'block' }} className={cssDado}>
                <div style={{ display: 'block' }}>
                    <span className='k-floating-label'>{label}<ModalInput selfClick={autoClick} value={() => getValueCurrent()} descricao='Nome/descrição (novo):' onAdd={handleAddDado} /></span>
                </div>
                <div style={{ display: 'block' }}>
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
            <div style={{ clear: 'both' }}></div>
        </>
    );
};

export default EventoPrazoAgendaComboBox;