﻿"use client";
export interface IContratos {
// 202501251
    id: number;
 
		processo: number,
		cliente: number,
		advogado: number,
		dia: number,
		valor: number,
		datainicio: string,
		datatermino: string,
		ocultarrelatorio: boolean,
		percescritorio: number,
		valorconsultoria: number,
		tipocobranca: number,
		protestar: string,
		juros: string,
		valorrealizavel: number,
		documento: string,
		email1: string,
		email2: string,
		email3: string,
		pessoa1: string,
		pessoa2: string,
		pessoa3: string,
		obs: string,
		clientecontrato: number,
		idextrangeiro: number,
		chavecontrato: string,
		avulso: boolean,
		suspenso: boolean,
		multa: string,
		bold: boolean,
		auditor: undefined | null
}

export interface IContratosFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IContratosIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}