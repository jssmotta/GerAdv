"use client";
export interface IAtividades {
// 202501251
    id: number;
 
		descricao: string,
		auditor: undefined | null
}

export interface IAtividadesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAtividadesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}