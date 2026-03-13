'use client';
import React, { useState, useEffect } from 'react';
import { Input, InputProps } from '@progress/kendo-react-inputs';
import { getIcon, InputAwesomeIcon } from '@/app/tools/iconMapperInput';

/**
 * Interface para os dados retornados pela API ViaCEP
 */
export interface CepData {
  cep: string;
  logradouro: string;
  complemento: string;
  bairro: string;
  localidade: string;
  uf: string;
  ibge: string;
  gia: string;
  ddd: string;
  siafi: string;
  erro?: boolean;
}

/**
 * Interface para as propriedades específicas do InputCep
 * Estende as propriedades padrão do Input do Kendo UI
 * Mantém compatibilidade total com versão anterior
 */
export interface InputCepProps extends InputProps {
  onValidChange?: (isValid: boolean) => void;
  onValueChange?: (value: string) => void;
  onAddressFound?: (addressData: CepData | null) => void;
  dataForm?: any;
  tabIndex?: number;
}

/**
 * Aplica máscara de CEP (XX.XXX-XXX)
 */
const applyMask = (value: string): string => {
  // Remove tudo que não for dígito
  const cleanValue = value.replace(/\D/g, '');

  // Limita o tamanho para 8 caracteres
  const limitedValue = cleanValue.slice(0, 8);

  // Aplica a máscara
  return limitedValue
    .replace(/^(\d{2})(\d{3})(\d{3})$/, '$1.$2-$3')
    .replace(/^(\d{2})(\d{3})$/, '$1.$2')
    .replace(/^(\d{2})$/, '$1');
};

/**
 * Remove a máscara do CEP
 */
const removeMask = (value: string): string => {
  return value.replace(/\D/g, '');
};

/**
 * Valida se o CEP é válido
 */
export const validateCep = (cep: string): boolean => {
  // CEP deve ter exatamente 8 dígitos
  return cep.length === 8;
};

/**
 * Busca dados do CEP na API ViaCEP
 */
const fetchCepData = async (cep: string): Promise<CepData | null> => {
  try {
    const response = await fetch(`https://viacep.com.br/ws/${cep}/json/`);

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data: CepData = await response.json();

    // Verifica se a API retornou erro
    if (data.erro) {
      return null;
    }

    return data;
  } catch (error) {
    console.error('Erro ao buscar CEP:', error);
    return null;
  }
};

/**
 * Componente InputCep
 * Estende o Input do Kendo UI para lidar com formatação e validação de CEP
 * Mantém 100% de compatibilidade com a versão anterior
 * Adiciona validação online via API ViaCEP internamente
 */
