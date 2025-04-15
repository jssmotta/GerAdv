import { Auditor } from "../../Models/Auditor";

export interface IUF {
  id: number;
	pais : number;
	ddd : string;
	iduf : string;
	top : boolean;
	descricao : string;
	auditor?: Auditor | null;
}
