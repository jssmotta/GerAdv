import { Auditor } from "../../Models/Auditor";

export interface ITribunal {
  id: number;
	area : number;
	justica : number;
	instancia : number;
	nome : string;
	descricao : string;
	sigla : string;
	web : string;
	etiqueta : boolean;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
