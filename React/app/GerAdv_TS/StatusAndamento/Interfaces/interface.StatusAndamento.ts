'use client';

export interface IStatusAndamento {
// 202501251
    id: number;
 
	nome: string,
	icone: number,
	bold: boolean,
}

export interface IStatusAndamentoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IStatusAndamentoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}