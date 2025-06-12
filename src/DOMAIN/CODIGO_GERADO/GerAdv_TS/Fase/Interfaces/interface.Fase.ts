'use client';

export interface IFase {
// 202501251
    id: number;
 
	justica: number,
	area: number,
	descricao: string,
}

export interface IFaseFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IFaseIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}