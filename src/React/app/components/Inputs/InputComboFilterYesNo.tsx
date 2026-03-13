'use client';
import React from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';

interface InputComboFilterYesNoProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: number;
  onChange: (event: any) => void;
  required?: boolean;
  maxLength?: number;
}

const InputComboFilterYesNo: React.FC<InputComboFilterYesNoProps> = ({
  tabIndex = 0,
  type,
  required,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
}) => {
  const options = [
    { text: '(qualquer um)', value: -2147483648 },
    { text: name=='sexo' ? 'Feminino' : 'Não', value: 0 },
    { text: name=='sexo' ? 'Masculino' : 'Sim', value: 1 }
  ];

  const selectedOption = options.find(option => option.value === value);

  const handleChange = (event: any) => {
    onChange({
      target: {
        name,
        value: event.target.value?.value,
      },
    });
  };

  return (
    <div className={`input-container input-container-yes-no ${className}`}>
      <label htmlFor={id} className="input-label">
        {label}
      </label>
      <ComboBox
        id={id}
        tabIndex={tabIndex}
        name={name}
        data={options}
        aria-label={`Campo de seleção para ${label}`}
        value={selectedOption}
        onChange={handleChange}
        textField="text"
        dataItemKey="value"
        className="k-combobox"
      />
    </div>
  );
};

export default React.memo(InputComboFilterYesNo);