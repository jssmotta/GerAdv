import { Auditor } from "../../Models/Auditor";

export interface ISetor {
  id: number;
	descricao : string;
	guid : string;
	auditor?: Auditor | null;
}
