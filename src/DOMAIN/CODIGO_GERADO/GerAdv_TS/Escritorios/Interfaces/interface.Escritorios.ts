"use client";
export interface IEscritorios {
// 202501251
    id: number;
 
		cidade: number,
		cnpj: string,
		casa: boolean,
		parceria: boolean,
		nome: string,
		oab: string,
		endereco: string,
		bairro: string,
		cep: string,
		fone: string,
		fax: string,
		site: string,
		email: string,
		obs: string,
		advresponsavel: string,
		secretaria: string,
		inscest: string,
		correspondente: boolean,
		top: boolean,
		etiqueta: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IEscritoriosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IEscritoriosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}