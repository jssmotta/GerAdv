"use client";
export interface IModelosDocumentos {
// 202501251
    id: number;
 
		tipomodelodocumento: number,
		nome: string,
		remuneracao: string,
		assinatura: string,
		header: string,
		footer: string,
		extra1: string,
		extra2: string,
		extra3: string,
		outorgante: string,
		outorgados: string,
		poderes: string,
		objeto: string,
		titulo: string,
		testemunhas: string,
		css: string,
		auditor: undefined | null
}

export interface IModelosDocumentosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IModelosDocumentosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}