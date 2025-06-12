'use client';

export interface IAlertas {
// 202501251
    id: number;
 
	operador: number,
	nome: string,
	data: string,
	dataate: string,
}

export interface IAlertasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAlertasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}