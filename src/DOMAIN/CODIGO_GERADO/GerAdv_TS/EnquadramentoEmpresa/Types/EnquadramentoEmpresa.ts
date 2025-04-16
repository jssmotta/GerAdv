import { Auditor } from "../../Models/Auditor";

export interface IEnquadramentoEmpresa {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
