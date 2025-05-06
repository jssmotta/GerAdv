import { Auditor } from "../../Models/Auditor";

export interface INENotas {
  id: number;
	apenso : number;
	precatoria : number;
	instancia : number;
	processo : number;
	movpro : boolean;
	nome : string;
	notaexpedida : boolean;
	revisada : boolean;
	palavrachave : number;
	data : string;
	notapublicada : string;
	auditor?: Auditor | null;
}
