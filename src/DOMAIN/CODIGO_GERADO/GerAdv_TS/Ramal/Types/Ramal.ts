import { Auditor } from "../../Models/Auditor";

export interface IRamal {
  id: number;
	nome : string;
	obs : string;
	auditor?: Auditor | null;
}
