'use client';
import React from 'react';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

interface InputInputProps {
  tabIndex?: number;
  type: string;
  id: string;
  label?: string | React.ReactNode;
  dataForm?: any;
  className?: string;
  name: string;
  value: string | number;
  autoComplete?: string;
  placeholder?: string;
  required?: boolean;
  disabled?: boolean;
  onPaste?: (event: React.ClipboardEvent<HTMLInputElement>) => void;
  onKeyDown?: (event: React.KeyboardEvent<HTMLInputElement>) => void;
  onChange?: (event: InputChangeEvent) => void;
  onBlur?: (event: React.FocusEvent<HTMLInputElement>) => void;
  onFocus?: (event: React.FocusEvent<HTMLInputElement>) => void;
  maxLength?: number;
  iconLabel?: any;
  valid?: boolean;
  title?: string;
  validationMessage?: string;
  style?: React.CSSProperties;
}

const InputInput: React.FC<InputInputProps> = ({
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
  onPaste,
  onKeyDown,
  onChange,
  onBlur,
  onFocus,
  iconLabel,
  valid,
  validationMessage,
  title,
  style
}) => {

  const icon = getIcon( (typeof label === 'string' ? label : undefined) || iconLabel);
  const effectiveIcon = icon || iconLabel;

  return (
    <>
      <div className={`input-container ${ icon || iconLabel ? 'input-container-icon' : ''}`} style={style}>
        
        {label && (
        <label htmlFor={id} className='k-label'>
          {label}
          {required && <span className="required-indicator" aria-label="required" style={{ color: 'red' }}>&nbsp;*</span>}
        </label>
        )}

         {effectiveIcon && (
              <InputAwesomeIcon icon={effectiveIcon} />
            )}

          <Input
            tabIndex={tabIndex}
            style={{ fontSize: '16px' }}
            type={type}
            required={required}
            autoComplete={autoComplete}
            id={id}
            name={name}    
            valid={typeof valid === 'boolean' ? valid : undefined}        
            value={value == '-2147483648' ? '' : value}
            onChange={onChange}
            onPaste={onPaste}
            onKeyDown={onKeyDown}
            onBlur={onBlur}
            onFocus={onFocus}
            placeholder={placeholder}
            aria-label={`Campo de entrada para ${label}`}
            disabled={disabled}
            className={className}
            maxLength={maxLength}            
            validationMessage={validationMessage}
            title={title}
          />
       
      </div>
    </>
  );
};

export default React.memo(InputInput);
