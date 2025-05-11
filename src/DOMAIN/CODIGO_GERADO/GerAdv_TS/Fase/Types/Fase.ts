import { Auditor } from "../../Models/Auditor";

export interface IFase {
  id: number;
	justica : number;
	area : number;
	descricao : string;
	guid : string;
	auditor?: Auditor | null;
}