const InputCep: React.FC<InputCepProps> = (props) => {
  const {
    value,
    onChange,
    onBlur,
    onFocus,
    onValidChange,
    onValueChange,
    onAddressFound,
    validationMessage,
    dataForm,
    valid,
    tabIndex = 0,
    ...otherProps
  } = props;

  const [isValid, setIsValid] = useState<boolean>(false);
  const [touched, setTouched] = useState<boolean>(false);
  const [addressData, setAddressData] = useState<CepData | null>(null);

  // Função para disparar evento onChange para outros campos
  const triggerChangeEvent = (fieldName: string, fieldValue: string) => {
    if (onChange) {
      // Create a synthetic event similar to Kendo's InputChangeEvent
      const syntheticEvent = {
        syntheticEvent: {} as React.SyntheticEvent<any>,
        nativeEvent: {} as Event,
        value: fieldValue,
        target: {
          name: fieldName,
          value: fieldValue,
        },
      };
      onChange(syntheticEvent as any);
    }
  };

  // Função para validar CEP online
  const validateCepOnline = async (cleanCep: string) => {
    if (cleanCep.length !== 8) {
      return;
    }

    try {
      const data = await fetchCepData(cleanCep);

      if (data) {
        setAddressData(data);

        // Dispara eventos onChange automáticos para preencher outros campos

        if (dataForm) {

          if (dataForm.id == 0 || dataForm.endereco === "") {
            triggerChangeEvent('endereco', data.logradouro || '');
          }
          if (dataForm.id == 0 || dataForm.bairro === "") {
            triggerChangeEvent('bairro', data.bairro || '');
          }
          if (dataForm.id == 0 || dataForm.cidade === "") {
            triggerChangeEvent('cidade', data.localidade || '');
          }
          if (dataForm.id == 0 || dataForm.uf === "") {
            triggerChangeEvent('uf', data.uf?.toUpperCase() || '');
          }
        }

      

      // Notifica o componente pai sobre o endereço encontrado (se callback existir)
      if (onAddressFound) {
        onAddressFound(data);
      }
    } else {
      setAddressData(null);

      if (onAddressFound) {
        onAddressFound(null);
      }
    }
  } catch (error) {
    setAddressData(null);

    if (onAddressFound) {
      onAddressFound(null);
    }
  }
};

// Valida o valor atual sempre que ele mudar
useEffect(() => {
  const inputValue = (value as string) || '';
  const cleanValue = removeMask(inputValue);
  const newIsValid = validateCep(cleanValue);

  // Só atualiza se o estado de validação mudou
  if (newIsValid !== isValid) {
    setIsValid(newIsValid);

    // Notifica o componente pai sobre a mudança na validação, se houver callback
    if (onValidChange) {
      onValidChange(newIsValid);
    }
  }

  // Se CEP é válido, faz a validação online com debounce
  if (newIsValid) {
    const timeoutId = setTimeout(() => {
      validateCepOnline(cleanValue);
    }, 800); // 800ms de debounce

    return () => clearTimeout(timeoutId);
  } else {
    // Se CEP não é válido, limpa dados do endereço
    if (addressData) {
      setAddressData(null);
      if (onAddressFound) {
        onAddressFound(null);
      }
    }
  }
}, [value, onValidChange, isValid]); // Mantém isValid na dependência para controlar atualizações

// Manipulador para o evento onChange
const handleChange = (event: any) => {
  // Obtém o valor digitado - handle both empty string and undefined/null
  const inputValue = event.value !== undefined ? event.value : (event.target?.value || '');

  // Remove a máscara para obter apenas os dígitos
  const cleanValue = removeMask(inputValue);

  // Aplica a máscara para exibição
  const formattedValue = applyMask(cleanValue);

  // Cria um novo evento com o valor formatado
  const newEvent = {
    ...event,
    value: formattedValue,
    target: {
      ...event.target,
      value: formattedValue,
    },
  };

  // Chama o onChange original com o novo evento
  if (onChange) {
    onChange(newEvent);
  }

  // Notifica o valor sem máscara, se houver callback
  if (onValueChange) {
    onValueChange(cleanValue);
  }
};

// Manipulador para o evento onBlur
const handleBlur = (event: any) => {
  setTouched(true);

  if (onBlur) {
    onBlur(event);
  }
};

// Manipulador para o evento onFocus
const handleFocus = (event: any) => {
  if (onFocus) {
    onFocus(event);
  }
};

// Determina se o campo é válido
const fieldValid = touched ? isValid : valid;
const icon = getIcon('CEP'); 
return (
  <div className="input-container input-container-icon">
    {icon && (
      <InputAwesomeIcon icon={icon} />
    )}
    <Input
      {...otherProps}
      tabIndex={tabIndex}
      style={{ fontSize: '16px' }}
      value={value}
      onChange={handleChange}
      onBlur={handleBlur}
      onFocus={handleFocus}
      valid={fieldValid}
      aria-label='Campo de entrada de CEP'
      validationMessage={validationMessage || 'CEP inválido'}
      placeholder={otherProps.placeholder || 'XX.XXX-XXX'}
      maxLength={10}
    />
  </div>
);
};

export default React.memo(InputCep);