import { Auditor } from "../../Models/Auditor";

export interface IAuditor4K {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
