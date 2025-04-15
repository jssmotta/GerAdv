import { Auditor } from "../../Models/Auditor";

export interface ISMSAlice {
  id: number;
	operador : number;
	tipoemail : number;
	nome : string;
	auditor?: Auditor | null;
}
