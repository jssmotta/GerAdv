import { Auditor } from "../../Models/Auditor";

export interface IGUTAtividades {
  id: number;
	gutperiodicidade : number;
	operador : number;
	nome : string;
	observacao : string;
	gutgrupo : number;
	concluido : boolean;
	dataconcluido : string;
	diasparainiciar : number;
	minutospararealizar : number;
	guid : string;
	auditor?: Auditor | null;
}
