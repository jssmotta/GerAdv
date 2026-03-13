'use client';
import React from 'react';
import { Checkbox, CheckboxChangeEvent } from '@progress/kendo-react-inputs';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import InputCheckbox from './InputCheckbox';

interface InputCheckBoxProps {
  tabIndex?: number;
  label: string;
  dataForm?: any;
  name: string;
  checked: boolean;
  style?: React.CSSProperties;
  onChange: (event: CheckboxChangeEvent) => void;
}

type OperadorLike = {
  id: number;
  senha256: string;
};

const InputCheckboxMaster: React.FC<InputCheckBoxProps> = ({
  tabIndex = 0,
  dataForm,
  style,
  label,
  name,
  checked,
  onChange,
}) => {
  const cssDado = 'inputCheckBox';
  let systemContext: any = undefined;
  try {
    systemContext = useAppSelector(selectSystemContext);
  } catch (e) {
    systemContext = undefined;
  }
  function isOperadorLike(obj: any): obj is OperadorLike {
    return obj && typeof obj === 'object' && 'senha256' in obj && 'id' in obj;
  }
  return (
    <>
      
          {isOperadorLike(dataForm) ? (
            <InputCheckbox
              tabIndex={tabIndex}
              style={style}
              name={name}
              checked={checked}
              aria-label={`Checkbox para ${label}`}
              label={label}
              disabled={
                systemContext?.Id == dataForm.id ||
                systemContext?.IsMaster === false
              }
              onChange={onChange}
            />
          ) : (
            <InputCheckbox
              style={style}
              tabIndex={tabIndex}
              name={name}
              aria-label={`Checkbox para ${label}`}
              checked={checked}
              disabled={systemContext?.IsMaster === false}
              label={label}
              onChange={onChange}
            />
          )}      
    </>
  );
};

export default React.memo(InputCheckboxMaster);
