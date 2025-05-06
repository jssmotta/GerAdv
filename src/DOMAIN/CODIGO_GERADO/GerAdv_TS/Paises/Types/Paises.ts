import { Auditor } from "../../Models/Auditor";

export interface IPaises {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
