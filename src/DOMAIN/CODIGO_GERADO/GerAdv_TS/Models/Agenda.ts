import { Auditor } from "./Auditor";

import { IAgenda } from "../Agenda/Interfaces/interface.Agenda";
export interface Agenda
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
	clienteavisado : boolean;
	revisarp2 : boolean;
	idne : number;
	oculto : number;
	cartaprecatoria : number;
	revisar : boolean;
	hrfinal : string;
	eventogerador : number;
	eventodata : string;
	data : string;
	eventoprazo : number;
	hora : string;
	compromisso : string;
	liberado : boolean;
	importante : boolean;
	concluido : boolean;
	idhistorico : number;
	idinsprocesso : number;
	quemid : number;
	quemcodigo : number;
	status : string;
	valor : number;
	decisao : string;
	sempre : number;
	prazodias : number;
	protocolointegrado : number;
	datainicioprazo : string;
	usuariociente : boolean;
	auditor?: Auditor | null;
}

export function AgendaEmpty(): IAgenda {
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
		clienteavisado: false,
		revisarp2: false,
		idne: 0,
		oculto: 0,
		cartaprecatoria: 0,
		revisar: false,
		hrfinal: '',
		eventogerador: 0,
		eventodata: '',
		data: '',
		eventoprazo: 0,
		hora: '',
		compromisso: '',
		liberado: false,
		importante: false,
		concluido: false,
		idhistorico: 0,
		idinsprocesso: 0,
		quemid: 0,
		quemcodigo: 0,
		status: '',
		valor: 0,
		decisao: '',
		sempre: 0,
		prazodias: 0,
		protocolointegrado: 0,
		datainicioprazo: '',
		usuariociente: false,
		auditor: null
    };
}
