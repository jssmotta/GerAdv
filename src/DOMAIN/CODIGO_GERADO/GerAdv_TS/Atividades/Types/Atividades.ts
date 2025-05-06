import { Auditor } from "../../Models/Auditor";

export interface IAtividades {
  id: number;
	descricao : string;
	guid : string;
	auditor?: Auditor | null;
}
