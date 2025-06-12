'use client';

export interface IPontoVirtual {
// 202501251
    id: number;
 
	operador: number,
	horaentrada: string,
	horasaida: string,
	key: string,
}

export interface IPontoVirtualFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IPontoVirtualIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}