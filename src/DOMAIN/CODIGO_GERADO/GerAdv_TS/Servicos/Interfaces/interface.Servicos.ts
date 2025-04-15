"use client";
export interface IServicos {
// 202501251
    id: number;
 
		cobrar: boolean,
		descricao: string,
		basico: boolean,
		auditor: undefined | null
}

export interface IServicosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IServicosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}