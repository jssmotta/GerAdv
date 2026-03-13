'use client';
import React, { useRef } from 'react';
import { toDataHora, dataComHora } from '@/app/tools/datetime'; // Importa as funções necessárias
import { TimePicker } from '@progress/kendo-react-dateinputs';

interface InputHoraProps {
  tabIndex?: number;
  id: string;
  label: string;
  type: string;
  className?: string;
  name: string;
  dataForm?: any;
  value: string; 
  onChange: (value: string) => void;
  maxLength?: number;
}

const InputHora: React.FC<InputHoraProps> = ({
  tabIndex = 0,
  id,
  label,
  className,
  name,
  value,
  onChange,
}) => {
  const handleTimeChange = (time: any) => {
    if (time) {
      // Usa a função `dataComHora` para formatar a data no formato "HH:mm"
      const formattedTime = dataComHora(time.value);

      onChange({ target: { name: name, value: formattedTime } } as any); // Propaga no formato desejado
    }
  };
 

  const containerRef = useRef<HTMLDivElement | null>(null);

  const focusOnInput = () => {
    const inputElement = containerRef.current?.querySelector('input') as HTMLInputElement | null;
    if (inputElement) {
      inputElement.focus();
    }
  };
  
  return (
    <div ref={containerRef} className={`input-container-date input-container-timepicker`} onClick={focusOnInput}>      

<style jsx>{`
.k-timepicker .k-picker-wrap {
  max-width: 50px !important;
  }

`}</style>
      <label htmlFor={id} className="input-time-label">
        {label}
      </label>
      <div style={{ display: 'flex', flexDirection: 'row', alignItems: 'flex-end', position: 'relative', maxWidth: '200px', width: '90%' }}>
        <div style={{ flex: 1, position: 'relative' }}>

          <TimePicker
            tabIndex={tabIndex}
            id={id}            
            name={name}
            value={value ? toDataHora(value) : null} // Usa `toDataHora` para converter a string "HH:mm" para um objeto Date
            onChange={handleTimeChange}
            format="HH:mm"            
            aria-label={`Campo de seleção de ${label}`}            
            className='input-time-picker'
            
          />
        </div>
      </div>
    </div>
  );
};

export default React.memo(InputHora);
