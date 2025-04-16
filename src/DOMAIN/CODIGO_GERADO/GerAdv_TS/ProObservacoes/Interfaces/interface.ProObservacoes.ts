"use client";
export interface IProObservacoes {
// 202501251
    id: number;
 
		processo: number,
		nome: string,
		observacoes: string,
		data: string,
		auditor: undefined | null
}

export interface IProObservacoesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProObservacoesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}