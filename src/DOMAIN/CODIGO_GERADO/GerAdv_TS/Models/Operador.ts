import { Auditor } from "./Auditor";

import { IOperador } from "../Operador/Interfaces/interface.Operador";
export interface Operador
{
    id: number;
	statusid : number;
	email : string;
	pasta : string;
	telefonista : boolean;
	master : boolean;
	nome : string;
	nick : string;
	ramal : string;
	cadid : number;
	cadcod : number;
	excluido : boolean;
	situacao : boolean;
	computador : number;
	minhadescricao : string;
	ultimologoff : string;
	emailnet : string;
	onlineip : string;
	online : boolean;
	sysop : boolean;
	statusmessage : string;
	isfinanceiro : boolean;
	top : boolean;
	sexo : boolean;
	basico : boolean;
	externo : boolean;
	senha256 : string;
	emailconfirmado : boolean;
	datalimitereset : string;
	suportesenha256 : string;
	suportemaxage : string;
	suportenomesolicitante : string;
	suporteultimoacesso : string;
	suporteipultimoacesso : string;
	auditor?: Auditor | null;
}

export function OperadorEmpty(): IOperador {
// 20250125
    return {
        id: 0,
		statusid: 0,
		email: '',
		pasta: '',
		telefonista: false,
		master: false,
		nome: '',
		nick: '',
		ramal: '',
		cadid: 0,
		cadcod: 0,
		excluido: false,
		situacao: false,
		computador: 0,
		minhadescricao: '',
		ultimologoff: '',
		emailnet: '',
		onlineip: '',
		online: false,
		sysop: false,
		statusmessage: '',
		isfinanceiro: false,
		top: false,
		sexo: false,
		basico: false,
		externo: false,
		senha256: '',
		emailconfirmado: false,
		datalimitereset: '',
		suportesenha256: '',
		suportemaxage: '',
		suportenomesolicitante: '',
		suporteultimoacesso: '',
		suporteipultimoacesso: '',
		auditor: null
    };
}
