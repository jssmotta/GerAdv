"use client";
export interface IGUTTipo {
// 202501251
    id: number;
 
		nome: string,
		ordem: number,
		auditor: undefined | null
}

export interface IGUTTipoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IGUTTipoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}