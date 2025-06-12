'use client';

export interface IProResumos {
// 202501251
    id: number;
 
	processo: number,
	data: string,
	resumo: string,
	tiporesumo: number,
	bold: boolean,
}

export interface IProResumosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProResumosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}