import { Auditor } from "../../Models/Auditor";

export interface IObjetos {
  id: number;
	justica : number;
	area : number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}
