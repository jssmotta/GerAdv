'use client';
import React from 'react';
import { Checkbox, CheckboxChangeEvent } from '@progress/kendo-react-inputs';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';

interface InputCheckBoxProps {
  tabIndex?: number;
  label: string;
  dataForm?: any;
  name: string;
  checked: boolean;
  style?: React.CSSProperties;
  onChange: (event: CheckboxChangeEvent) => void;
}

export type OperadorLike = {
  id: number;
  senha256: string;
};

const InputMaster: React.FC<InputCheckBoxProps> = ({
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
  
  // Helper function to determine if checkbox should be disabled
  const isDisabled = () => {
    // If systemContext is null or undefined, disable the checkbox
    if (!systemContext) {
      return true;
    }
    
    // If IsMaster is not explicitly true, disable the checkbox
    // This handles cases where IsMaster is undefined, null, false, or missing
    const isMaster = systemContext.IsMaster === true;
    
    if (isOperadorLike(dataForm)) {
      // If it's an operator-like object, disable if:
      // 1. It's the same user (same ID), OR
      // 2. Current user is not master
      return systemContext.Id === dataForm.id || !isMaster;
    } else {
      // If it's not an operator-like object, disable only if user is not master
      return !isMaster;
    }
  };

  return (
    <>
      <div className={`input-container input-checkbox-container`}>
        <div className={cssDado}>
          <Checkbox
            tabIndex={tabIndex}
            style={style}
            name={name}
            checked={checked}
            disabled={isDisabled()}
            onChange={onChange}
            aria-label={`Checkbox para ${label}`}
          />
          <label htmlFor={name}>{label}</label>
        </div>
      </div>
    </>
  );
};

export default React.memo(InputMaster);