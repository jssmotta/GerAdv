'use client';

export interface IReuniaoPessoas {
// 202501251
    id: number;
 
	reuniao: number,
	operador: number,
}

export interface IReuniaoPessoasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IReuniaoPessoasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}