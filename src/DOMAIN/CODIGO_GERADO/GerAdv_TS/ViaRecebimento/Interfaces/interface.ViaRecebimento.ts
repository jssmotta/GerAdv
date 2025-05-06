"use client";
export interface IViaRecebimento {
// 202501251
    id: number;
 
		nome: string,
}

export interface IViaRecebimentoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IViaRecebimentoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}