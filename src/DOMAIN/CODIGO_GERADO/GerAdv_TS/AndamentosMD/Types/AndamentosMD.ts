import { Auditor } from "../../Models/Auditor";

export interface IAndamentosMD {
  id: number;
	processo : number;
	nome : string;
	andamento : number;
	pathfull : string;
	unc : string;
	auditor?: Auditor | null;
}
