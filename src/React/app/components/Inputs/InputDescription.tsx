import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';
import React, { useCallback } from 'react';
import { OperadorLike } from './InputMaster';

interface InputDescriptionProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  className?: string;
  dataForm?: any;
  name: string;
  value: string;
  onChange: (event: InputChangeEvent) => void;
  required?: boolean;
  placeholder?: string;
  disabled?: boolean;
}

const InputDescription: React.FC<InputDescriptionProps> = ({
  tabIndex = 0,
  type,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
  required,
  disabled,
  placeholder,
}) => {

    // Guard against tests that run outside a Redux Provider
    let systemContext: any = undefined;
    try {
      systemContext = useAppSelector(selectSystemContext);
    } catch (e) {
      // If hook throws (no Redux store), fall back to undefined
      systemContext = undefined;
    }

  function isOperadorLike(obj: any): obj is OperadorLike {
    return obj && typeof obj === 'object' && 'senha256' in obj && 'id' in obj;
  }
    const removePercent = useCallback((s: any) => {
      if (typeof s !== 'string') return s;
      return s.replace(/%/g, '');
    }, []);
    const removeLeadingSpaces = useCallback((s: any) => {
      if (typeof s !== 'string') return s;
      return s.replace(/^\s+/, '');
    }, []);
    const handleChange = useCallback((event: InputChangeEvent) => {
      let cleaned = removePercent(event.value);
      if (typeof cleaned === 'string') cleaned = removeLeadingSpaces(cleaned);
      const processedEvent: InputChangeEvent = { ...event, value: cleaned };
      onChange(processedEvent);
    }, [onChange, removePercent]);

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
  
  return (
    <div className={`input-container`}>
      <Input
        tabIndex={tabIndex}
        style={{ fontSize: '16px' }}
        type={type}
        id={id}
        name={name}        
        value={value}
        aria-label={`Campo de entrada para ${label}`}
        disabled={isDisabled()}
        placeholder={placeholder}
        onChange={handleChange}
        onKeyDown={handleKeyDown}
        onPaste={handlePaste}
        required={required}
        label={label.substring(0, 1).toUpperCase() + label.substring(1)}
        className={className}
      />
    </div>
  );
};

export default React.memo(InputDescription);
