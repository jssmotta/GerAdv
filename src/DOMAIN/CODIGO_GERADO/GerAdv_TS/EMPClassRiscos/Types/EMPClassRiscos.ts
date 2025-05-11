import { Auditor } from "../../Models/Auditor";

export interface IEMPClassRiscos {
  id: number;
	nome : string;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
