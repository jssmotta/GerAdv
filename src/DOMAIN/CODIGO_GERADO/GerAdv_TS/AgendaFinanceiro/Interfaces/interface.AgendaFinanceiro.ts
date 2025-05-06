"use client";
export interface IAgendaFinanceiro {
// 202501251
    id: number;
 
		cidade: number,
		advogado: number,
		funcionario: number,
		tipocompromisso: number,
		cliente: number,
		area: number,
		justica: number,
		processo: number,
		usuario: number,
		preposto: number,
		idcob: number,
		idne: number,
		prazoprovisionado: number,
		oculto: number,
		cartaprecatoria: number,
		repetirdias: number,
		hrfinal: string,
		repetir: number,
		eventogerador: number,
		eventodata: string,
		data: string,
		eventoprazo: number,
		hora: string,
		compromisso: string,
		ddias: string,
		dias: number,
		liberado: boolean,
		importante: boolean,
		concluido: boolean,
		idhistorico: number,
		idinsprocesso: number,
		quemid: number,
		quemcodigo: number,
		status: string,
		valor: number,
		compromissohtml: string,
		decisao: string,
		revisar: boolean,
		revisarp2: boolean,
		sempre: number,
		prazodias: number,
		protocolointegrado: number,
		datainicioprazo: string,
		usuariociente: boolean,
		auditor: undefined | null
}

export interface IAgendaFinanceiroFormProps {
  id: number;
  onClose: () => void;
  onSuccess: () => void;
  onError: () => void;
}

export interface IAgendaFinanceiroIncProps {
    id: number;
    onClose: () => void;
    onSuccess: () => void;
    onError: () => void;
}