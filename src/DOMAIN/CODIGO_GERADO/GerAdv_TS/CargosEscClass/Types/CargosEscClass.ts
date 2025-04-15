import { Auditor } from "../../Models/Auditor";

export interface ICargosEscClass {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
