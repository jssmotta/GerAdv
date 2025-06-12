'use client';

export interface IAuditor4K {
// 202501251
    id: number;
 
	nome: string,
}

export interface IAuditor4KFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAuditor4KIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}