"use client";
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { Enderecos } from '../../Models/Enderecos';
import { UpperCaseDefault } from '@/app/components/UpperCases';
import ModalInput from '@/app/components/Modalnput';
import { IEnderecos } from '../Interfaces/interface.Enderecos';
import { EnderecosApi } from '../Apis/ApiEnderecos';
import { NomeID } from '@/app/models/NomeID';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';

const EnderecosComboBox: React.FC<DadosSelectProps> = ({ name, value, setValue, label }) => {
    const cssDado = 'enderecosInput';
    const { systemContext } = useSystemContext();
    const dadoApi = new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
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

        const nova = { id: 0, descricao: (UpperCaseDefault ? descricao.toUpperCase() : descricao) } as Enderecos;
        const novoDado = await dadoApi.addAndUpdate(nova as IEnderecos);
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

            <div className={`${cssDado} inputCombobox`}>
                <div className='comboboxLabel'>
                    <span className='k-floating-label'>{label}<ModalInput selfClick={autoClick} value={() => getValueCurrent()} descricao='Nome/descrição (novo):' onAdd={handleAddDado} /></span>
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

export default EnderecosComboBox;