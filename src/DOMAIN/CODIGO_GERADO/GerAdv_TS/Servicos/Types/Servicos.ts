import { Auditor } from "../../Models/Auditor";

export interface IServicos {
  id: number;
	cobrar : boolean;
	descricao : string;
	basico : boolean;
	guid : string;
	auditor?: Auditor | null;
}
