import { Auditor } from "./Auditor";

import { IAgendaFinanceiro } from "../AgendaFinanceiro/Interfaces/interface.AgendaFinanceiro";
export interface AgendaFinanceiro
{
    id: number;
	cidade : number;
	advogado : number;
	funcionario : number;
	tipocompromisso : number;
	cliente : number;
	area : number;
	justica : number;
	processo : number;
	usuario : number;
	preposto : number;
	idcob : number;
	idne : number;
	prazoprovisionado : number;
	oculto : number;
	cartaprecatoria : number;
	repetirdias : number;
	hrfinal : string;
	repetir : number;
	eventogerador : number;
	eventodata : string;
	data : string;
	eventoprazo : number;
	hora : string;
	compromisso : string;
	ddias : string;
	dias : number;
	liberado : boolean;
	importante : boolean;
	concluido : boolean;
	idhistorico : number;
	idinsprocesso : number;
	quemid : number;
	quemcodigo : number;
	status : string;
	valor : number;
	compromissohtml : string;
	decisao : string;
	revisar : boolean;
	revisarp2 : boolean;
	sempre : number;
	prazodias : number;
	protocolointegrado : number;
	datainicioprazo : string;
	usuariociente : boolean;
	auditor?: Auditor | null;
}

export function AgendaFinanceiroEmpty(): IAgendaFinanceiro {
// 20250125
    return {
        id: 0,
		cidade: 0,
		advogado: 0,
		funcionario: 0,
		tipocompromisso: 0,
		cliente: 0,
		area: 0,
		justica: 0,
		processo: 0,
		usuario: 0,
		preposto: 0,
		idcob: 0,
		idne: 0,
		prazoprovisionado: 0,
		oculto: 0,
		cartaprecatoria: 0,
		repetirdias: 0,
		hrfinal: '',
		repetir: 0,
		eventogerador: 0,
		eventodata: '',
		data: '',
		eventoprazo: 0,
		hora: '',
		compromisso: '',
		ddias: '',
		dias: 0,
		liberado: false,
		importante: false,
		concluido: false,
		idhistorico: 0,
		idinsprocesso: 0,
		quemid: 0,
		quemcodigo: 0,
		status: '',
		valor: 0,
		compromissohtml: '',
		decisao: '',
		revisar: false,
		revisarp2: false,
		sempre: 0,
		prazodias: 0,
		protocolointegrado: 0,
		datainicioprazo: '',
		usuariociente: false,
		auditor: null
    };
}
