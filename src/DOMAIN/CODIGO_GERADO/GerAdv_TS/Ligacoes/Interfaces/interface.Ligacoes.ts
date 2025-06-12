'use client';

export interface ILigacoes {
// 202501251
    id: number;
 
	cliente: number,
	ramal: number,
	processo: number,
	assunto: string,
	ageclienteavisado: number,
	celular: boolean,
	contato: string,
	datarealizada: string,
	quemid: number,
	telefonista: number,
	ultimoaviso: string,
	horafinal: string,
	nome: string,
	quemcodigo: number,
	solicitante: number,
	para: string,
	fone: string,
	particular: boolean,
	realizada: boolean,
	status: string,
	data: string,
	hora: string,
	urgente: boolean,
	ligarpara: string,
	startscreen: boolean,
	emotion: number,
	bold: boolean,
}

export interface ILigacoesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ILigacoesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}