'use client';

export interface IProObservacoes {
// 202501251
    id: number;
 
	processo: number,
	nome: string,
	observacoes: string,
	data: string,
}

export interface IProObservacoesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProObservacoesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}