"use client";
export interface IBensClassificacao {
// 202501251
    id: number;
 
		nome: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IBensClassificacaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IBensClassificacaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}