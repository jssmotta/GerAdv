'use client';

export interface IProSucumbencia {
// 202501251
    id: number;
 
	processo: number,
	instancia: number,
	tipoorigemsucumbencia: number,
	data: string,
	nome: string,
	valor: number,
	percentual: string,
}

export interface IProSucumbenciaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProSucumbenciaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}