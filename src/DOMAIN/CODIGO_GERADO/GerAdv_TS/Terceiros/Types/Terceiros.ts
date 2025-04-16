import { Auditor } from "../../Models/Auditor";

export interface ITerceiros {
  id: number;
	processo : number;
	situacao : number;
	cidade : number;
	nome : string;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	fax : string;
	obs : string;
	email : string;
	class : string;
	varaforocomarca : string;
	sexo : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}
