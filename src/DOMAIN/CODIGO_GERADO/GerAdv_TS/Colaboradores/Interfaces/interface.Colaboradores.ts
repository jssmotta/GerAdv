"use client";
export interface IColaboradores {
// 202501251
    id: number;
 
		cargo: number,
		cliente: number,
		cidade: number,
		sexo: boolean,
		nome: string,
		cpf: string,
		rg: string,
		dtnasc: string,
		idade: number,
		endereco: string,
		bairro: string,
		cep: string,
		fone: string,
		observacao: string,
		email: string,
		cnh: string,
		class: string,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IColaboradoresFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IColaboradoresIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}