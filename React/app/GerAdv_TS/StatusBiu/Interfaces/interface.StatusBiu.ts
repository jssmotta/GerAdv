'use client';

export interface IStatusBiu {
// 202501251
    id: number;
 
	tipostatusbiu: number,
	operador: number,
	nome: string,
	icone: number,
}

export interface IStatusBiuFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IStatusBiuIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}