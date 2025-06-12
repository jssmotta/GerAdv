'use client';

export interface IOutrasPartesCliente {
// 202501251
    id: number;
 
	cidade: number,
	nome: string,
	terceirizado: boolean,
	clienteprincipal: number,
	tipo: boolean,
	sexo: boolean,
	dtnasc: string,
	cpf: string,
	rg: string,
	cnpj: string,
	inscest: string,
	nomefantasia: string,
	endereco: string,
	cep: string,
	bairro: string,
	fone: string,
	fax: string,
	email: string,
	site: string,
	class: string,
	etiqueta: boolean,
	ani: boolean,
	bold: boolean,
}

export interface IOutrasPartesClienteFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IOutrasPartesClienteIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}