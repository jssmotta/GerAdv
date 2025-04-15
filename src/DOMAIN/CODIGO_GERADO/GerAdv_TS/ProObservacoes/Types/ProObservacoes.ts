import { Auditor } from "../../Models/Auditor";

export interface IProObservacoes {
  id: number;
	processo : number;
	nome : string;
	observacoes : string;
	data : string;
	auditor?: Auditor | null;
}
