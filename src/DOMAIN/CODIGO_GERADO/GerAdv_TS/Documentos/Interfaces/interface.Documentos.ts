"use client";
export interface IDocumentos {
// 202501251
    id: number;
 
		processo: number,
		data: string,
		observacao: string,
		auditor: undefined | null
}

export interface IDocumentosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IDocumentosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}