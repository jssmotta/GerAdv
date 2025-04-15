import { Auditor } from "../../Models/Auditor";

export interface IAuditor4K {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
