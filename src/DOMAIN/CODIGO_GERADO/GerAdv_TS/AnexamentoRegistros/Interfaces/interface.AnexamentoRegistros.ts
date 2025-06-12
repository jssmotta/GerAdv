'use client';

export interface IAnexamentoRegistros {
// 202501251
    id: number;
 
	cliente: number,
	guidreg: string,
	codigoreg: number,
	idreg: number,
	data: string,
}

export interface IAnexamentoRegistrosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAnexamentoRegistrosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}