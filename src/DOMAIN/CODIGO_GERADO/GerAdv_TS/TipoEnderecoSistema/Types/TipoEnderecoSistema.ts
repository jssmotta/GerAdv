import { Auditor } from "../../Models/Auditor";

export interface ITipoEnderecoSistema {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
