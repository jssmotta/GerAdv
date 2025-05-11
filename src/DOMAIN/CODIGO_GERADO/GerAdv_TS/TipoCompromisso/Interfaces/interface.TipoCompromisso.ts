"use client";
export interface ITipoCompromisso {
// 202501251
    id: number;
 
		icone: number,
		descricao: string,
		financeiro: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface ITipoCompromissoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoCompromissoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}