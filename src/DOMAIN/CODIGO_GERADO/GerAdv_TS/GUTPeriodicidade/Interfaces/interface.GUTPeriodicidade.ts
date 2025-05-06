"use client";
export interface IGUTPeriodicidade {
// 202501251
    id: number;
 
		nome: string,
		intervalodias: number,
		auditor: undefined | null
}

export interface IGUTPeriodicidadeFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IGUTPeriodicidadeIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}