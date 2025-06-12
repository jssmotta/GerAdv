'use client';

export interface ITiposAcao {
// 202501251
    id: number;
 
	nome: string,
	inativo: boolean,
	bold: boolean,
}

export interface ITiposAcaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITiposAcaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}