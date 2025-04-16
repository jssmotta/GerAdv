"use client";
export interface IUF {
// 202501251
    id: number;
 
		pais: number,
		ddd: string,
		iduf: string,
		top: boolean,
		descricao: string,
		auditor: undefined | null
}

export interface IUFFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IUFIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}