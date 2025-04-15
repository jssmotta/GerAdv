"use client";
export interface IStatusTarefas {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IStatusTarefasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IStatusTarefasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}