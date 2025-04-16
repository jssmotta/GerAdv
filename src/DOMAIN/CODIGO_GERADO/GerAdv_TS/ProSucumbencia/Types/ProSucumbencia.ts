import { Auditor } from "../../Models/Auditor";

export interface IProSucumbencia {
  id: number;
	processo : number;
	instancia : number;
	tipoorigemsucumbencia : number;
	data : string;
	nome : string;
	valor : number;
	percentual : string;
	auditor?: Auditor | null;
}
