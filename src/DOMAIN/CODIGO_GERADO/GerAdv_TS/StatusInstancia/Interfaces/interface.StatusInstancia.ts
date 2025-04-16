"use client";
export interface IStatusInstancia {
// 202501251
    id: number;
 
		nome: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IStatusInstanciaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IStatusInstanciaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}