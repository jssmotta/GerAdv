"use client";
export interface IProValores {
// 202501251
    id: number;
 
		processo: number,
		tipovalorprocesso: number,
		indice: string,
		ignorar: boolean,
		data: string,
		valororiginal: number,
		percmulta: number,
		valormulta: number,
		percjuros: number,
		valororiginalcorrigidoindice: number,
		valormultacorrigido: number,
		valorjuroscorrigido: number,
		valorfinal: number,
		dataultimacorrecao: string,
		auditor: undefined | null
}

export interface IProValoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProValoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}