import { Auditor } from "../../Models/Auditor";

export interface IForo {
  id: number;
	cidade : number;
	email : string;
	nome : string;
	unico : boolean;
	site : string;
	endereco : string;
	bairro : string;
	fone : string;
	fax : string;
	cep : string;
	obs : string;
	unicoconfirmado : boolean;
	web : string;
	etiqueta : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
