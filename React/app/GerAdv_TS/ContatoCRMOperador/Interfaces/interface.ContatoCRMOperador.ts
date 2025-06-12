'use client';

export interface IContatoCRMOperador {
// 202501251
    id: number;
 
	contatocrm: number,
	operador: number,
	cargoesc: number,
}

export interface IContatoCRMOperadorFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IContatoCRMOperadorIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}