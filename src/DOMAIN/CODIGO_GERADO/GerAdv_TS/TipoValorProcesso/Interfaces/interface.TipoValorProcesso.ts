"use client";
export interface ITipoValorProcesso {
// 202501251
    id: number;
 
		descricao: string,
}

export interface ITipoValorProcessoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoValorProcessoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}