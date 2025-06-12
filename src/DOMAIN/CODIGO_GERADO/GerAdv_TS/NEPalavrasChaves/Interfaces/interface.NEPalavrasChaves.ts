'use client';

export interface INEPalavrasChaves {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface INEPalavrasChavesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface INEPalavrasChavesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}