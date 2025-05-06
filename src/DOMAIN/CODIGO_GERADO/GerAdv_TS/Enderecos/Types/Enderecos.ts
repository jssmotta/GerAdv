import { Auditor } from "../../Models/Auditor";

export interface IEnderecos {
  id: number;
	cidade : number;
	topindex : boolean;
	descricao : string;
	contato : string;
	dtnasc : string;
	endereco : string;
	bairro : string;
	privativo : boolean;
	addcontato : boolean;
	cep : string;
	oab : string;
	obs : string;
	fone : string;
	fax : string;
	tratamento : string;
	site : string;
	email : string;
	quem : number;
	quemindicou : string;
	reportecbonly : boolean;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	guid : string;
	auditor?: Auditor | null;
}
