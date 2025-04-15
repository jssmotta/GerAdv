import { Auditor } from "../../Models/Auditor";

export interface IProProcuradores {
  id: number;
	advogado : number;
	processo : number;
	nome : string;
	data : string;
	substabelecimento : boolean;
	procuracao : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
