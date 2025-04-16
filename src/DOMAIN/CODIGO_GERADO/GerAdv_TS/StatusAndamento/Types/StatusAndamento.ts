import { Auditor } from "../../Models/Auditor";

export interface IStatusAndamento {
  id: number;
	nome : string;
	icone : number;
	bold : boolean;
	auditor?: Auditor | null;
}
