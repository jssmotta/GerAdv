import { Auditor } from "../../Models/Auditor";

export interface ITipoModeloDocumento {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
