"use client";
export interface IEnquadramentoEmpresa {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface IEnquadramentoEmpresaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IEnquadramentoEmpresaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}