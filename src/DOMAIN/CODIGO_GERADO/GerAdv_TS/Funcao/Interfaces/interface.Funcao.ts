"use client";
export interface IFuncao {
// 202501251
    id: number;
 
		descricao: string,
		auditor: undefined | null
}

export interface IFuncaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IFuncaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}