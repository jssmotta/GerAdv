import { Auditor } from "../../Models/Auditor";

export interface ITiposAcao {
  id: number;
	nome : string;
	inativo : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
