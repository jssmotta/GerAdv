'use client';

export interface IEnquadramentoEmpresa {
// 202501251
    id: number;
 
	nome: string,
}

export interface IEnquadramentoEmpresaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IEnquadramentoEmpresaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}