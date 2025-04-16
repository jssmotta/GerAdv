"use client";
export interface IFornecedores {
// 202501251
    id: number;
 
		cidade: number,
		grupo: number,
		nome: string,
		subgrupo: number,
		tipo: boolean,
		sexo: boolean,
		cnpj: string,
		inscest: string,
		cpf: string,
		rg: string,
		endereco: string,
		bairro: string,
		cep: string,
		fone: string,
		fax: string,
		email: string,
		site: string,
		obs: string,
		produtos: string,
		contatos: string,
		etiqueta: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IFornecedoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IFornecedoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}