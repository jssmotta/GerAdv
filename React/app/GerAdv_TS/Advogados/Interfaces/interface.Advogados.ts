'use client';

export interface IAdvogados {
// 202501251
    id: number;
 
	cargo: number,
	escritorio: number,
	cidade: number,
	emailpro: string,
	cpf: string,
	nome: string,
	rg: string,
	casa: boolean,
	nomemae: string,
	estagiario: boolean,
	oab: string,
	nomecompleto: string,
	endereco: string,
	cep: string,
	sexo: boolean,
	bairro: string,
	ctpsserie: string,
	ctps: string,
	fone: string,
	fax: string,
	comissao: number,
	dtinicio: string,
	dtfim: string,
	dtnasc: string,
	salario: number,
	secretaria: string,
	textoprocuracao: string,
	email: string,
	especializacao: string,
	pasta: string,
	observacao: string,
	contabancaria: string,
	parctop: boolean,
	class: string,
	top: boolean,
	etiqueta: boolean,
	ani: boolean,
	bold: boolean,
}

export interface IAdvogadosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IAdvogadosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}