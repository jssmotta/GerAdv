"use client";
export interface IAnexamentoRegistros {
// 202501251
    id: number;
 
		cliente: number,
		guidreg: string,
		codigoreg: number,
		idreg: number,
		data: string,
		auditor: undefined | null
}

export interface IAnexamentoRegistrosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAnexamentoRegistrosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}