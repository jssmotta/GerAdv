import { Auditor } from "../../Models/Auditor";

export interface IServicos {
  id: number;
	cobrar : boolean;
	descricao : string;
	basico : boolean;
	auditor?: Auditor | null;
}
