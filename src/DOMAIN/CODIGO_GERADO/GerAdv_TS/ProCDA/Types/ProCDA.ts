import { Auditor } from "../../Models/Auditor";

export interface IProCDA {
  id: number;
	processo : number;
	nome : string;
	nrointerno : string;
	bold : boolean;
	auditor?: Auditor | null;
}
