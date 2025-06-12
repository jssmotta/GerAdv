'use client';

export interface ITerceiros {
// 202501251
    id: number;
 
	processo: number,
	situacao: number,
	cidade: number,
	nome: string,
	endereco: string,
	bairro: string,
	cep: string,
	fone: string,
	fax: string,
	obs: string,
	email: string,
	class: string,
	varaforocomarca: string,
	sexo: boolean,
	bold: boolean,
}

export interface ITerceirosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}

export interface ITerceirosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: (registro?: any) => void;
    onError: () => void;
}