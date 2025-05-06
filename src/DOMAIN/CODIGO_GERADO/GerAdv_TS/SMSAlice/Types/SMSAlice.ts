import { Auditor } from "../../Models/Auditor";

export interface ISMSAlice {
  id: number;
	operador : number;
	tipoemail : number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
