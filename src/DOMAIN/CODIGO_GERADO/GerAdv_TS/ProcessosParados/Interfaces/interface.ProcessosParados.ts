"use client";
export interface IProcessosParados {
// 202501251
    id: number;
 
		processo: number,
		operador: number,
		semana: number,
		ano: number,
		datahora: string,
		datahistorico: string,
		datanenotas: string,
}

export interface IProcessosParadosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProcessosParadosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}