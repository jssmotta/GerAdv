"use client";
export interface IContatoCRM {
// 202501251
    id: number;
 
		operador: number,
		cliente: number,
		processo: number,
		tipocontatocrm: number,
		ageclienteavisado: number,
		docsviarecebimento: number,
		naopublicavel: boolean,
		notificar: boolean,
		ocultar: boolean,
		assunto: string,
		isdocsrecebidos: boolean,
		quemnotificou: number,
		datanotificou: string,
		horanotificou: string,
		objetonotificou: number,
		pessoacontato: string,
		data: string,
		tempo: number,
		horainicial: string,
		horafinal: string,
		importante: boolean,
		urgente: boolean,
		gerarhoratrabalhada: boolean,
		exibirnotopo: boolean,
		contato: string,
		emocao: number,
		continuar: boolean,
		bold: boolean,
		auditor: undefined | null
}

export interface IContatoCRMFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IContatoCRMIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}