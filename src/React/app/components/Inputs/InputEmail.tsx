'use client';
import React, { useState, useEffect } from 'react';
import { InputChangeEvent } from '@progress/kendo-react-inputs';
import InputInput from './InputInput';

interface InputEmailProps {
  tabIndex?: number;
  type?: string;
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
  onChange?: (event: InputChangeEvent) => void;
  onValidChange?: (isValid: boolean) => void;
  maxLength?: number;
}

/**
 * Valida se o email é válido
 */
export const validateEmail = (email: string): boolean => {
  if (!email) return true; // Email é opcional

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email.trim());
};

const InputEmail: React.FC<InputEmailProps> = ({
  type = 'email',
  tabIndex = 0,
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
  onValidChange,
}) => {
  const [isValid, setIsValid] = useState<boolean>(true);
  const [touched, setTouched] = useState<boolean>(false);

  // Valida o email sempre que o valor mudar
  useEffect(() => {
    const emailValue = String(value || '');
    const newIsValid = validateEmail(emailValue);

    setIsValid(newIsValid);

    // Notifica mudança na validação
    if (onValidChange) {
      onValidChange(newIsValid);
    }
  }, [value, onValidChange]);

  const handleBlur = () => {
    setTouched(true);
  };

  const getValidationStatusClass = (): string => {
    if (!touched || !value) return '';
    return isValid ? 'valid' : 'invalid';
  };

  const getValidationMessage = (): string => {
    if (!touched || !value || isValid) return '';
    return 'Email inválido';
  };

  const fieldValid = touched ? isValid : true;
 
  
  return (
    <>
      <div className={`${className || ''}`}>
 
        <InputInput
          tabIndex={tabIndex}          
          type={'email'}
          label={label}
          required={required}
          autoComplete={autoComplete}
          id={id}
          name={name}          
          value={value}
          aria-label={`Campo de entrada para ${label}`}
          onChange={onChange}
          onPaste={onPaste}
          onKeyDown={onKeyDown}
          onBlur={handleBlur}
          placeholder={placeholder}
          disabled={disabled}
          className={className}
          maxLength={maxLength}
          valid={fieldValid}
          validationMessage={getValidationMessage() ? getValidationMessage() : undefined}
        />

        <div className={`validation-status ${getValidationStatusClass()}`}>
          {getValidationMessage()}
        </div>
      </div>
    </>
  );
};

export default React.memo(InputEmail);
