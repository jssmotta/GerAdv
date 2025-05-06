import { Auditor } from "../../Models/Auditor";

export interface ITipoModeloDocumento {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
