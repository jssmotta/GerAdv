'use client';
import React from 'react';
import { Checkbox, CheckboxChangeEvent } from '@progress/kendo-react-inputs';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

interface InputCheckBoxProps {
  tabIndex?: number;
  label: string;
  dataForm?: any;
  name: string;
  checked: boolean;
  style?: React.CSSProperties;
  onChange: (event: CheckboxChangeEvent) => void;
  className?: string;
  id?: string;
  disabled?: boolean;
}

const InputCheckbox: React.FC<InputCheckBoxProps> = ({
  tabIndex = 0,
  id,
  disabled,
  style,
  label,
  dataForm,
  name,
  className,
  checked,
  onChange,
}) => {
  const cssDado = 'inputCheckBox';
  const icon = getIcon(label);
  return (
    <div className={`${className ? className : ''} input-container-check input-checkbox-container ${icon ? 'input-container-checkbox-icon' : ''}`}>

      <div className={cssDado} style={{ paddingTop: '10px' }}>
        {icon && (
          <InputAwesomeIcon icon={icon} inputText={false} />
        )}

        <Checkbox
          tabIndex={tabIndex}
          style={style}
          name={name}
          className={`${icon ? 'input-checkbox-icon' : ''}`}
          aria-label={`Checkbox para ${label}`}
          id={name}
          checked={checked}
          disabled={disabled}
          onChange={onChange}

        />
        <label htmlFor={name} className={className}>{label}</label>
      </div>
    </div>
  );
};

export default React.memo(InputCheckbox);
