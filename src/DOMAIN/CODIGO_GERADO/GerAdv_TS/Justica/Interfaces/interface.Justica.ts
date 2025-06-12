'use client';

export interface IJustica {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface IJusticaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IJusticaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}