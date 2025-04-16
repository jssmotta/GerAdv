import { Auditor } from "../../Models/Auditor";

export interface IProTipoBaixa {
  id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}
