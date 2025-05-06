import { Auditor } from "../../Models/Auditor";

export interface ILigacoes {
  id: number;
	cliente : number;
	ramal : number;
	processo : number;
	assunto : string;
	ageclienteavisado : number;
	celular : boolean;
	contato : string;
	datarealizada : string;
	quemid : number;
	telefonista : number;
	ultimoaviso : string;
	horafinal : string;
	nome : string;
	quemcodigo : number;
	solicitante : number;
	para : string;
	fone : string;
	particular : boolean;
	realizada : boolean;
	status : string;
	data : string;
	hora : string;
	urgente : boolean;
	ligarpara : string;
	startscreen : boolean;
	emotion : number;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
