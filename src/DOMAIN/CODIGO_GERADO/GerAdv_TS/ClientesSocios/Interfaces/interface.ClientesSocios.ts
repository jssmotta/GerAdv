"use client";
export interface IClientesSocios {
// 202501251
    id: number;
 
		cliente: number,
		cidade: number,
		cidadesocio: number,
		somenterepresentante: boolean,
		idade: number,
		isrepresentantelegal: boolean,
		qualificacao: string,
		sexo: boolean,
		dtnasc: string,
		nome: string,
		site: string,
		representantelegal: string,
		endereco: string,
		bairro: string,
		cep: string,
		rg: string,
		cpf: string,
		fone: string,
		participacao: string,
		cargo: string,
		email: string,
		obs: string,
		cnh: string,
		datacontrato: string,
		cnpj: string,
		inscest: string,
		socioempresaadminnome: string,
		enderecosocio: string,
		bairrosocio: string,
		cepsocio: string,
		rgdataexp: string,
		socioempresaadminsomente: boolean,
		tipo: boolean,
		fax: string,
		class: string,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IClientesSociosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IClientesSociosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}