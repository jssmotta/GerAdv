import { Auditor } from "../../Models/Auditor";

export interface IRegimeTributacao {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
