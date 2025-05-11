"use client";
export interface IRegimeTributacao {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IRegimeTributacaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IRegimeTributacaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}