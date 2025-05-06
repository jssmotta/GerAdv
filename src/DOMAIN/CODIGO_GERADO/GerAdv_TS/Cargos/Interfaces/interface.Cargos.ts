"use client";
export interface ICargos {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface ICargosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ICargosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}