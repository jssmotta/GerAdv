import { Auditor } from "../../Models/Auditor";

export interface IAlertas {
  id: number;
	operador : number;
	nome : string;
	data : string;
	dataate : string;
	auditor?: Auditor | null;
}
