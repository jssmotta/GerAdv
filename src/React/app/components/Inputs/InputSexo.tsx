'use client';
import React from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

interface InputSexoProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: boolean; // Agora o valor é booleano
  onChange: (event: any) => void;
  required?: boolean;
}

const InputSexo: React.FC<InputSexoProps> = ({
  tabIndex = 0,
  type,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
  required = false
}) => {
  const options = [
    { text: 'Masculino', value: true },
    { text: 'Feminino', value: false },
  ];

  const selectedOption = options.find((option) => option.value === value) ?? options[0];

  const onChangeLocal = (event: any) => {
    const selectedValue = event.target.value?.value;
    onChange({
      target: {
        name: name,
        value: selectedValue,
      },
    });
  };
  
  const icon = getIcon(label);

  return (
    <>
      <div className="input-container input-container-icon input-container-sexo">
        {icon && (
          <InputAwesomeIcon icon={icon} />
        )}

        <label htmlFor={id} className='k-label'>
          {label}{required && ' *'}
        </label>

        <ComboBox
          tabIndex={tabIndex}
          data-testid="combobox"
          id={id}
          name={name}
          required={required}
          data={options}
          aria-label={`Campo de seleção para ${label}`}
          value={selectedOption}
          onChange={(event) => onChangeLocal(event)}
          textField="text"
          dataItemKey="value"
          className="k-combobox combobox-sexo"
          style={{ fontSize: '16px', paddingLeft: '0px' }}
          clearButton={true}
          suggest={true}
          popupSettings={{
            className: 'sexo-dropdown-popup-msi'
          }}
        />
      </div>

      <style>
        {`

      .input-container-sexo {
          border-bottom: 1px solid #ccc !important;
          max-height: 58px !important;
          max-width: 360px !important;
      }

      .input-container-icon {
        position: relative;
      }

  .sexo-dropdown-popup-msi {
    z-index: 2147483647 !important;
    position: fixed !important;
    background: #fff !important;
    border: 1px solid #ccc !important;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15) !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    min-width: 200px !important;
  }

  /* Garante que o container do popup do Kendo não seja cortado */
  .k-animation-container {
    overflow: visible !important;
    z-index: 2147483647 !important;
  }

  .sexo-dropdown-popup-msi .k-list {
    background: #fff !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    padding: 0 !important;
  }

  .sexo-dropdown-popup-msi .k-list-item {
    padding: 8px 16px !important;
    background: #fff !important;
    color: #333 !important;
    cursor: pointer !important;
    border-bottom: 1px solid #eee !important;
    transition: background 0.2s;
  }

  .sexo-dropdown-popup-msi .k-list-item:last-child {
    border-bottom: none !important;
  }

  .sexo-dropdown-popup-msi .k-list-item:hover {
    background: #f0f0f0 !important;
  }

  `}</style>
    </>
  );
};

export default React.memo(InputSexo);
