'use client';

export interface ICargosEsc {
// 202501251
    id: number;
 
	percentual: number,
	nome: string,
	classificacao: number,
}

export interface ICargosEscFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ICargosEscIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}