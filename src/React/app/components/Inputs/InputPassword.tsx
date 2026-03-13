'use client';
import React from 'react';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';

interface InputPasswordProps {
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
  onChange?: (event: InputChangeEvent) => void;
  maxLength?: number;
}

const InputPassword: React.FC<InputPasswordProps> = ({
  tabIndex = 0,
  type,
  id,
  label,
  dataForm,
  className,
  disabled,
  name,
  value,
  autoComplete = "off",
  placeholder,
  required = false,
  maxLength,
  onPaste,
  onKeyDown,
  onChange,
}) => {
  let systemContext: any = undefined;
  try {
    systemContext = useAppSelector(selectSystemContext);
  } catch (e) {
    systemContext = undefined;
  }

  if (!systemContext?.IsMaster) {
    return null;
  }

  return (
    <div className="input-container">
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
        aria-label={`Campo de entrada senha para ${label}`}
        onChange={onChange}
        onPaste={onPaste}
        onKeyDown={onKeyDown}
        placeholder={placeholder}
        disabled={disabled}
        className={className}
        maxLength={maxLength}
      />
    </div>
  );
};

const areEqual = (prevProps: InputPasswordProps, nextProps: InputPasswordProps) => {
  return (
    prevProps.value === nextProps.value &&
    prevProps.disabled === nextProps.disabled &&
    prevProps.required === nextProps.required &&
    prevProps.className === nextProps.className &&
    prevProps.placeholder === nextProps.placeholder &&
    prevProps.maxLength === nextProps.maxLength
  );
};

export default React.memo(InputPassword, areEqual);