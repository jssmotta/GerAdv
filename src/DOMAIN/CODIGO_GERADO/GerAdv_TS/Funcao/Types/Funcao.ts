import { Auditor } from "../../Models/Auditor";

export interface IFuncao {
  id: number;
	descricao : string;
	auditor?: Auditor | null;
}
