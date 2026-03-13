'use client';
import React from 'react';
import { Input } from '@progress/kendo-react-inputs';

interface InputGuidProps {
  tabIndex?: number;
  type: string;
  id: string;
  label?: string;
  dataForm?: any;
  className?: string;
  name: string;
  value?: string;
  autoComplete?: string;
  placeholder?: string;
  required?: boolean;
  disabled?: boolean;
  onPaste?: (event: React.ClipboardEvent<HTMLInputElement>) => void;
  onKeyDown?: (event: React.KeyboardEvent<HTMLInputElement>) => void;
  // recebe string e devolve string (valor formatado)
  onChange?: (value: string) => void;
  maxLength?: number;
}

const GUID_MAX_LENGTH = 36; // 32 hex chars + 4 hyphens
const HEX_MAX = 32;

const formatGuid = (input?: string) => {
  if (!input) return '';
  // remove non-hex characters
  const hex = input.replace(/[^0-9a-fA-F]/g, '').slice(0, HEX_MAX).toUpperCase();
  if (!hex) return '';
  const parts = [
    hex.slice(0, 8),
    hex.slice(8, 12),
    hex.slice(12, 16),
    hex.slice(16, 20),
    hex.slice(20, 32),
  ].filter(Boolean);
  return parts.join('-');
};

const isValidGuid = (value?: string) => {
  if (!value) return true; // treat empty as valid (validation can be enforced by `required`)
  const regex = /^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$/i;
  return regex.test(value);
};

const InputGuid: React.FC<InputGuidProps> = ({
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
  const displayValue = formatGuid(String(value ?? ''));
  const ariaInvalid = !isValidGuid(displayValue);

  const handleChange = (event: any) => {
    const raw = String(event.target?.value ?? '');
    const formatted = formatGuid(raw);
    if (onChange) {
      onChange(formatted);
    }
  };

  return (
    <>
      <div className={`input-container`}>
        <Input
          tabIndex={tabIndex}
          style={{ fontSize: '16px' }}
          type={type}
          required={required}
          autoComplete={autoComplete}
          id={id}
          name={name}
          label={label}
          value={displayValue}
          onChange={handleChange}
          onPaste={onPaste}
          onKeyDown={onKeyDown}
          placeholder={placeholder}
          aria-label={`Valor Guid`}
          aria-invalid={ariaInvalid}
          disabled={disabled}
          className={className}
          maxLength={maxLength ?? GUID_MAX_LENGTH}
        />
      </div>
    </>
  );
};

export default React.memo(InputGuid);
