'use client';

export interface ITipoEnderecoSistema {
// 202501251
    id: number;
 
	nome: string,
}

export interface ITipoEnderecoSistemaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoEnderecoSistemaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}