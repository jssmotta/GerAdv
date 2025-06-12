'use client';

export interface IStatusInstancia {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface IStatusInstanciaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IStatusInstanciaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}