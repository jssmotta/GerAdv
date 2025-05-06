import { Auditor } from "../../Models/Auditor";

export interface IJustica {
  id: number;
	nome : string;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
