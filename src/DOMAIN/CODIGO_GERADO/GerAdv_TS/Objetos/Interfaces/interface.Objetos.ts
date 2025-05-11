"use client";
export interface IObjetos {
// 202501251
    id: number;
 
		justica: number,
		area: number,
		nome: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IObjetosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IObjetosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}