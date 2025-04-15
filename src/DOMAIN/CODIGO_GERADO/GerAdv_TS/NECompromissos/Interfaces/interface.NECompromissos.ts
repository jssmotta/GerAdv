"use client";
export interface INECompromissos {
// 202501251
    id: number;
 
		tipocompromisso: number,
		palavrachave: number,
		provisionar: boolean,
		textocompromisso: string,
		bold: boolean,
		auditor: undefined | null
}

export interface INECompromissosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface INECompromissosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}