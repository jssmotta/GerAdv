import { Auditor } from "../../Models/Auditor";

export interface ITipoRecurso {
  id: number;
	justica : number;
	area : number;
	descricao : string;
	auditor?: Auditor | null;
}
