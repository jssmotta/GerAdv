import { Auditor } from "../../Models/Auditor";

export interface IArea {
  id: number;
	descricao : string;
	top : boolean;
	guid : string;
	auditor?: Auditor | null;
}
