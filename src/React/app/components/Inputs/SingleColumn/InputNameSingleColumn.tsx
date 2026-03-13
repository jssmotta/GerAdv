'use client';
import { Input } from '@progress/kendo-react-inputs';
import { on } from 'events';
import React, { useCallback } from 'react';

interface InputNameSingleColumnProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  onChange: (event: any) => void;
  required?: boolean;
  placeholder?: string;
  disabled?: boolean;
  fontSize?: string | number;
  onBlur?: (event: React.FocusEvent<HTMLInputElement>) => void;
  onFocus?: (event: React.FocusEvent<HTMLInputElement>) => void;
  maxLength?: number;
  autoTrim?: boolean;
  validator?: (value: string) => string | null;
  'data-testid'?: string;
}

const InputNameSingleColumn: React.FC<InputNameSingleColumnProps> = ({
  tabIndex = 0,
  type,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
  required = false,
  disabled = false,
  placeholder,
  fontSize = '12px',
  onBlur,
  onFocus,
  maxLength,
  autoTrim = false,
  validator,
  'data-testid': dataTestId,
}) => {
  const capitalizeFirstLetter = useCallback((str: string): string => {
    if (!str || str.length === 0) return str;
    return str.charAt(0).toUpperCase() + str.slice(1);
  }, []);

  const handleChange = useCallback((event: any) => {
    let newValue = event.target.value;

    if (autoTrim && typeof newValue === 'string') {
      newValue = newValue.trim();
    }

    if (maxLength && newValue.length > maxLength) {
      newValue = newValue.substring(0, maxLength);
    }

    if (onChange) {
      onChange({
        target: {
          name: event.target.name,
          value: newValue
        },
        value: newValue
      });
    }
  }, [onChange, autoTrim, maxLength]);

  const handleBlur = useCallback((event: React.FocusEvent<HTMLInputElement>) => {
    if (validator && value) {
      const validationError = validator(value);
      if (validationError) {
        console.warn(`Validation error for ${name}: ${validationError}`);
      }
    }

    if (onBlur) {
      onBlur(event);
    }
  }, [validator, value, name, onBlur]);

  const capitalizedLabel = capitalizeFirstLetter(label);

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
      data-testid={`${dataTestId || id}-container`}
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
        {capitalizedLabel}
        {required && <span style={{ color: 'red', marginLeft: '2px' }}>*</span>}
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
          placeholder={placeholder}
          required={required}
          disabled={disabled}
          maxLength={maxLength}
          data-testid={dataTestId || `input-${name}`}
          aria-label={capitalizedLabel}
          aria-required={required}
          aria-invalid={validator && value && validator(value) ? 'true' : 'false'}
          style={{
            width: '100%',
            height: '28px',
            border: 'none',
            borderBottom: '1px solid #ccc',
            borderRadius: '0',
            backgroundColor: 'transparent',
            fontSize: fontSize || '12px',
            fontFamily: 'inherit',
            boxSizing: 'border-box',
            padding: '4px 8px',
            outline: 'none'
          }}
          onFocus={(e:any) => {
            e.target.style.borderBottom = '1px solid var(--focus-color-inputs)';
            if (onFocus) onFocus(e);
          }}
          onBlur={(e:any) => {
            e.target.style.borderBottom = '1px solid #ccc';
            onBlur && onBlur(e);
            handleBlur(e);
          }}
        />
      </div>
    </div>
  );
};

export default React.memo(InputNameSingleColumn);