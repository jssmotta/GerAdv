import { Auditor } from "../../Models/Auditor";

export interface IProObservacoes {
  id: number;
	processo : number;
	nome : string;
	observacoes : string;
	data : string;
	guid : string;
	auditor?: Auditor | null;
}
