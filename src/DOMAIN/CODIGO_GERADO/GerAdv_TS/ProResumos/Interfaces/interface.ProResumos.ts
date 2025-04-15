"use client";
export interface IProResumos {
// 202501251
    id: number;
 
		processo: number,
		data: string,
		resumo: string,
		tiporesumo: number,
		bold: boolean,
		auditor: undefined | null
}

export interface IProResumosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProResumosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}