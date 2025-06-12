'use client';

export interface IParteClienteOutras {
// 202501251
    id: number;
 
	cliente: number,
	processo: number,
	primeirareclamada: boolean,
}

export interface IParteClienteOutrasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IParteClienteOutrasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}