"use client";
export interface IReuniaoPessoas {
// 202501251
    id: number;
 
		reuniao: number,
		operador: number,
		auditor: undefined | null
}

export interface IReuniaoPessoasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IReuniaoPessoasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}