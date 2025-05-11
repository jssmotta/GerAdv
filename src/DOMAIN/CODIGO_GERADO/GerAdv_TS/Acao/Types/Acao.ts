import { Auditor } from "../../Models/Auditor";

export interface IAcao {
  id: number;
	justica : number;
	area : number;
	descricao : string;
	guid : string;
	auditor?: Auditor | null;
}
