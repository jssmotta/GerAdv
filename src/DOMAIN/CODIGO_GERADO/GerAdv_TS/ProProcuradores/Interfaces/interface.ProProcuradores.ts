"use client";
export interface IProProcuradores {
// 202501251
    id: number;
 
		advogado: number,
		processo: number,
		nome: string,
		data: string,
		substabelecimento: boolean,
		procuracao: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IProProcuradoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProProcuradoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}