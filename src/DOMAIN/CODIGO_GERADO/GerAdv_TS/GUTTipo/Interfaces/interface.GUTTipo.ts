'use client';

export interface IGUTTipo {
// 202501251
    id: number;
 
	nome: string,
	ordem: number,
}

export interface IGUTTipoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IGUTTipoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}