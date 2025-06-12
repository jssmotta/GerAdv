'use client';

export interface IForo {
// 202501251
    id: number;
 
	cidade: number,
	email: string,
	nome: string,
	unico: boolean,
	site: string,
	endereco: string,
	bairro: string,
	fone: string,
	fax: string,
	cep: string,
	obs: string,
	unicoconfirmado: boolean,
	web: string,
	etiqueta: boolean,
	bold: boolean,
}

export interface IForoFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface IForoIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}