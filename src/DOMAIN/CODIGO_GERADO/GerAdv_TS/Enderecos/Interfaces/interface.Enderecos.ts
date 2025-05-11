"use client";
export interface IEnderecos {
// 202501251
    id: number;
 
		cidade: number,
		topindex: boolean,
		descricao: string,
		contato: string,
		dtnasc: string,
		endereco: string,
		bairro: string,
		privativo: boolean,
		addcontato: boolean,
		cep: string,
		oab: string,
		obs: string,
		fone: string,
		fax: string,
		tratamento: string,
		site: string,
		email: string,
		quem: number,
		quemindicou: string,
		reportecbonly: boolean,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IEnderecosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IEnderecosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}