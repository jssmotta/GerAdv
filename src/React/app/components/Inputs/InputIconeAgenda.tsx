'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import { OperadorLike } from './InputMaster';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import * as Icons from '../svg/IconsAppointments';
import { descriptionsIcons } from '../svg/IconsAppointments';

export interface ITipoCompromisso { 
    id?: number;
    icone: number,
    nome: string,
}

const InputIconeAgenda: React.FC<DadosSelectProps> = ({
    tabIndex = 0,
    name,
    value,
    label,
    dataForm,
    onChange
}) => {
    const cssDado = 'tipocompromissoInput';

    let systemContext: any = undefined;
    try {
        systemContext = useAppSelector(selectSystemContext);
    } catch (e) {
        systemContext = undefined;
    }

    // Usando estado local para ter controle total dos dados
    const [dados, setDados] = React.useState<ITipoCompromisso[] | null>([]);
    const [selectedValue, setSelectedValue] = useState<any>(null);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if (value && dados && dados.length > 0) {
            let foundItem = null;

            if (typeof value === 'object' && value.id) {
                // O value.id representa o icone
                foundItem = dados.find((item: ITipoCompromisso) => item.icone === value.id);
            } else if (typeof value === 'string') {
                foundItem = dados.find((item: ITipoCompromisso) =>
                    item.nome.toLowerCase() === value.toLowerCase()
                );
            } else if (typeof value === 'number') {
                // Se value é um número, representa o icone
                foundItem = dados.find((item: ITipoCompromisso) => item.icone === value);
            }

            if (foundItem) {
                setSelectedValue(foundItem);
            }
        } else if (!value) {
            setSelectedValue(null);
        }

    }, [value, dados]);

    function isOperadorLike(obj: any): obj is OperadorLike {
        return obj && typeof obj === 'object' && 'senha256' in obj && 'id' in obj;
    }

    // Buscar dados diretamente da API
    const fetchDados = async () => {
        try {
            setLoading(true);
            const load = [] as ITipoCompromisso[];
            for (let i = 1; i <= 32; i++) {
                load.push({ id: i, nome: descriptionsIcons[i - 1], icone: i });
            }
            setDados(load);
        } catch (error) {
            console.error('Erro ao buscar dados:', error);
        } finally {
            setLoading(false);
        }
    };
    React.useEffect(() => {
        fetchDados();
    }, []);

    const handleComboChange = (e: any) => {
        const newValue = e.target.value;
        if (newValue && typeof newValue === 'object' && 'id' in newValue && 'nome' in newValue) {
            setSelectedValue(newValue);

            if (onChange) {
                onChange({
                    target: {
                        name: name,
                        value: newValue.icone,
                    },
                });
            }

        } else if (typeof newValue === 'string' && newValue.trim() !== '') {
            const tempValue = { id: 0, nome: newValue, icone: 0 };
            setSelectedValue(tempValue);

            // Disparar onChange se fornecido
            if (onChange) {
                onChange({
                    target: {
                        name: name,
                        value: 0,
                    },
                });
            }

        }
    };


    const renderComboBoxItem = (li: any, itemProps: any) => {
        const item = itemProps.dataItem;
        if (!item || !item.icone) {
            return React.cloneElement(
                li,
                li.props,
                <div style={{ display: 'flex', alignItems: 'center', width: '100%', padding: '4px 8px' }}>
                    <span style={{ display: 'inline-block', verticalAlign: 'middle' }}>
                        {item?.nome || 'Item sem nome'}
                    </span>
                </div>
            );
        }
        const iconIndex = parseInt(String(item.icone), 10) || 0;
        const iconKey = `Icone${iconIndex}`;
        const svgIcon = (Icons as any)[iconKey] || (Icons as any).Icone0 || '';
        return React.cloneElement(
            li,
            li.props,
            <div style={{ display: 'flex', alignItems: 'center', width: '100%', padding: '4px 8px' }}>
                <div
                    style={{
                        width: '18px',
                        height: '18px',
                        marginRight: '8px',
                        display: 'inline-block',
                        verticalAlign: 'middle',
                        flexShrink: 0
                    }}
                    dangerouslySetInnerHTML={{ __html: svgIcon }}
                />
                <span style={{ display: 'inline-block', verticalAlign: 'middle' }}>
                    {item.nome}
                </span>
            </div>
        );
    };
    const renderComboBoxValue = (paramValue: any) => {
        if (!paramValue || !paramValue.props || !paramValue.props.value) {
            return null;
        }
        const currentValue = paramValue.props.value;
        // Buscar o item pelo ID ou nome
        let selectedValueForRender = null;
        if (typeof currentValue === 'object' && currentValue.id) {
            selectedValueForRender = dados?.find((item: ITipoCompromisso) => item.id === currentValue.id);
        } else if (typeof currentValue === 'string') {
            selectedValueForRender = dados?.find((item: ITipoCompromisso) =>
                item.nome.toLowerCase() === currentValue.toLowerCase()
            );
        }
        if (!selectedValueForRender || !selectedValueForRender.icone) {
            return (
                <span style={{ display: 'flex', alignItems: 'center', width: '100%' }}>
                    <span style={{ display: 'inline-block', verticalAlign: 'middle' }}>
                        {selectedValueForRender?.nome || currentValue?.nome || currentValue}
                    </span>
                </span>
            );
        }
        const iconIndex = parseInt(String(selectedValueForRender.icone), 10) || 0;
        const iconKey = `Icone${iconIndex}`;
        const svgIcon = (Icons as any)[iconKey] || (Icons as any).Icone0 || '';
        return (
            <span style={{ display: 'flex', alignItems: 'center', width: '100%' }}>
                <div
                    style={{
                        width: '18px',
                        height: '18px',
                        marginLeft: '4px',
                        marginRight: '8px',
                        display: 'inline-block',
                        verticalAlign: 'middle',
                        flexShrink: 0
                    }}
                    dangerouslySetInnerHTML={{ __html: svgIcon }}
                />
                <span style={{ display: 'inline-block', verticalAlign: 'middle' }}>
                    {selectedValueForRender.nome}
                </span>
            </span>
        );
    };
    return (
        <>
            <style jsx global>{`
  /* Estilos para o campo de input com �cone */
  .tipocompromissoInput .k-input-inner {
    padding-left: 30px !important;
  }
  /* Garantir que o ComboBox tenha apenas border-bottom */
  .tipocompromissoInput.k-combobox, 
  .tipocompromissoInput .k-input, 
  .tipocompromissoInput .k-input-inner {
    border: none !important;
    border-radius: 0 !important;
    border-bottom: 1px solid #ccc !important;
    box-shadow: none !important;
    background-color: transparent !important;
    transition: border-color 0.3s ease;
  }
  .icone-agenda-dropdown-popup-msi {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    z-index: 99999 !important;
    position: absolute !important;
    background: white !important;
    border: 1px solid #ccc !important;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15) !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    min-width: 200px !important;
    height: auto !important;
  }
  .icone-agenda-dropdown-popup-msi .k-list {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    background: white !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    height: auto !important;
    width: 100% !important;
  }
  .icone-agenda-dropdown-popup-msi .k-list-item {
    display: flex !important;
    align-items: center !important;
    visibility: visible !important;
    opacity: 1 !important;
    padding: 8px 12px !important;
    background: white !important;
    color: #333 !important;
    cursor: pointer !important;
    border-bottom: 1px solid #eee !important;
    height: auto !important;
    min-height: 32px !important;
    width: 100% !important;
  }
  .icone-agenda-dropdown-popup-msi .k-list-item: hover {
    background: #f0f0f0 !important;
  }
  .icone-agenda-dropdown-popup-msi .k-list-item > div {
    display: flex !important;
    align-items: center !important;
    width: 100% !important;
    padding: 8px 12px !important;
  }
  .icone-agenda-dropdown-popup-msi .k-list-item img {
    display: inline-block !important;
    vertical-align: middle !important;
    flex-shrink: 0 !important;
    width: 18px !important;
    height: 18px !important;
    margin-right: 8px !important;
  }
    /* SVG icon container styling to match previous <img> sizes */
    .icone-agenda-dropdown-popup-msi .k-list-item .svg-icon,
    .icone-agenda-dropdown-popup-msi .k-list-item .svg-icon svg {
        display: inline-block !important;
        vertical-align: middle !important;
        flex-shrink: 0 !important;
        width: 18px !important;
        height: 18px !important;
        margin-right: 8px !important;
    }
  .icone-agenda-dropdown-popup-msi .k-list-item span {
    display: inline-block !important;
    vertical-align: middle !important;
    flex: 1 !important;
  }
    /* avoid forcing all descendants to block; keep rules specific above */
  `}</style>

            <div className={`${cssDado} input-msi-combobox input-container`}>
                <div className='comboboxLabel'>
                    <span className='k-floating-label'>{label}</span>
                </div>
                <div className='comboboxBox'>
                    <ComboBox
                        tabIndex={tabIndex}
                        name={name}
                        data={dados || []}
                        textField='nome'
                        dataItemKey='id'
                        value={selectedValue}
                        className={cssDado}
                        allowCustom={true}
                        filterable={true}
                        aria-label={`Campo de seleção para ${label}`}
                        loading={loading}
                        disabled={
                            systemContext?.Id == dataForm?.id ||
                            systemContext?.IsMaster === false
                        }
                        aria-busy={loading}
                        onChange={handleComboChange}
                        itemRender={renderComboBoxItem}
                        valueRender={renderComboBoxValue}
                        style={{ height: '33px' }}
                        clearButton={true}
                        suggest={true}
                        popupSettings={{
                            className: 'icone-agenda-dropdown-popup-msi'
                        }}
                    />

                </div>
            </div>
        </>
    );
};
export default InputIconeAgenda;