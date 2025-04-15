"use client";
export interface ICargosEscClass {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface ICargosEscClassFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ICargosEscClassIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}