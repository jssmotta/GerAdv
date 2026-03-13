'use client';
import React, { use, useEffect } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';

interface InputComboOptionsProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  placeholder?: string;
  value: string;
  onChange: (event: any) => void;
  comboOptions: string;
  required?: boolean;
  disabled?: boolean;
  maxLength?: number;
}

const InputComboOptions: React.FC<InputComboOptionsProps> = ({
  tabIndex = 0,
  type,
  disabled = false,
  required,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  comboOptions,
  onChange,
}) => {
  const options = comboOptions.split(';').map((e) => {
    return { text: e, value: e };
  });

  const selectedOption = options.find((option) => option.value === value);

  const onChangeLocal = (event: any) => {
    const selectedValue = event.target.value?.value;
    onChange({
      target: {
        name: name,
        value: selectedValue,
      },
    });
  };

  return (
    <div className={`input-container ${className}`}>
      <label htmlFor={id} className="input-label">
        {label}
      </label>
      {dataForm?.id == 0 ? (
        <ComboBox
          tabIndex={tabIndex}
          id={id}
          name={name}
          data={options}
          aria-label={`Campo de seleção para ${label}`}
          value={selectedOption}
          onChange={(event) => onChangeLocal(event)}
          textField="text"
          dataItemKey="value"
          disabled={disabled}
          className="k-combobox"
        />
      ) : (
        <ComboBox
          tabIndex={tabIndex}
          id={id}
          name={name}
          data={options}
          aria-label={`Campo de seleção para ${label}`}
          value={selectedOption}
          onChange={(event) => onChangeLocal(event)}
          textField="text"
          dataItemKey="value"
          disabled={disabled}
          className="k-combobox"
        />
      )}
    </div>
  );
};

export default React.memo(InputComboOptions);
