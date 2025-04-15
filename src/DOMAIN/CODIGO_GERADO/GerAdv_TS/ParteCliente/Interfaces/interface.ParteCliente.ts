"use client";
export interface IParteCliente {
// 202501251
    id: number;
 
		cliente: number,
		processo: number,
}

export interface IParteClienteFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IParteClienteIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}