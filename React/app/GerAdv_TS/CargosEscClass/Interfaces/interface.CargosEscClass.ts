'use client';

export interface ICargosEscClass {
// 202501251
    id: number;
 
	nome: string,
}

export interface ICargosEscClassFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ICargosEscClassIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}