'use client';
import React from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';

interface InputTipoPessoaProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: boolean;
  maxLength?: number;
  required?: boolean;
  onChange: (event: any) => void;
}

const InputTipoPessoa: React.FC<InputTipoPessoaProps> = ({
  tabIndex = 0,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
}) => {
  const options = [
    { text: 'Jurídica', value: true },
    { text: 'Física', value: false },
  ];

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

  const stylePfPj =
    selectedOption?.value === true
      ? `.input-tipo-pf {display:none;}`
      : `.input-tipo-pj {display:none;}`;

  return (
    <>
      <style>{stylePfPj}

{`
.input-container-tipo-pessoa {
    border-bottom: 1px solid #ccc !important;
    min-height: 56px;
  }
 .input-container-tipo-pessoa:focus-within {
    border-bottom: 1px solid var(--focus-color-inputs) !important;
  }

    `}

      </style>
      <div className={`input-container input-container-tipo-pessoa ${className}`}>
        <label htmlFor={id} className="input-label">
          {label}
        </label>
        {dataForm?.id == 0 ? (
          <ComboBox
            id={id}
            name={name}
            data={options}
            value={selectedOption}
            onChange={(event) => onChangeLocal(event)}
            textField="text"
            aria-label={`Campo de seleção para ${label}`}
            dataItemKey="value"
            className="k-combobox"
          />
        ) : (
          <ComboBox
            id={id}
            name={name}
            data={options}
            aria-label={`Campo de seleção para ${label}`} 
            value={selectedOption}
            onChange={(event) => onChangeLocal(event)}
            textField="text"
            dataItemKey="value"
            className="k-combobox"
          />
        )}
      </div>
    </>
  );
};

export default React.memo(InputTipoPessoa);
