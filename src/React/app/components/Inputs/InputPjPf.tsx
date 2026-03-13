'use client';
import React from 'react';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';

interface InputInputProps {
  tabIndex?: number;
  type?: string;
  id?: string;
  label?: string;
  dataForm?: any;
  className?: string;
  name: string;
  value?: string | number;
  autoComplete?: string;
  placeholder?: string;
  required?: boolean;
  disabled?: boolean;
  onPaste?: (event: React.ClipboardEvent<HTMLInputElement>) => void;
  onKeyDown?: (event: React.KeyboardEvent<HTMLInputElement>) => void;
  onChange?: (event: any) => void;
  maxLength?: number;
  checked?: boolean;
  max?: number;
}

const InputPjPf: React.FC<InputInputProps> = ({
  tabIndex = 0,
  type,
  id,
  label,
  dataForm,
  className,
  disabled,
  name,
  value,
  autoComplete,
  placeholder,
  required,
  maxLength,
  max,
  onPaste,
  onKeyDown,
  onChange,
}) => {
  const stylePfPj = name === 'rg' ? 'input-tipo-pf' : 'input-tipo-pj';

  return (
    <>
      <div className={`input-container ${stylePfPj}`}>
        {required ? (
          <Input
            tabIndex={tabIndex}
            style={{ fontSize: '16px' }}
            type={type}
            required={required}
            autoComplete={autoComplete}
            id={id}
            name={name}
            label={label}
            value={value}
            onChange={onChange}
            onPaste={onPaste}
            onKeyDown={onKeyDown}
            placeholder={placeholder}
            disabled={disabled}
            className={className}
            aria-label={`Campo de entrada para ${label}`}
            maxLength={maxLength}
          />
        ) : (
          <Input
            style={{ fontSize: '16px' }}
            type={type}
            autoComplete={autoComplete}
            id={id}
            name={name}
            max={max}
            label={label}
            value={value}
            aria-label={`Campo de entrada para ${label}`}
            onChange={onChange}
            onPaste={onPaste}
            onKeyDown={onKeyDown}
            placeholder={placeholder}
            disabled={disabled}
            className={className}
            maxLength={maxLength}
          />
        )}
      </div>
    </>
  );
};

export default React.memo(InputPjPf);
