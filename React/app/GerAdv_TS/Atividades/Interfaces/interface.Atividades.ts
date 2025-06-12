'use client';

export interface IAtividades {
// 202501251
    id: number;
 
	descricao: string,
}

export interface IAtividadesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAtividadesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}