"use client";
export interface IStatusAndamento {
// 202501251
    id: number;
 
		nome: string,
		icone: number,
		bold: boolean,
		auditor: undefined | null
}

export interface IStatusAndamentoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IStatusAndamentoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}