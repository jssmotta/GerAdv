import { Auditor } from "../../Models/Auditor";

export interface IEventoPrazoAgenda {
  id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}
