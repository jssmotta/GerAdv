'use client';
import React from 'react';
import { Checkbox, CheckboxChangeEvent } from '@progress/kendo-react-inputs';
import InputCheckbox from './InputCheckbox';

interface InputCheckBoxProps {
  tabIndex?: number;
  label: string;
  dataForm?: any;
  name: string;
  checked: boolean;
  style?: React.CSSProperties;
  onChange: (event: CheckboxChangeEvent) => void;
  className?: string;
}

const InputCheckboxPjPf: React.FC<InputCheckBoxProps> = ({
  tabIndex = 0,
  style,
  label,
  dataForm,
  name,
  className,
  checked,
  onChange,
}) => {
  const cssDado = 'inputCheckBox';

  const showPjPf = () => {
    const isPf = dataForm && dataForm?.tipo !== undefined && !!!dataForm?.tipo;
    const isPj = dataForm && dataForm?.tipo !== undefined && dataForm?.tipo;

    let result = false;
    if (isPf) {
      result = name === 'rg';
    } else if (isPj) {
      result =
        name === 'inscest' ||
        name === 'inscmun' ||
        name === 'difal' ||
        name === 'importadora' ||
        name === 'orgaopublico';
    }
    return result;
  };

  return (
    <>
      {showPjPf() && (        
            <InputCheckbox
              style={style}
              tabIndex={tabIndex}
              name={name}
              aria-label={`Checkbox para ${label}`}
              id={name}
              label={label}
              checked={checked}
              onChange={onChange}
            />
        
      )}
    </>
  );
};

export default React.memo(InputCheckboxPjPf);
