"use client";
export interface IPaises {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IPaisesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IPaisesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}