"use client";
export interface IRamal {
// 202501251
    id: number;
 
		nome: string,
		obs: string,
		auditor: undefined | null
}

export interface IRamalFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IRamalIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}