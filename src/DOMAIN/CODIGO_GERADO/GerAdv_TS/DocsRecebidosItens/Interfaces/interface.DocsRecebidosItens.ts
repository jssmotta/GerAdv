"use client";
export interface IDocsRecebidosItens {
// 202501251
    id: number;
 
		contatocrm: number,
		nome: string,
		devolvido: boolean,
		seradevolvido: boolean,
		observacoes: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IDocsRecebidosItensFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IDocsRecebidosItensIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}