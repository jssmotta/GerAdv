import { Auditor } from "../../Models/Auditor";

export interface ISetor {
  id: number;
	descricao : string;
	auditor?: Auditor | null;
}
