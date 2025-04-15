"use client";
export interface INENotas {
// 202501251
    id: number;
 
		apenso: number,
		precatoria: number,
		instancia: number,
		processo: number,
		movpro: boolean,
		nome: string,
		notaexpedida: boolean,
		revisada: boolean,
		palavrachave: number,
		data: string,
		notapublicada: string,
		auditor: undefined | null
}

export interface INENotasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface INENotasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}