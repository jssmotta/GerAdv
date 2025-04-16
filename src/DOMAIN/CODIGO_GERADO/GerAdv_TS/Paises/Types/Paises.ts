import { Auditor } from "../../Models/Auditor";

export interface IPaises {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
