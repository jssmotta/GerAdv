'use client';
import React from 'react';

interface InputHiddenProps {
  tabIndex?: number;
  type: string;
  id: string;
  label: string;
  className?: string;
  name: string;
  dataForm?: any;
  value: any;
  maxLength?: number;
  onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

const InputHidden: React.FC<InputHiddenProps> = (props) => {
  return null;
};

export default React.memo(InputHidden);
