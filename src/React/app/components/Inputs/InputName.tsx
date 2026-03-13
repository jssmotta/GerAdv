'use client';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';
import React, { useCallback } from 'react';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { OperadorLike } from './InputMaster';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

interface InputNameProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  onChange: (event: InputChangeEvent) => void;
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

const InputName: React.FC<InputNameProps> = ({
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
  fontSize = '16px',
  onBlur,
  onFocus,
  maxLength,
  autoTrim = false,
  validator,
  'data-testid': dataTestId,
}) => {
  // Guard useAppSelector() because tests may run without the Redux store Provider
  let systemContext: any = undefined;
  try {
    systemContext = useAppSelector(selectSystemContext);
  } catch (e) {
    systemContext = undefined;
  }

  function isOperadorLike(obj: any): obj is OperadorLike {
    return obj && typeof obj === 'object' && 'senha256' in obj && 'id' in obj;
  }
  
  const removeLeadingSpaces = useCallback((s: any) => {
    if (typeof s !== 'string') return s;
    return s.replace(/^\s+/, '');
  }, []);
  const handleKeyDown = useCallback((e: React.KeyboardEvent<HTMLInputElement>) => {
    const target = e.currentTarget as HTMLInputElement;
    const start = target.selectionStart ?? 0;
    if (e.key === '%') {
      e.preventDefault();
    }
    if (e.key === '*') {
        e.preventDefault();
      }
    if (e.key === ' ' && start === 0) {
      e.preventDefault();
    }
  }, []);

  const handlePaste = useCallback((e: React.ClipboardEvent<HTMLInputElement>) => {
    const paste = e.clipboardData.getData('text');
    if (!paste) return;
    e.preventDefault();
    const sanitizedPaste = paste.replace(/%/g, '').replace(/^\s+/, '');
    const target = e.currentTarget as HTMLInputElement;
    const start = target.selectionStart ?? target.value.length;
    const end = target.selectionEnd ?? start;
    const newValue = target.value.substring(0, start) + sanitizedPaste + target.value.substring(end);
    const processedEvent: InputChangeEvent = { synthetic: true as any, value: newValue } as any;
    onChange(processedEvent);
  }, [onChange]);
  const isDisabled = () => {

    // If caller explicitly set disabled, honor it immediately
    if (disabled) return true;

    if (dataForm == null || dataForm.id == 0) {
      return false;
    }

    // If systemContext is null or undefined, default to not disabled
    if (!systemContext) {
      return disabled || false;
    }

    // If IsMaster is not explicitly true, disable the checkbox
    // This handles cases where IsMaster is undefined, null, false, or missing
    const isMaster = systemContext.IsMaster === true;

    if (isOperadorLike(dataForm)) {
      // If it's an operator-like object, disable if:
      // 1. It's the same user (same ID), OR
      // 2. Current user is not master
      return systemContext.Id === dataForm.id || !isMaster;
    } else {
      // If it's not an operator-like object, disable only if user is not master
      return !isMaster;
    }
  };



  const capitalizeFirstLetter = useCallback((str: string): string => {
    if (!str || str.length === 0) return str;
    return str.charAt(0).toUpperCase() + str.slice(1);
  }, []);

  const handleChange = useCallback((event: InputChangeEvent) => {
    let newValue = event.value;

    if (autoTrim && typeof newValue === 'string') {
      newValue = newValue.trim();
    }

    if (typeof newValue === 'string') {
      newValue = removeLeadingSpaces(newValue);
    }

    if (maxLength && typeof newValue === 'string' && newValue.length > maxLength) {
      newValue = newValue.substring(0, maxLength);
    }

    const processedEvent: InputChangeEvent = {
      ...event,
      value: newValue,
    };

    onChange(processedEvent);
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

  const icon = getIcon(capitalizedLabel || '');    
   
  return (
    <div className={`input-container ${ icon ? 'input-container-icon' : ''}`} data-testid={`${dataTestId || id}-container`}>
     
      {icon && (
           <InputAwesomeIcon icon={icon} />
         )}
         
      <Input
        tabIndex={tabIndex}
        type={type}
        id={id}
        name={name}
        value={value}
        disabled={isDisabled()}
        placeholder={placeholder}
        onChange={handleChange}
        onBlur={handleBlur}
        onFocus={onFocus}
        onKeyDown={handleKeyDown}
        onPaste={handlePaste}
        required={required}
        label={capitalizedLabel}
        className={className}
        maxLength={maxLength}
        style={{ fontSize }}
        data-testid={dataTestId || `input-${name}`}        
        aria-label={capitalizedLabel}
        aria-required={required}
        aria-invalid={validator && value && validator(value) ? 'true' : 'false'}
      />
    </div>
  );
};

export default React.memo(InputName);