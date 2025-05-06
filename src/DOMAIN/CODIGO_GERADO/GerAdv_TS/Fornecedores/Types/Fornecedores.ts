import { Auditor } from "../../Models/Auditor";

export interface IFornecedores {
  id: number;
	cidade : number;
	grupo : number;
	nome : string;
	subgrupo : number;
	tipo : boolean;
	sexo : boolean;
	cnpj : string;
	inscest : string;
	cpf : string;
	rg : string;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	fax : string;
	email : string;
	site : string;
	obs : string;
	produtos : string;
	contatos : string;
	etiqueta : boolean;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
