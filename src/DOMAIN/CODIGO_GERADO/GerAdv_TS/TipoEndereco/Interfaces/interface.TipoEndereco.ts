'use client';

export interface ITipoEndereco {
// 202501251
    id: number;
 
	descricao: string,
}

export interface ITipoEnderecoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITipoEnderecoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}