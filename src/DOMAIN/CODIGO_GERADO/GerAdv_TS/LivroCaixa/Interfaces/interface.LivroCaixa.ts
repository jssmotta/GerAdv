"use client";
export interface ILivroCaixa {
// 202501251
    id: number;
 
		processo: number,
		iddes: number,
		pessoal: number,
		ajuste: boolean,
		idhon: number,
		idhonparc: number,
		idhonsuc: boolean,
		data: string,
		valor: number,
		tipo: boolean,
		historico: string,
		grupo: number,
		auditor: undefined | null
}

export interface ILivroCaixaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface ILivroCaixaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}