'use client';

export interface IRamal {
// 202501251
    id: number;
 
	nome: string,
	obs: string,
}

export interface IRamalFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IRamalIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}