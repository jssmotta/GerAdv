'use client';

export interface IFuncao {
// 202501251
    id: number;
 
	descricao: string,
}

export interface IFuncaoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IFuncaoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}