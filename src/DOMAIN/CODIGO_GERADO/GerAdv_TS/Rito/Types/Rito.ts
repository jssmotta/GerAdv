import { Auditor } from "../../Models/Auditor";

export interface IRito {
  id: number;
	descricao : string;
	top : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
