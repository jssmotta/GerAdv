'use client';

export interface IPenhoraStatus {
// 202501251
    id: number;
 
	nome: string,
}

export interface IPenhoraStatusFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IPenhoraStatusIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}