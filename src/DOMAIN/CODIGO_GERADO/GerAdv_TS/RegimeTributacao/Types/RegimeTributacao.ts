import { Auditor } from "../../Models/Auditor";

export interface IRegimeTributacao {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
