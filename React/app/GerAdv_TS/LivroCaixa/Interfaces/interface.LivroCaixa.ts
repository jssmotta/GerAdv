'use client';

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
}

export interface ILivroCaixaFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ILivroCaixaIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}