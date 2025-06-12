'use client';

export interface IServicos {
// 202501251
    id: number;
 
	cobrar: boolean,
	descricao: string,
	basico: boolean,
}

export interface IServicosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IServicosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}