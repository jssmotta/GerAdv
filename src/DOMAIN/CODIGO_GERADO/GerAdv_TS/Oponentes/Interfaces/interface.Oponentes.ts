"use client";
export interface IOponentes {
// 202501251
    id: number;
 
		cidade: number,
		empfuncao: number,
		ctpsnumero: string,
		site: string,
		ctpsserie: string,
		nome: string,
		adv: number,
		empcliente: number,
		idrep: number,
		pis: string,
		contato: string,
		cnpj: string,
		rg: string,
		juridica: boolean,
		tipo: boolean,
		sexo: boolean,
		cpf: string,
		endereco: string,
		fone: string,
		fax: string,
		bairro: string,
		cep: string,
		inscest: string,
		observacao: string,
		email: string,
		class: string,
		top: boolean,
		etiqueta: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IOponentesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IOponentesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}