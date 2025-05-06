import { Auditor } from "../../Models/Auditor";

export interface IBensClassificacao {
  id: number;
	nome : string;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
