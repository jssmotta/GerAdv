'use client';

export interface ILivroCaixaClientes {
// 202501251
    id: number;
 
	livrocaixa: number,
	cliente: number,
	lancado: boolean,
}

export interface ILivroCaixaClientesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ILivroCaixaClientesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}