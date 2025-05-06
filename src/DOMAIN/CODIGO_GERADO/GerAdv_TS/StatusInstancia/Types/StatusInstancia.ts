import { Auditor } from "../../Models/Auditor";

export interface IStatusInstancia {
  id: number;
	nome : string;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
