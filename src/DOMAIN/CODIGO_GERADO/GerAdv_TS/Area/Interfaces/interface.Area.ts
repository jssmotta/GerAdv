"use client";
export interface IArea {
// 202501251
    id: number;
 
		descricao: string,
		top: boolean,
		auditor: undefined | null
}

export interface IAreaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAreaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}