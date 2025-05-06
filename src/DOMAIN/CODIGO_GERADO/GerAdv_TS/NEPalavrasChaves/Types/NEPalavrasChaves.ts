import { Auditor } from "../../Models/Auditor";

export interface INEPalavrasChaves {
  id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}
