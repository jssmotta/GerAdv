"use client";
export interface IFase {
// 202501251
    id: number;
 
		justica: number,
		area: number,
		descricao: string,
		auditor: undefined | null
}

export interface IFaseFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IFaseIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}