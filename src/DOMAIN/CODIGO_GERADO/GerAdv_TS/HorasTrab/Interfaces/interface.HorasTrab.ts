"use client";
export interface IHorasTrab {
// 202501251
    id: number;
 
		cliente: number,
		processo: number,
		advogado: number,
		funcionario: number,
		servico: number,
		idcontatocrm: number,
		honorario: boolean,
		idagenda: number,
		data: string,
		status: number,
		hrini: string,
		hrfim: string,
		tempo: number,
		valor: number,
		obs: string,
		anexo: string,
		anexocomp: string,
		anexounc: string,
		auditor: undefined | null
}

export interface IHorasTrabFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IHorasTrabIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}