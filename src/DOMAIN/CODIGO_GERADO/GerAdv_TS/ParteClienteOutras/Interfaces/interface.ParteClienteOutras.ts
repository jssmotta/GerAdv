"use client";
export interface IParteClienteOutras {
// 202501251
    id: number;
 
		cliente: number,
		processo: number,
		primeirareclamada: boolean,
		auditor: undefined | null
}

export interface IParteClienteOutrasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IParteClienteOutrasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}