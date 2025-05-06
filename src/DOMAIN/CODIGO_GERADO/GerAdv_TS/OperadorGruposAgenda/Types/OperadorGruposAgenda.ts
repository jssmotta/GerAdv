import { Auditor } from "../../Models/Auditor";

export interface IOperadorGruposAgenda {
  id: number;
	operador : number;
	sqlwhere : string;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
