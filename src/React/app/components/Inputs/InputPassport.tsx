'use client';
import React, { useState, useEffect, useCallback } from 'react';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';
import InputInput from './InputInput';

interface InputPassportProps {
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

const InputPassport: React.FC<InputPassportProps> = ({
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

  const removeLeadingSpaces = useCallback((s: any) => {
    if (typeof s !== 'string') return s;
    return s.replace(/^\s+/, '');
  }, []);

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

  const handleKeyDownInternal = useCallback((e: React.KeyboardEvent<HTMLInputElement>) => {
    const target = e.currentTarget as HTMLInputElement;
    const start = target.selectionStart ?? 0;
    if (e.key === ' ' && start === 0) {
      e.preventDefault();
      return;
    }

    if (onKeyDown) onKeyDown(e);
  }, [onKeyDown]);

  const handlePasteInternal = useCallback((e: React.ClipboardEvent<HTMLInputElement>) => {
    const paste = e.clipboardData.getData('text');
    if (!paste) return;
    e.preventDefault();
    const sanitizedPaste = paste.replace(/^\s+/, '');
    const target = e.currentTarget as HTMLInputElement;
    const start = target.selectionStart ?? target.value.length;
    const end = target.selectionEnd ?? start;
    const newValue = target.value.substring(0, start) + sanitizedPaste + target.value.substring(end);
    const processedEvent: InputChangeEvent = { synthetic: true as any, value: newValue } as any;
    if (onChange) onChange(processedEvent);
  }, [onChange]);

  const handleChangeInternal = useCallback((event: InputChangeEvent) => {
    let newValue = event.value;
    if (typeof newValue === 'string') {
      newValue = removeLeadingSpaces(newValue);
    }
    const processedEvent: InputChangeEvent = { ...event, value: newValue } as any;
    if (onChange) onChange(processedEvent);
  }, [onChange, removeLeadingSpaces]);

  const getValidationStatusClass = (): string => {
    if (!touched || !value) return '';
    return isValid ? 'valid' : 'invalid';
  };

  const getValidationMessage = (): string => {
    if (!touched || !value || isValid) return '';
    return 'Email inválido';
  };

  const fieldValid = touched ? isValid : true;

  const displayValue = typeof value === 'string' ? removeLeadingSpaces(value) : value;

 
  return (
    <>
     {dataForm.id === 0 && (
      <div>              
        <InputInput
          label={'E-mail da conta (não poderá ser alterado)'}
          tabIndex={tabIndex}          
          type={'email'}
          required={true}
          autoComplete={autoComplete}
          id={id}
          name={name}          
          value={displayValue}
          aria-label={`Campo de entrada para ${label}`}
          onChange={handleChangeInternal}
          onPaste={handlePasteInternal}
          onKeyDown={handleKeyDownInternal}
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
     )}
    </>
  );
};

export default React.memo(InputPassport);
