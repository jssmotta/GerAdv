'use client';

export interface IOponentesRepLegal {
// 202501251
    id: number;
 
	oponente: number,
	cidade: number,
	nome: string,
	fone: string,
	sexo: boolean,
	cpf: string,
	rg: string,
	endereco: string,
	bairro: string,
	cep: string,
	fax: string,
	email: string,
	site: string,
	observacao: string,
	bold: boolean,
}

export interface IOponentesRepLegalFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IOponentesRepLegalIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}