'use client';
import React from 'react';
import { TextArea } from '@progress/kendo-react-inputs';

interface InputMemoSingleColumnProps {
  tabIndex?: number;
  type?: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  maxLength?: number;
  placeholder?: string;
  required?: boolean;
  disabled?: boolean;
  rows?: number;
  onChange?: (event: any) => void;
}

const InputMemoSingleColumn: React.FC<InputMemoSingleColumnProps> = ({
  tabIndex = 0,
  type,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  maxLength,
  placeholder,
  required,
  disabled,
  rows = 3,
  onChange,
}) =>
  {
    const label15 = label ? label.length > 20 ? label.slice(0, 20) : label : '';
   
  return (
    <div 
      style={{
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'flex-start',
        height: '56px',
        minHeight: '56px',
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
          paddingTop: '8px',
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
          boxSizing: 'border-box', 
        }}
      >
        <TextArea
          id={id}
          name={name}
          value={value || ''}
          onChange={onChange}
          placeholder={label || placeholder}
          required={required}
          disabled={disabled}
          maxLength={maxLength}
          rows={rows}
          style={{
            width: '100%',
            minHeight: '48px',
            height: '48px',
            border: 'none',
            borderBottom: '1px solid #ccc',
            borderRadius: '0',
            backgroundColor: 'transparent',
            fontSize: '12px',
            fontFamily: 'inherit',
            resize: 'none',
            boxSizing: 'border-box',
            padding: '4px 8px',
            lineHeight: '1.4',
            outline: 'none'
          }}
          onFocus={(e:any) => {
            e.target.style.borderBottom = '1px solid var(--focus-color-inputs)';
          }}
          onBlur={(e:any) => {
            e.target.style.borderBottom = '1px solid #ccc';
          }}
        />
      </div>
    </div>
  );
};

export default React.memo(InputMemoSingleColumn);