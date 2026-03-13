'use client';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';
import { Input, InputChangeEvent } from '@progress/kendo-react-inputs';
import React, { use, useEffect } from 'react';

interface InputUFProps {
  tabIndex?: number;
  id: string;
  label: string;
  dataForm?: any;
  className?: string;
  name: string;
  value: string;
  type?: string;
  placeholder?: string;
  maxLength?: number;
  onChange: (event: InputChangeEvent) => void;
}

const InputUF: React.FC<InputUFProps> = ({
  tabIndex = 0,
  id,
  label,
  dataForm,
  className,
  name,
  value,
  onChange,
}) => {
  const handleChange = (event: InputChangeEvent) => {
    const upperCaseValue = event.value.toUpperCase();
    onChange({ ...event, value: upperCaseValue });
  };

  const icon = getIcon(label || '');

  return (
    <>
      <div className={`input-container input-container-icon`}>
 

        {icon && (
          <InputAwesomeIcon icon={icon} />
        )}

        <Input
          tabIndex={tabIndex}
          style={{ fontSize: '16px', width: '95px' }}
          list={`${id}-datalist`}
          id={id}
          label={label}
          name={name}
          maxLength={2}
          value={value == '' ? ' ' : value.trim()}
          aria-label={`Campo de entrada para ${label}`}
          onChange={handleChange}
          className="input-uf"
        />
      </div>
      <datalist id={`${id}-datalist`}>
        {brazilianUFs.map((uf) => (
          <option key={uf.uf} value={uf.uf + ' - ' + uf.name} />
        ))}
      </datalist>
    </>
  );
};

const brazilianUFs = [
  { uf: 'EX', name: 'Exterior' },
  { uf: 'AC', name: 'Acre' },
  { uf: 'AL', name: 'Alagoas' },
  { uf: 'AP', name: 'Amapá' },
  { uf: 'AM', name: 'Amazonas' },
  { uf: 'BA', name: 'Bahia' },
  { uf: 'CE', name: 'Ceará' },
  { uf: 'DF', name: 'Distrito Federal' },
  { uf: 'ES', name: 'Espírito Santo' },
  { uf: 'GO', name: 'Goiás' },
  { uf: 'MA', name: 'Maranhão' },
  { uf: 'MT', name: 'Mato Grosso' },
  { uf: 'MS', name: 'Mato Grosso do Sul' },
  { uf: 'MG', name: 'Minas Gerais' },
  { uf: 'PA', name: 'Pará' },
  { uf: 'PB', name: 'Paraíba' },
  { uf: 'PR', name: 'Paraná' },
  { uf: 'PE', name: 'Pernambuco' },
  { uf: 'PI', name: 'Piauí' },
  { uf: 'RJ', name: 'Rio de Janeiro' },
  { uf: 'RN', name: 'Rio Grande do Norte' },
  { uf: 'RS', name: 'Rio Grande do Sul' },
  { uf: 'RO', name: 'Rondônia' },
  { uf: 'RR', name: 'Roraima' },
  { uf: 'SC', name: 'Santa Catarina' },
  { uf: 'SP', name: 'São Paulo' },
  { uf: 'SE', name: 'Sergipe' },
  { uf: 'TO', name: 'Tocantins' },
];

export default InputUF;
