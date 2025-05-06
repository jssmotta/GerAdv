import { Auditor } from "../../Models/Auditor";

export interface IOponentesRepLegal {
  id: number;
	oponente : number;
	cidade : number;
	nome : string;
	fone : string;
	sexo : boolean;
	cpf : string;
	rg : string;
	endereco : string;
	bairro : string;
	cep : string;
	fax : string;
	email : string;
	site : string;
	observacao : string;
	bold : boolean;
	auditor?: Auditor | null;
}
