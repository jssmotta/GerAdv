"use client";
export interface IProDepositos {
// 202501251
    id: number;
 
		processo: number,
		fase: number,
		tipoprodesposito: number,
		data: string,
		valor: number,
		auditor: undefined | null
}

export interface IProDepositosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProDepositosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}