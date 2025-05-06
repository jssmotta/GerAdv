import { Auditor } from "../../Models/Auditor";

export interface ITipoEndereco {
  id: number;
	descricao : string;
	guid : string;
	auditor?: Auditor | null;
}
