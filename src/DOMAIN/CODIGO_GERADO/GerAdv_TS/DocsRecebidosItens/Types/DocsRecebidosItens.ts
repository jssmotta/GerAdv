import { Auditor } from "../../Models/Auditor";

export interface IDocsRecebidosItens {
  id: number;
	contatocrm : number;
	nome : string;
	devolvido : boolean;
	seradevolvido : boolean;
	observacoes : string;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
