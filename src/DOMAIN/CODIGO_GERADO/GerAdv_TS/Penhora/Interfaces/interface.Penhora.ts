'use client';

export interface IPenhora {
// 202501251
    id: number;
 
	processo: number,
	penhorastatus: number,
	nome: string,
	descricao: string,
	datapenhora: string,
	master: number,
}

export interface IPenhoraFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IPenhoraIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}