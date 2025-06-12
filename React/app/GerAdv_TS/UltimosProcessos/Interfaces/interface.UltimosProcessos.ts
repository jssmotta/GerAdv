'use client';

export interface IUltimosProcessos {
// 202501251
    id: number;
 
	processo: number,
	quando: string,
	quem: number,
}

export interface IUltimosProcessosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IUltimosProcessosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}