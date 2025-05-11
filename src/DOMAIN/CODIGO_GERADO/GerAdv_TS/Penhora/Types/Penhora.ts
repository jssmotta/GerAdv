import { Auditor } from "../../Models/Auditor";

export interface IPenhora {
  id: number;
	processo : number;
	penhorastatus : number;
	nome : string;
	descricao : string;
	datapenhora : string;
	master : number;
	guid : string;
	auditor?: Auditor | null;
}
