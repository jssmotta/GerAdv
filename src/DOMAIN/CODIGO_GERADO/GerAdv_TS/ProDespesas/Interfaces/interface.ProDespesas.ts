"use client";
export interface IProDespesas {
// 202501251
    id: number;
 
		cliente: number,
		processo: number,
		ligacaoid: number,
		corrigido: boolean,
		data: string,
		valororiginal: number,
		quitado: number,
		datacorrecao: string,
		valor: number,
		tipo: boolean,
		historico: string,
		livrocaixa: boolean,
		auditor: undefined | null
}

export interface IProDespesasFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IProDespesasIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}