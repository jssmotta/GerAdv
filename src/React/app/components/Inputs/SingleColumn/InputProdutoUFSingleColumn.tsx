'use client';
import React from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';

interface InputUFSingleColumnProps {
  tabIndex?: number;
  type: string;
  maxLength?: number;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  onChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

const InputUFSingleColumn: React.FC<InputUFSingleColumnProps> = ({
  type,
  maxLength,
  tabIndex = 0,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange
}) => {
  const brasilianStates = [
    { text: 'EX - Exterior', value: 'EX' },
    { text: 'AC - Acre', value: 'AC' },
    { text: 'AL - Alagoas', value: 'AL' },
    { text: 'AP - Amapá', value: 'AP' },
    { text: 'AM - Amazonas', value: 'AM' },
    { text: 'BA - Bahia', value: 'BA' },
    { text: 'CE - Ceará', value: 'CE' },
    { text: 'DF - Distrito Federal', value: 'DF' },
    { text: 'ES - Espírito Santo', value: 'ES' },
    { text: 'GO - Goiás', value: 'GO' },
    { text: 'MA - Maranhão', value: 'MA' },
    { text: 'MT - Mato Grosso', value: 'MT' },
    { text: 'MS - Mato Grosso do Sul', value: 'MS' },
    { text: 'MG - Minas Gerais', value: 'MG' },
    { text: 'PA - Pará', value: 'PA' },
    { text: 'PB - Paraíba', value: 'PB' },
    { text: 'PR - Paraná', value: 'PR' },
    { text: 'PE - Pernambuco', value: 'PE' },
    { text: 'PI - Piauí', value: 'PI' },
    { text: 'RJ - Rio de Janeiro', value: 'RJ' },
    { text: 'RN - Rio Grande do Norte', value: 'RN' },
    { text: 'RS - Rio Grande do Sul', value: 'RS' },
    { text: 'RO - Rondônia', value: 'RO' },
    { text: 'RR - Roraima', value: 'RR' },
    { text: 'SC - Santa Catarina', value: 'SC' },
    { text: 'SP - São Paulo', value: 'SP' },
    { text: 'SE - Sergipe', value: 'SE' },
    { text: 'TO - Tocantins', value: 'TO' }
  ];

  // Encontra o item selecionado baseado no valor
  const selectedItem = brasilianStates.find(state => state.value === value) || null;

  const handleChange = (event: any) => {
    const selectedValue = event.value?.value || '';
    
    // Simula um evento de input para manter compatibilidade com onChange existente
    const syntheticEvent = {
      target: {
        name: name,
        value: selectedValue
      }
    } as React.ChangeEvent<HTMLInputElement>;
    
    onChange(syntheticEvent);
  };

  const label15 = label.length > 20 ? label.slice(0, 20) : label;

  return (
    <div className="input-container input-container-uf-single">
      <label htmlFor={id} className="input-uf-label-single">
        {label15}
      </label>
      <div className="input-uf-wrapper-single">
        <ComboBox
          id={id}
          name={name}
          data={brasilianStates}
          textField="text"
          dataItemKey="value"
          value={selectedItem}
          tabIndex={tabIndex}
          onChange={handleChange}
          className="k-combobox-single"
          placeholder="Selecione a UF"
          allowCustom={false}
          suggest={true}
          clearButton={true}
        />
      </div>
    </div>
  );
};

export default React.memo(InputUFSingleColumn);