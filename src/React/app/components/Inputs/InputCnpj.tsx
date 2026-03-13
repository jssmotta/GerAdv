'use client';
import React, { useState, useEffect, useMemo } from 'react';
import {
  MaskedTextBox,
  MaskedTextBoxProps,
  MaskedTextBoxChangeEvent,
} from '@progress/kendo-react-inputs';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

export interface InputCnpjProps extends MaskedTextBoxProps {
  onValidChange?: (isValid: boolean) => void;
  onValueChange?: (value: string) => void;
  dataForm?: any;
  type?: string;
  tabIndex?: number;
}

/**
 * Regra customizada para posições alfanuméricas do CNPJ:
 * Aceita A-Z e 0-9 (a regex /[A-Za-z0-9]/ aceita minúsculas que serão
 * convertidas para maiúsculas no handleChange)
 */
const cnpjAlphaNumericRule = /[A-Za-z0-9]/;

/**
 * Rules customizadas para o MaskedTextBox do KendoReact.
 * "N" = nossa regra alfanumérica (substitui a built-in "A" para evitar
 * conflito caso o Kendo mude o comportamento padrão)
 */
const cnpjMaskRules = {
  N: cnpjAlphaNumericRule,
};

/**
 * Máscara do CNPJ alfanumérico:
 * - "N" nas 12 primeiras posições (aceita letra ou dígito)
 * - "0" nas 2 últimas posições (DV, só dígito)
 * - Pontos, barra e hífen são literais
 */
const CNPJ_MASK = 'NN.NNN.NNN/NNNN-00';

/**
 * Remove máscara do CNPJ e converte para maiúsculas
 */
const removeMascaraCnpj = (cnpj: string): string =>
  cnpj.toUpperCase().replace(/[^A-Z0-9]/g, '');

/**
 * Formata o CNPJ para o padrão XX.XXX.XXX/XXXX-XX
 */
export const formatCnpj = (cnpj: string): string => {
  const clean = removeMascaraCnpj(cnpj);
  if (!clean) return '';
  if (clean.length === 14) {
    return `${clean.substring(0, 2)}.${clean.substring(2, 5)}.${clean.substring(5, 8)}/${clean.substring(8, 12)}-${clean.substring(12, 14)}`;
  }
  return cnpj;
};

/**
 * Converte caractere do CNPJ para valor de cálculo (ASCII - 48)
 * Dígitos: '0'=0 ... '9'=9
 * Letras:  'A'=17, 'B'=18 ... 'Z'=42
 */
const cnpjCharToValue = (c: string): number => c.charCodeAt(0) - 48;

/**
 * Valida CNPJ numérico ou alfanumérico (Receita Federal 2026)
 * Algoritmo: Módulo 11 com conversão ASCII - 48
 */
export const validateCnpj = (cnpj: string): boolean => {
  const clean = removeMascaraCnpj(cnpj);

  if (clean.length !== 14) return false;

  // 12 primeiros: alfanuméricos; 2 últimos: numéricos (DV)
  if (!/^[A-Z0-9]{12}[0-9]{2}$/.test(clean)) return false;

  // Rejeita sequência de caracteres iguais
  if (clean.split('').every(c => c === clean[0])) return false;

  // Converte para valores usando ASCII - 48
  const valores = clean.split('').map(cnpjCharToValue);

  // Primeiro dígito verificador
  const peso1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
  let soma = 0;
  for (let i = 0; i < 12; i++) {
    soma += valores[i] * peso1[i];
  }
  let resto = soma % 11;
  const dv1 = resto < 2 ? 0 : 11 - resto;

  if (valores[12] !== dv1) return false;

  // Segundo dígito verificador
  const peso2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
  soma = 0;
  for (let i = 0; i < 13; i++) {
    soma += valores[i] * peso2[i];
  }
  resto = soma % 11;
  const dv2 = resto < 2 ? 0 : 11 - resto;

  return valores[13] === dv2;
};

const InputCnpj: React.FC<InputCnpjProps> = ({
  value,
  onChange,
  onBlur,
  onFocus,
  onValidChange,
  onValueChange,
  validationMessage,
  valid,
  tabIndex = 0,
  ...otherProps
}) => {
  const [isValid, setIsValid] = useState<boolean>(false);
  const [touched, setTouched] = useState<boolean>(false);

  useEffect(() => {
    const cleanValue = removeMascaraCnpj((value as string) || '');
    const newIsValid = validateCnpj(cleanValue);
    setIsValid(newIsValid);
    if (onValidChange) onValidChange(newIsValid);
  }, [value, onValidChange]);

  const handleChange = (event: MaskedTextBoxChangeEvent) => {
    // Força uppercase no valor (o MaskedTextBox aceita minúsculas pela regex)
    if (event.value) {
      event.value = event.value.toUpperCase();
    }
    if (onChange) onChange(event);
    const cleanValue = removeMascaraCnpj(event.value || '');
    if (onValueChange) onValueChange(cleanValue.padStart(14, '0'));
  };

  const handleBlur = (event: any) => {
    setTouched(true);
    if (onBlur) onBlur(event);
  };

  const fieldValid = touched ? isValid : valid;

  const getValidationStatusClass = (): string => {
    return isValid ? 'valid' : 'invalid';
  };

  const getValidationMessage = (): string => {
    if (isValid) return '';
    const cnpj = removeMascaraCnpj((value as string) ?? '');
    if (cnpj.length !== 14) return '';
    return 'Dígito verificador do CNPJ inválido.';
  };

  const icon = getIcon('cnpj');

  const formattedValue = useMemo(() => {
    if (value === null || value === undefined) return '';
    const strValue = String(value);
    return formatCnpj(strValue);
  }, [value]);

  return (
    <>
      {getValidationMessage() !== '' && (
        <style>
          {`
          .buttonCrudOk {
            opacity: 0.5 !important;
            pointer-events: none !important;
          }
        `}
        </style>
      )}
      <div className='input-container input-tipo-pj input-container-icon2'>
        {icon && <InputAwesomeIcon icon={icon} />}

        <MaskedTextBox
          {...otherProps}
          tabIndex={tabIndex}
          style={{ fontSize: '16px' }}
          value={formattedValue}
          onChange={handleChange}
          onBlur={handleBlur}
          onFocus={onFocus}
          mask={CNPJ_MASK}
          rules={cnpjMaskRules}
          aria-label='Campo de entrada de CNPJ'
          valid={fieldValid}
          validationMessage={validationMessage || 'CNPJ inválido'}
          placeholder={otherProps.placeholder || 'XX.XXX.XXX/XXXX-XX'}
        />
        <div className={`validation-status ${getValidationStatusClass()}`}>
          {getValidationMessage()}
        </div>
      </div>
    </>
  );
};

export default React.memo(InputCnpj);
