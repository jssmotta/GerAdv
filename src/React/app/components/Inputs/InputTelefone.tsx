import React from 'react';
import { MaskedTextBox } from '@progress/kendo-react-inputs';
import InputMemo from './InputMemo';

interface InputTelefoneProps {
  tabIndex?: number;
  type?: string;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  onChange: (e: any) => void;
  placeholder?: string;
  maxLength?: number;
}

const telefoneMask = '(00) 0000-00009';

export const InputTelefone: React.FC<InputTelefoneProps> = ({
  type = 'text',
  id,
  label,
  className,
  name,
  value,
  maxLength = 2048,
  onChange,
  tabIndex = 0,
}) => {
  
  const safeOnChange = (e: any) => {
    if (typeof onChange === 'function') return onChange(e);
    // allow null handlers in tests without throwing
    return undefined;
  };

  return (    
      <InputMemo
        tabIndex={tabIndex}
        data-testid="masked-textbox"
        id={id}
        name={name}
        value={value}
        onChange={safeOnChange}
        aria-label={`Campo de entrada para ${label}`}
        required label={label} maxLength={maxLength}  
        rows={3}
        className="input-default-main"
        cols={200}
     />    
  );
};

export default React.memo(InputTelefone);
