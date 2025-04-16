import { Auditor } from "../../Models/Auditor";

export interface ITipoContatoCRM {
  id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}
