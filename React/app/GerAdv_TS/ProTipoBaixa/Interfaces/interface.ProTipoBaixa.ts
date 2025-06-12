'use client';

export interface IProTipoBaixa {
// 202501251
    id: number;
 
	nome: string,
	bold: boolean,
}

export interface IProTipoBaixaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IProTipoBaixaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}