'use client';

export interface IArea {
// 202501251
    id: number;
 
	descricao: string,
	top: boolean,
}

export interface IAreaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAreaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}