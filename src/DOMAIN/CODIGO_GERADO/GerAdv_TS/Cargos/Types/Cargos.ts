import { Auditor } from "../../Models/Auditor";

export interface ICargos {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
