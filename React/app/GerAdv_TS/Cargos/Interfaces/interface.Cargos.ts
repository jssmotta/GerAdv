'use client';

export interface ICargos {
// 202501251
    id: number;
 
	nome: string,
}

export interface ICargosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ICargosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}