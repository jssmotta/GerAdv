import { Auditor } from "../../Models/Auditor";

export interface IGUTTipo {
  id: number;
	nome : string;
	ordem : number;
	auditor?: Auditor | null;
}
