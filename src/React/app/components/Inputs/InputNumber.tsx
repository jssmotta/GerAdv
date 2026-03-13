import React from 'react';
import { NumericTextBox } from '@progress/kendo-react-inputs';

interface InputNumberProps {
  tabIndex?: number;
  id?: string;
  label?: string;
  dataForm?: any;
  className?: string;
  name?: string;
  value?: number | null;
  onChange: (e: { target: { name?: string; value: number | null } }) => void;
  maxLength?: number;
  [key: string]: any;
}

const InputNumber: React.FC<InputNumberProps> = ({
  tabIndex = 0,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
  maxLength = 2048,
  ...rest
}) => {
  // Handler para limitar o número de caracteres
  const handleChange = (e: any) => {
    const val = e.value !== null ? e.value.toString() : '';
    if (val.length <= maxLength) {
      onChange({
        target: {
          name,
          value: e.value,
        },
      });
    }
  };

  return (
    <div className={className}>
      {label && <label htmlFor={id}>{label}</label>}
      <NumericTextBox
        id={id}
        name={name}
        aria-label={`Campo de entrada para ${label}`}
        value={value}
        onFocus={(e: any) => e.target.select()}
        onChange={handleChange}        
        {...rest}
      />
    </div>
  );
};

export default InputNumber;