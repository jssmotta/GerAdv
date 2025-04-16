import { Auditor } from "../../Models/Auditor";

export interface ITipoEndereco {
  id: number;
	descricao : string;
	auditor?: Auditor | null;
}
