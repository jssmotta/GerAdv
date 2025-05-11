import { Auditor } from "../../Models/Auditor";

export interface IColaboradores {
  id: number;
	cargo : number;
	cliente : number;
	cidade : number;
	sexo : boolean;
	nome : string;
	cpf : string;
	rg : string;
	dtnasc : string;
	idade : number;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	observacao : string;
	email : string;
	cnh : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
