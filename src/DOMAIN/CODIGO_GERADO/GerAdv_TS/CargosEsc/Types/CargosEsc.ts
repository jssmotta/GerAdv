import { Auditor } from "../../Models/Auditor";

export interface ICargosEsc {
  id: number;
	percentual : number;
	nome : string;
	classificacao : number;
	guid : string;
	auditor?: Auditor | null;
}
