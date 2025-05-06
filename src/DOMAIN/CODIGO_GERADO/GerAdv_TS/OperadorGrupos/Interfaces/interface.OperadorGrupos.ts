"use client";
export interface IOperadorGrupos {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IOperadorGruposFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IOperadorGruposIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}