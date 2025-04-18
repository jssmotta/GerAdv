﻿"use client";
export interface IFuncionarios {
// 202501251
    id: number;
 
		cargo: number,
		funcao: number,
		cidade: number,
		emailpro: string,
		nome: string,
		sexo: boolean,
		registro: string,
		cpf: string,
		rg: string,
		tipo: boolean,
		observacao: string,
		endereco: string,
		bairro: string,
		cep: string,
		contato: string,
		fax: string,
		fone: string,
		email: string,
		periodo_ini: string,
		periodo_fim: string,
		ctpsnumero: string,
		ctpsserie: string,
		pis: string,
		salario: number,
		ctpsdtemissao: string,
		dtnasc: string,
		data: string,
		liberaagenda: boolean,
		pasta: string,
		class: string,
		etiqueta: boolean,
		ani: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IFuncionariosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IFuncionariosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}