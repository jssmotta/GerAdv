'use client';
import React, { useRef } from 'react';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { parse, format } from 'date-fns';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

interface InputDateProps {
  tabIndex?: number;
  required?: boolean;
  type?: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string; // Alterado para string
  min?: Date | undefined;
  max?: Date | undefined;
  onChange: (value: string) => void; // Retorna string formatada
  disabled?: boolean; 
}

const InputDate: React.FC<InputDateProps> = ({
  tabIndex = 0,
  required,
  type,
  id,
  label,
  dataForm,
  className,
  min,
  max,
  disabled,
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
      onChange(formattedDate); // Retorna a data formatada como string
    } else {
      onChange(''); // Retorna string vazia se a data for limpa
    }
  };

  // Avoid importing MobileContext in tests (some runners mis-handle the module alias)
  const isMobile = false;
  const [isFocused, setIsFocused] = React.useState(false);
  
  const icon = getIcon(label);

  // Função para mostrar informação do dia da semana
  const showNameDayOfWeekInfo = () => {
    if (!parsedValue || isNaN(parsedValue.getTime())) {
      return null;
    }

    const selectedDate = new Date(parsedValue);
    selectedDate.setHours(0, 0, 0, 0);
    
    const today = new Date();
    today.setHours(0, 0, 0, 0);
    
    const tomorrow = new Date(today);
    tomorrow.setDate(tomorrow.getDate() + 1);
    
    const yesterday = new Date(today);
    yesterday.setDate(yesterday.getDate() - 1);
    
    const diffTime = selectedDate.getTime() - today.getTime();
    const diffDays = diffTime / (1000 * 60 * 60 * 24);
    
    // Detecta idioma do navegador
    const browserLang = typeof navigator !== 'undefined' ? navigator.language : 'pt-BR';
    const isPtBr = browserLang.startsWith('pt');
    
    let dayText = '';
    
    if (diffDays === 0) {
      dayText = isPtBr ? 'Hoje' : 'Today';
    } else if (diffDays === 1) {
      dayText = isPtBr ? 'Amanhã' : 'Tomorrow';
    } else if (diffDays === -1) {
      dayText = isPtBr ? 'Ontem' : 'Yesterday';
    } else {
      // Nomes dos dias da semana
      const daysOfWeekPt = ['Domingo', 'Segunda-feira', 'Terça-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sábado'];
      const daysOfWeekEn = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
      
      const dayOfWeek = selectedDate.getDay();
      dayText = isPtBr ? daysOfWeekPt[dayOfWeek] : daysOfWeekEn[dayOfWeek];
    }
    
    return (
      <span style={{ 
        marginLeft: '8px', 
        fontSize: '0.65rem', 
        color: '#666',
        fontStyle: 'italic'
      }}>
        ({dayText})
      </span>
    );
  };

  const containerRef = useRef<HTMLDivElement | null>(null);
  
    const focusOnInput = () => {
      const inputElement = containerRef.current?.querySelector('input') as HTMLInputElement | null;
      if (inputElement) {
        inputElement.focus();
      }
    };
    
  return (
    <div ref={containerRef} className={`input-container-date`} onClick={focusOnInput}>
      <style>{isMobile ? `
        .k-datepicker-x .k-input, 
        .k-datepicker-x .k-picker-wrap, 
        .k-datepicker-x .k-picker-wrap .k-input {
          border-bottom: none !important;
          box-shadow: none !important;
          max-width: calc(100vw - 140px) !important;
        }
      ` : `
        .k-datepicker-x .k-input, 
        .k-datepicker-x .k-picker-wrap, 
        .k-datepicker-x .k-picker-wrap .k-input {
          border-bottom: none !important;
          box-shadow: none !important;
          max-width: 280px !important;
        }
      `}</style>
      {icon && (
        <InputAwesomeIcon icon={icon} inputText={false} />
      )}
      
      <label htmlFor={id} className="input-date-label">
        {label} {showNameDayOfWeekInfo()}
      </label>
      <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'flex-end', position: 'relative', width: '90%' }}>
        <div style={{ flex: 1, position: 'relative' }} className={icon ? `input-container-date-icon` : ''}>
          <DatePicker
            tabIndex={tabIndex}
            id={id}
            name={name}
            min={min}
            max={max}
            disabled={disabled}            
            value={parsedValue}
            onChange={handleChange}
            required={required}
            className={`k-datepicker-x ${className}`}
            format="dd/MM/yyyy"
            aria-label={`Campo de seleção para ${label}`}
            onFocus={() => setIsFocused(true)}
            onBlur={() => setIsFocused(false)}
          />
      
        </div>
        
      </div>
      
    </div>
  );
};

export default React.memo(InputDate);
