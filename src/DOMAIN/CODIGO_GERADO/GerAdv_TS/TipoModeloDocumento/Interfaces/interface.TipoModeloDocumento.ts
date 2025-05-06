"use client";
export interface ITipoModeloDocumento {
// 202501251
    id: number;
 
		nome: string,
		auditor: undefined | null
}

export interface ITipoModeloDocumentoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ITipoModeloDocumentoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}