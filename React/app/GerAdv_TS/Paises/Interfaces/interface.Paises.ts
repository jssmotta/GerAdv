'use client';

export interface IPaises {
// 202501251
    id: number;
 
	nome: string,
}

export interface IPaisesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IPaisesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}