"use client";
export interface IPosicaoOutrasPartes {
// 202501251
    id: number;
 
		descricao: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IPosicaoOutrasPartesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IPosicaoOutrasPartesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}