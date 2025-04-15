"use client";
export interface IOperadorGruposAgenda {
// 202501251
    id: number;
 
		operador: number,
		sqlwhere: string,
		nome: string,
		auditor: undefined | null
}

export interface IOperadorGruposAgendaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IOperadorGruposAgendaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}