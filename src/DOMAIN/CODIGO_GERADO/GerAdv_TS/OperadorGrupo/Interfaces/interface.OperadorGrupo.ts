"use client";
export interface IOperadorGrupo {
// 202501251
    id: number;
 
		operador: number,
		grupo: number,
		inativo: boolean,
		auditor: undefined | null
}

export interface IOperadorGrupoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IOperadorGrupoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}