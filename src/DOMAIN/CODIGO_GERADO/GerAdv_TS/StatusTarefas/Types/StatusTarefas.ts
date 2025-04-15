import { Auditor } from "../../Models/Auditor";

export interface IStatusTarefas {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
