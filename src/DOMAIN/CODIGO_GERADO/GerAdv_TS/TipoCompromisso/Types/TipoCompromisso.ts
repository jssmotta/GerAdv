import { Auditor } from "../../Models/Auditor";

export interface ITipoCompromisso {
  id: number;
	icone : number;
	descricao : string;
	financeiro : boolean;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
