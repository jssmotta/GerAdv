import { Auditor } from "../../Models/Auditor";

export interface ICidade {
  id: number;
	uf : number;
	ddd : string;
	top : boolean;
	comarca : boolean;
	capital : boolean;
	nome : string;
	sigla : string;
	guid : string;
	auditor?: Auditor | null;
}
