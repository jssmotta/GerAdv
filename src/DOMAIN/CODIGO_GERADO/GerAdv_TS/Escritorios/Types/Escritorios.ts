import { Auditor } from "../../Models/Auditor";

export interface IEscritorios {
  id: number;
	cidade : number;
	cnpj : string;
	casa : boolean;
	parceria : boolean;
	nome : string;
	oab : string;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	fax : string;
	site : string;
	email : string;
	obs : string;
	advresponsavel : string;
	secretaria : string;
	inscest : string;
	correspondente : boolean;
	top : boolean;
	etiqueta : boolean;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
