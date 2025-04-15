import { Auditor } from "../../Models/Auditor";

export interface IDiario2 {
  id: number;
	operador : number;
	cliente : number;
	data : string;
	hora : string;
	nome : string;
	ocorrencia : string;
	bold : boolean;
	auditor?: Auditor | null;
}
