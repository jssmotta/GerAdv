import { Auditor } from "../../Models/Auditor";

export interface IAtividades {
  id: number;
	descricao : string;
	auditor?: Auditor | null;
}
