'use client';
import { Input } from '@progress/kendo-react-inputs';
import React from 'react';

interface InputInputSingleColumnProps {
  tabIndex?: number;
  type: string;
  id: string;
  label?: string;
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
  onChange?: (event: any) => void;
  maxLength?: number;
}

const InputInputSingleColumn: React.FC<InputInputSingleColumnProps> = ({
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
}) => {
  const handleChange = (e: any) => {
    if (onChange) {
      onChange({
        target: {
          name: e.target.name,
          value: e.target.value
        }
      });
    }
  };
  const label15 = label ? label.length > 20 ? label.slice(0, 20) : label : '';

  return (
    <div 
      style={{
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        height: '32px',
        margin: '2px 0',
        padding: '0',
        width: '100%',
        boxSizing: 'border-box'
      }}
    >
      <div 
        style={{
          flex: '0 0 15%',
          width: '15%',
          textAlign: 'right',
          paddingRight: '8px',
          fontWeight: '500',
          color: '#333',
          fontSize: '12px',
          margin: '0',
          boxSizing: 'border-box'
        }}
      >
        {label15}
      </div>
      <div 
        style={{
          flex: '0 0 85%',
          width: '85%',
          maxWidth: '85%',
          boxSizing: 'border-box'
        }}
      >
        <Input
          type={type}
          id={id}
          name={name}
          value={value || ''}
          onChange={handleChange}
          onPaste={onPaste}
          onKeyDown={onKeyDown}
          placeholder={label || placeholder}
          required={required}
          disabled={disabled}
          maxLength={maxLength}
          autoComplete={autoComplete}
          style={{
            width: '100%',
            height: '28px',
            border: 'none',
            borderBottom: '1px solid #ccc',
            borderRadius: '0',
            backgroundColor: 'transparent',
            fontSize: '12px',
            fontFamily: 'inherit',
            boxSizing: 'border-box',
            padding: '4px 8px',
            outline: 'none'
          }}
          onFocus={(e) => {
            e.target.style.borderBottom = '1px solid var(--focus-color-inputs)';
          }}
          onBlur={(e) => {
            e.target.style.borderBottom = '1px solid #ccc';
          }}
        />
      </div>
    </div>
  );
};

export default React.memo(InputInputSingleColumn);