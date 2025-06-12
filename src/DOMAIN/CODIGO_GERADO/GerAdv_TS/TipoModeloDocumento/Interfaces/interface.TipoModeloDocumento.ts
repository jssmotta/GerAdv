'use client';

export interface ITipoModeloDocumento {
// 202501251
    id: number;
 
	nome: string,
}

export interface ITipoModeloDocumentoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoModeloDocumentoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}