import { Auditor } from "../../Models/Auditor";

export interface IPreClientes {
  id: number;
	idrep : number;
	cidade : number;
	inativo : boolean;
	quemindicou : string;
	nome : string;
	adv : number;
	juridica : boolean;
	nomefantasia : string;
	class : string;
	tipo : boolean;
	dtnasc : string;
	inscest : string;
	qualificacao : string;
	sexo : boolean;
	idade : number;
	cnpj : string;
	cpf : string;
	rg : string;
	tipocaptacao : boolean;
	observacao : string;
	endereco : string;
	bairro : string;
	cep : string;
	fax : string;
	fone : string;
	data : string;
	homepage : string;
	email : string;
	assistido : string;
	assrg : string;
	asscpf : string;
	assendereco : string;
	cnh : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
