'use client';

export interface IOperadorGrupos {
// 202501251
    id: number;
 
	nome: string,
}

export interface IOperadorGruposFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IOperadorGruposIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}