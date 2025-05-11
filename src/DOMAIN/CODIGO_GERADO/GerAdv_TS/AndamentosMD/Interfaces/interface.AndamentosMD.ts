"use client";
export interface IAndamentosMD {
// 202501251
    id: number;
 
		processo: number,
		nome: string,
		andamento: number,
		pathfull: string,
		unc: string,
		auditor: undefined | null
}

export interface IAndamentosMDFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAndamentosMDIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}