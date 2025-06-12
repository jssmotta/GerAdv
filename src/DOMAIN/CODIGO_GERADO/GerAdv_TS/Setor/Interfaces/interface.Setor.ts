'use client';

export interface ISetor {
// 202501251
    id: number;
 
	descricao: string,
}

export interface ISetorFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ISetorIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}