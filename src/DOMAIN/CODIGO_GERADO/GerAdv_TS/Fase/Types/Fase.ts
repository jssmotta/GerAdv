import { Auditor } from "../../Models/Auditor";

export interface IFase {
  id: number;
	justica : number;
	area : number;
	descricao : string;
	auditor?: Auditor | null;
}
