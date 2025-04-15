import { Auditor } from "../../Models/Auditor";

export interface IGUTPeriodicidade {
  id: number;
	nome : string;
	intervalodias : number;
	auditor?: Auditor | null;
}
