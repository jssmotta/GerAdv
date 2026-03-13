'use client';
import React from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';

interface InputComboOptionsSingleColumnProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  onChange: (event: any) => void;
  comboOptions: string;
  required?: boolean;
  maxLength?: number;
  placeholder?: string;
  disabled?: boolean;
}

const InputComboOptionsSingleColumn: React.FC<InputComboOptionsSingleColumnProps> = ({
  tabIndex = 0,
  type,
  required,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  comboOptions,
  onChange,
  placeholder,
  disabled,
}) => {
  // Converte a string de opções em array de objetos
  const options = comboOptions.split(';').filter(option => option.trim() !== '').map((option) => {
    const trimmedOption = option.trim();
    return { text: trimmedOption, value: trimmedOption };
  });

  // Encontra a opção selecionada baseada no valor atual
  const selectedOption = options.find((option) => option.value === value) || null;

  // Manipula a mudança de valor - usando a mesma assinatura do componente original
  const onChangeLocal = (event: any) => {
    const selectedValue = event.target.value?.value || '';
    onChange({
      target: {
        name: name,
        value: selectedValue,
      },
    });
  };

  const label15 = label ? label.length > 20 ? label.slice(0, 20) : label : '';


  return (
    <div className={`input-container input-container-combo-single ${className || ''}`}>
      <label htmlFor={id} className="input-combo-label-single">
        {label15}
      </label>
      <div className="input-combo-wrapper-single">
        <ComboBox
          tabIndex={tabIndex}
          id={id}
          name={name}
          data={options}
          value={selectedOption}
          onChange={(event) => onChangeLocal(event)}
          textField="text"
          dataItemKey="value"
          className="k-combobox-single"
          placeholder={placeholder || "Selecione uma opção"}
          disabled={disabled}
        />
      </div>
    </div>
  );
};

export default React.memo(InputComboOptionsSingleColumn);