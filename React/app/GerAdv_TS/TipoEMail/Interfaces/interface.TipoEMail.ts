'use client';

export interface ITipoEMail {
// 202501251
    id: number;
 
	nome: string,
}

export interface ITipoEMailFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoEMailIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}