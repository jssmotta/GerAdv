import { Auditor } from "../../Models/Auditor";

export interface IAlarmSMS {
  id: number;
	operador : number;
	agenda : number;
	recado : number;
	descricao : string;
	hora : number;
	minuto : number;
	d1 : boolean;
	d2 : boolean;
	d3 : boolean;
	d4 : boolean;
	d5 : boolean;
	d6 : boolean;
	d7 : boolean;
	email : string;
	desativar : boolean;
	today : string;
	excetodiasfelizes : boolean;
	desktop : boolean;
	alertardatahora : string;
	emocao : number;
	auditor?: Auditor | null;
}
