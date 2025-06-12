'use client';

export interface IRegimeTributacao {
// 202501251
    id: number;
 
	nome: string,
}

export interface IRegimeTributacaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IRegimeTributacaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}