import { Auditor } from "../../Models/Auditor";

export interface IOperador {
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
	guid : string;
	auditor?: Auditor | null;
}
