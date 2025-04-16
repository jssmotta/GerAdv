import { Auditor } from "../../Models/Auditor";

export interface IOutrasPartesCliente {
  id: number;
	cidade : number;
	nome : string;
	terceirizado : boolean;
	clienteprincipal : number;
	tipo : boolean;
	sexo : boolean;
	dtnasc : string;
	cpf : string;
	rg : string;
	cnpj : string;
	inscest : string;
	nomefantasia : string;
	endereco : string;
	cep : string;
	bairro : string;
	fone : string;
	fax : string;
	email : string;
	site : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
