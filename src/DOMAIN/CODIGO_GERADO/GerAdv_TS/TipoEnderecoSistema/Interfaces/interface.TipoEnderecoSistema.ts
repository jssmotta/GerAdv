"use client";
export interface ITipoEnderecoSistema {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface ITipoEnderecoSistemaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoEnderecoSistemaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}