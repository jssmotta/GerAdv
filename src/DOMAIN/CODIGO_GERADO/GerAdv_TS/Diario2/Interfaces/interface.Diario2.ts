"use client";
export interface IDiario2 {
// 202501251
    id: number;
 
		operador: number,
		cliente: number,
		data: string,
		hora: string,
		nome: string,
		ocorrencia: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IDiario2FormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IDiario2IncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}