"use client";
export interface IContatoCRMOperador {
// 202501251
    id: number;
 
		contatocrm: number,
		operador: number,
		cargoesc: number,
		auditor: undefined | null
}

export interface IContatoCRMOperadorFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IContatoCRMOperadorIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}