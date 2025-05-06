import { Auditor } from "../../Models/Auditor";

export interface IProCDA {
  id: number;
	processo : number;
	nome : string;
	nrointerno : string;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
