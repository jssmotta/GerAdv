"use client";
export interface IContaCorrente {
// 202501251
    id: number;
 
		processo: number,
		cliente: number,
		ciacordo: number,
		quitado: boolean,
		idcontrato: number,
		quitadoid: number,
		debitoid: number,
		livrocaixaid: number,
		sucumbencia: boolean,
		distregra: boolean,
		dtoriginal: string,
		parcelax: number,
		valor: number,
		data: string,
		historico: string,
		contrato: boolean,
		pago: boolean,
		distribuir: boolean,
		lc: boolean,
		idhtrab: number,
		nroparcelas: number,
		valorprincipal: number,
		parcelaprincipalid: number,
		hide: boolean,
		datapgto: string,
		auditor: undefined | null
}

export interface IContaCorrenteFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IContaCorrenteIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}