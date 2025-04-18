﻿"use client";
export interface IPreClientes {
// 202501251
    id: number;
 
		idrep: number,
		cidade: number,
		inativo: boolean,
		quemindicou: string,
		nome: string,
		adv: number,
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
		assistido: string,
		assrg: string,
		asscpf: string,
		assendereco: string,
		cnh: string,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IPreClientesFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IPreClientesIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}