'use client';
import React from 'react';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { parse, format } from 'date-fns';

interface InputDateSingleColumnProps {
  tabIndex?: number;
  required?: boolean;
  type?: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  min?: Date | undefined;
  max?: Date | undefined;
  onChange: (value: string) => void;
}

const InputDateSingleColumn: React.FC<InputDateSingleColumnProps> = ({
  tabIndex = 0,
  required,
  type,
  id,
  label,
  dataForm,
  className,
  min,
  max,
  name,
  value,
  onChange,
}) => {
  // Converte a string para um objeto Date
  const parsedValue = value ? parse(value, 'dd/MM/yyyy', new Date()) : null;

  // Manipula a mudança de valor e retorna como string formatada
  const handleChange = (event: any) => {
    const selectedDate = event.value;
    if (selectedDate) {
      const formattedDate = format(selectedDate, 'dd/MM/yyyy');
      onChange(formattedDate);
    } else {
      onChange('');
    }
  };

  return (
    <div className="input-container input-container-date-single">
      <label htmlFor={id} className="input-date-label-single">
        {label}
      </label>
      <div className="input-date-wrapper-single">
        <DatePicker
          tabIndex={tabIndex}
          id={id}
          name={name}
          min={min}
          max={max}
          value={parsedValue}
          onChange={handleChange}
          required={required}
          className="k-datepicker-single"
          format="dd/MM/yyyy"
        />
      </div>
    </div>
  );
};

export default React.memo(InputDateSingleColumn);