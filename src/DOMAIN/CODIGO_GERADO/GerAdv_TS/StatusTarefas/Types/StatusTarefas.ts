import { Auditor } from "../../Models/Auditor";

export interface IStatusTarefas {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
