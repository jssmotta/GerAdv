"use client";
export interface IPontoVirtualAcessos {
// 202501251
    id: number;
 
		operador: number,
		datahora: string,
		tipo: boolean,
		origem: string,
}

export interface IPontoVirtualAcessosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IPontoVirtualAcessosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}