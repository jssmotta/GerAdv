import { Auditor } from "../../Models/Auditor";

export interface ITipoEnderecoSistema {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
