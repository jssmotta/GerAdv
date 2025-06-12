'use client';

export interface IEndTit {
// 202501251
    id: number;
 
	endereco: number,
	titulo: number,
}

export interface IEndTitFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IEndTitIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}