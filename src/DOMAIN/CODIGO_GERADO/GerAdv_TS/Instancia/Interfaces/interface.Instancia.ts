"use client";
export interface IInstancia {
// 202501251
    id: number;
 
		processo: number,
		acao: number,
		foro: number,
		tiporecurso: number,
		liminarpedida: string,
		objeto: string,
		statusresultado: number,
		liminarpendente: boolean,
		interpusemosrecurso: boolean,
		liminarconcedida: boolean,
		liminarnegada: boolean,
		data: string,
		liminarparcial: boolean,
		liminarresultado: string,
		nroprocesso: string,
		divisao: number,
		liminarcliente: boolean,
		comarca: number,
		subdivisao: number,
		principal: boolean,
		zkey: string,
		zkeyquem: number,
		zkeyquando: string,
		nroantigo: string,
		accesscode: string,
		julgador: number,
		zkeyia: string,
		auditor: undefined | null
}

export interface IInstanciaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IInstanciaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}