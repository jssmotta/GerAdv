"use client";
export interface IClientes {
// 202501251
    id: number;
 
		cidade: number,
		regimetributacao: number,
		enquadramentoempresa: number,
		empresa: number,
		icone: string,
		nomemae: string,
		rgdataexp: string,
		inativo: boolean,
		quemindicou: string,
		sendemail: boolean,
		nome: string,
		adv: number,
		idrep: number,
		juridica: boolean,
		nomefantasia: string,
		class: string,
		tipo: boolean,
		dtnasc: string,
		inscest: string,
		qualificacao: string,
		sexo: boolean,
		idade: number,
		cnpj: string,
		cpf: string,
		rg: string,
		tipocaptacao: boolean,
		observacao: string,
		endereco: string,
		bairro: string,
		cep: string,
		fax: string,
		fone: string,
		data: string,
		homepage: string,
		email: string,
		obito: boolean,
		nomepai: string,
		rgoexpeditor: string,
		reportecbonly: boolean,
		probono: boolean,
		cnh: string,
		pessoacontato: string,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IClientesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IClientesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}