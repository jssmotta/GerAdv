'use client';

export interface ICidade {
// 202501251
    id: number;
 
	uf: number,
	ddd: string,
	top: boolean,
	comarca: boolean,
	capital: boolean,
	nome: string,
	sigla: string,
}

export interface ICidadeFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ICidadeIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}