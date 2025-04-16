import { Auditor } from "../../Models/Auditor";

export interface IAcao {
  id: number;
	justica : number;
	area : number;
	descricao : string;
	auditor?: Auditor | null;
}
