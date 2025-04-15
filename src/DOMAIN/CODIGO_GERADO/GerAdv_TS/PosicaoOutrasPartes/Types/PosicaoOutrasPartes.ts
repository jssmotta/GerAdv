import { Auditor } from "../../Models/Auditor";

export interface IPosicaoOutrasPartes {
  id: number;
	descricao : string;
	bold : boolean;
	auditor?: Auditor | null;
}
