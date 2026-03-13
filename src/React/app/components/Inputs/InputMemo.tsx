"use client";
import React from 'react';
import { TextArea } from '@progress/kendo-react-inputs';

interface InputMemoProps {
  tabIndex?: number;
  type?: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  required?: boolean;
  disabled?: boolean;
  rows?: number;
  cols?: number;
  onChange: (event: React.ChangeEvent<HTMLTextAreaElement>) => void;
  maxLength: number;
  placeholder?: string;
  error?: string;
  helpText?: string;
  showCharacterCount?: boolean;
  onBlur?: (event: React.FocusEvent<HTMLTextAreaElement>) => void;
  onFocus?: (event: React.FocusEvent<HTMLTextAreaElement>) => void;
}

const InputMemo = React.forwardRef<HTMLTextAreaElement, InputMemoProps>(({
  tabIndex = 0,
  type = 'memo',
  rows = 4,
  cols = 50,
  id,
  required = false,
  label,
  dataForm,
  className = '',
  disabled = false,
  name,
  value,
  onChange,
  maxLength,
  placeholder,
  error,
  helpText,
  showCharacterCount = false,
  onBlur,
  onFocus,
}, ref) => {
  const [isFocused, setIsFocused] = React.useState(false);

  React.useEffect(() => {
    if (process.env.NODE_ENV === 'development') {
      if (!id) console.warn('InputMemo: id is required');
      if (!name) console.warn('InputMemo: name is required');
      if (!label) console.warn('InputMemo: label is required');
      if (maxLength <= 0) console.warn('InputMemo: maxLength should be greater than 0');
    }
  }, [id, name, label, maxLength]);

  // Ensure value is never null or undefined
  const safeValue = value ?? '';
  const currentLength = safeValue.length;
  const isError = !!error;
  const isMaxLength = currentLength >= maxLength;

  const containerClasses = [
    'input-container input-container-textarea',
    className,
    isError ? 'input-container--error' : '',
    disabled ? 'input-container--disabled' : '',
  ].filter(Boolean).join(' ');

  const labelClasses = [
    'k-floating-label',
    required ? 'k-floating-label--required' : '',
    isError ? 'k-floating-label--error' : '',
  ].filter(Boolean).join(' ');

  return (
    <div className={containerClasses} style={{ margin: 0, marginBottom: 0 }}>
      <div
        className={labelClasses}
        style={{ width: '100%', display: 'block', margin: 0 }}
      >
        {label}
        {required && <span className="required-indicator" aria-label="required" style={{ color: 'red' }}>&nbsp;*</span>}
      </div>
      
      <TextArea
        tabIndex={tabIndex}
        ref={ref as any}
        id={id}
        name={name}
        value={safeValue}
        required={required}
        disabled={disabled}
        rows={rows}
        cols={cols}
        maxLength={maxLength}
        placeholder={placeholder}
        onChange={onChange as any}
        onBlur={(e: any) => { setIsFocused(false); onBlur && onBlur(e as any); }}
        onFocus={(e: any) => { setIsFocused(true); onFocus && onFocus(e as any); }}
        aria-label={label}
        aria-describedby={
          [
            error ? `${id}-error` : '',
            helpText ? `${id}-help` : '',
            showCharacterCount ? `${id}-count` : '',
          ].filter(Boolean).join(' ') || undefined
        }
        aria-invalid={isError}
        className="k-textarea"
        style={{
          width: '100%',
          display: 'block',
          fontSize: '16px',
          border: 'none',
          borderTop: 'none',
          borderLeft: 'none',
          borderRight: 'none',
          borderBottom: 'none',
          borderBottomColor: 'transparent',
          // Also set borderColor on the textarea when there is an error so tests can assert it
          borderColor: isError ? '#d32f2f' : undefined,
          boxShadow: 'none',
          WebkitBoxShadow: 'none',
          MozBoxShadow: 'none',
          outline: 'none',
          backgroundColor: disabled ? '#f5f5f5' : 'white',
          margin: 0,
          padding: 0,
          borderRadius: 0,
          fontFamily: 'inherit',
          resize: 'none',
          boxSizing: 'border-box',
          zIndex: 999
        }}
        data-testid="textarea"
      />
      <div style={{
        width: '100%',
        height: 0,
        borderBottom: isError
          ? '1px solid #d32f2f'
          : isFocused
            ? '1px solid var(--focus-color-inputs)'
            : '1px solid #ccc',
        pointerEvents: 'none',
        position: 'relative',
        zIndex: 1000
      }} />

      {error && (
        <div 
          id={`${id}-error`}
          className="input-error"
          role="alert"
          style={{ color: '#d32f2f', fontSize: '14px', marginTop: 0 }}
        >
          {error}
        </div>
      )}

      {helpText && !error && (
        <div 
          id={`${id}-help`}
          className="input-help"
          style={{ color: '#666', fontSize: '14px', marginTop: 0 }}
        >
          {helpText}
        </div>
      )}

      {showCharacterCount && (
        <div 
          id={`${id}-count`}
          className="character-count"
          style={{ 
            color: isMaxLength ? '#d32f2f' : '#666', 
            fontSize: '12px', 
            textAlign: 'right',
            marginTop: 0
          }}
        >
          {currentLength}/{maxLength}
        </div>
      )}
    </div>
  );
});

InputMemo.displayName = 'InputMemo';

export default React.memo(InputMemo);