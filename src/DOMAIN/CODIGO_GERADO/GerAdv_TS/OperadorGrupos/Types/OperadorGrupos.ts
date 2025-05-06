import { Auditor } from "../../Models/Auditor";

export interface IOperadorGrupos {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
