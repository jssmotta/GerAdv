'use client';
import React from 'react';
import { Checkbox, CheckboxChangeEvent } from '@progress/kendo-react-inputs';

interface InputImportadoraProps {
  tabIndex?: number;
  label: string;
  dataForm?: any;
  name: string;
  checked: boolean;
  style?: React.CSSProperties;
  onChange: (event: CheckboxChangeEvent) => void;
  className?: string;
}

const InputImportadora: React.FC<InputImportadoraProps> = ({
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

  return (
    <>
      {(!dataForm ||
        dataForm?.['uiShow' + name] ||
        dataForm?.['uiShow' + name] === undefined) && (
        <div
          className={`${className} input-container input-checkbox-container`}
        >
          <div className={cssDado}>
            <Checkbox
              tabIndex={tabIndex}
              style={style}
              name={name}
              className={className}
              id={name}
              aria-label={`Checkbox para ${label}`}
              checked={checked}
              onChange={onChange}
            />
            <label htmlFor={name}>{label}</label>
          </div>
        </div>
      )}
    </>
  );
};

export default React.memo(InputImportadora);
