"use client";
export interface ITiposAcao {
// 202501251
    id: number;
 
		nome: string,
		inativo: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface ITiposAcaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITiposAcaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}