"use client";
export interface IGruposEmpresas {
// 202501251
    id: number;
 
		oponente: number,
		cliente: number,
		email: string,
		inativo: boolean,
		descricao: string,
		observacoes: string,
		icone: string,
		despesaunificada: boolean,
		auditor: undefined | null
}

export interface IGruposEmpresasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IGruposEmpresasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}