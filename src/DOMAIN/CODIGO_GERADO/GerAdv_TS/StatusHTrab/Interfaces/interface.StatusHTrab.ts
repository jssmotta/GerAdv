'use client';

export interface IStatusHTrab {
// 202501251
    id: number;
 
	descricao: string,
	resid: number,
}

export interface IStatusHTrabFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IStatusHTrabIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}