import { Auditor } from "../../Models/Auditor";

export interface ICargosEscClass {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
