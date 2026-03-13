'use client';
import React, { useState, useEffect } from 'react';
import { MaskedTextBox } from '@progress/kendo-react-inputs';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

/**
 * Interface para as propriedades específicas do InputCpf
 */
export interface InputCpfProps {
 
  value?: string;
  onChange?: (event: any) => void;
  onBlur?: (event: any) => void;
  onValidChange?: (isValid: boolean) => void;
  onValueChange?: (value: string | undefined) => void;
  dataForm?: any;
  validationMessage?: string;
  valid?: boolean;
  name?: string;
  label?: string;
  id?: string;
  className?: string;
  placeholder?: string;
  disabled?: boolean;
  readOnly?: boolean;
  required?: boolean;
  tabIndex?: number;
  title?: string;
  type?: string;
}

/**
 * Formata o CPF para o padrão XXX.XXX.XXX-XX
 */
export const formatCpf = (cpf: string): string => {
  // Remove caracteres não numéricos
  const cleanCpf = cpf.replace(/\D/g, '');

  // Se não tiver nada, retorna vazio
  if (!cleanCpf) return '';

  // Se tiver 11 dígitos, formata
  if (cleanCpf.length === 11) {
    return cleanCpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
  }

  // Se tiver menos de 11 dígitos, retorna como está
  return cpf;
};

/**
 * Valida se o CPF é válido usando o algoritmo oficial
 */
export const validateCpf = (cpf: string): boolean => {
  // Remove caracteres não numéricos
  const cleanCpf = cpf.replace(/\D/g, '');

  // Se não tiver 11 dígitos, não é válido
  if (cleanCpf.length !== 11) return false;

  // Elimina CPFs com todos os dígitos iguais
  if (/^(\d)\1{10}$/.test(cleanCpf)) return false;

  // Calcula o primeiro dígito verificador
  let sum = 0;
  for (let i = 0; i < 9; i++) {
    sum += parseInt(cleanCpf.charAt(i)) * (10 - i);
  }
  let remainder = sum % 11;
  const firstVerifier = remainder < 2 ? 0 : 11 - remainder;

  // Calcula o segundo dígito verificador
  sum = 0;
  for (let i = 0; i < 10; i++) {
    sum += parseInt(cleanCpf.charAt(i)) * (11 - i);
  }
  remainder = sum % 11;
  const secondVerifier = remainder < 2 ? 0 : 11 - remainder;

  // Verifica se os dígitos calculados são iguais aos dígitos informados
  return (
    parseInt(cleanCpf.charAt(9)) === firstVerifier &&
    parseInt(cleanCpf.charAt(10)) === secondVerifier
  );
};

/**
 * Componente InputCpf Simplificado
 * Usa formatação nativa do MaskedTextBox + validação de CPF
 */
const InputCpf: React.FC<InputCpfProps> = (props) => {
  const {
    value,
    onChange,
    onBlur,
    onValidChange,
    onValueChange,
    dataForm,
    validationMessage,
    valid,
    name,
    id,
    className,
    disabled,
    readOnly,
    required,
    tabIndex,
    title,
    ...otherProps
  } = props;

  const [isValid, setIsValid] = useState<boolean>(false);
  const [touched, setTouched] = useState<boolean>(false);

  // Valida o CPF sempre que o valor mudar
  useEffect(() => {
    const inputValue = (value as string) || '';
    const newIsValid = validateCpf(inputValue);

    setIsValid(newIsValid);

    // Notifica mudança na validação
    if (onValidChange) {
      onValidChange(newIsValid);
    }
  }, [value, onValidChange]);

  // Handler para onChange - apenas repassa o evento
  const handleChange = (event: any) => {
    if (onChange) {
      onChange({
        target: {
          name: name,
          value: event.target.value,
        },
      });
    }

    // Se precisar do valor limpo
    if (onValueChange) {
      const cleanValue = event.target.value.replace(/\D/g, '');
      onValueChange(cleanValue);
    }
  };

  // Handler para onBlur
  const handleBlur = (event: any) => {
    setTouched(true);
    if (onBlur) {
      onBlur(event);
    }
  };

  // Determina validade do campo
  const fieldValid = touched ? isValid : valid !== undefined ? valid : true;

  // Converte value para string de forma mais segura e formata o CPF
  const stringValue = React.useMemo(() => {
    if (value === null || value === undefined) return '';
    const strValue = String(value);
    // Formata o CPF se vier do backend sem formatação
    return formatCpf(strValue);
  }, [value]);

  const getValidationStatusClass = (): string => {
    if (isValid) {
      return 'valid';
    }

    return 'invalid';
  };

  const getValidationMessage = (): string => {
    if (isValid) {
      return '';
    } else {
      const cpf = value?.replace(/\D/g, '') ?? '';
      if (cpf.length !== 11) return '';

      return 'Digito verificador do CPF inválido.';
    }
  };
  const icon = getIcon('CPF');

  return (
    <>
      <div className='input-container input-tipo-pf input-container-icon2'>

        <label htmlFor={id} className='k-label'>
          {'CPF'}{required && ' *'}
        </label>

         {icon && (
              <InputAwesomeIcon icon={icon} />
            )}

        <MaskedTextBox
          tabIndex={tabIndex}
          id={id}
          name={name}
          className={className} 
          value={stringValue}
          onChange={handleChange}
          onBlur={handleBlur}
          valid={fieldValid}
          validationMessage={validationMessage || 'CPF inválido'}
          placeholder="XXX.XXX.XXX-XX"
          mask="000.000.000-00"
          maskValidation={false}
          aria-label='Campo de entrada de CPF'
          disabled={disabled}
          required={required}  
          title={title}
        />{' '}
        <div className={`validation-status ${getValidationStatusClass()}`}>
          {getValidationMessage()}
        </div>
      </div>
    </>
  );
};

export default React.memo(InputCpf);
