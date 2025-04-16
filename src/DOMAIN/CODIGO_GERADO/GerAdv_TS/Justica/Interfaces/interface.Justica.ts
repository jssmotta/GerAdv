"use client";
export interface IJustica {
// 202501251
    id: number;
 
		nome: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IJusticaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IJusticaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}