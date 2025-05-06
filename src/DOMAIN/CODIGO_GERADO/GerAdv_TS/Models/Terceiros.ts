import { Auditor } from "./Auditor";

import { ITerceiros } from "../Terceiros/Interfaces/interface.Terceiros";
export interface Terceiros
{
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

export function TerceirosEmpty(): ITerceiros {
// 20250125
    return {
        id: 0,
		processo: 0,
		situacao: 0,
		cidade: 0,
		nome: '',
		endereco: '',
		bairro: '',
		cep: '',
		fone: '',
		fax: '',
		obs: '',
		email: '',
		class: '',
		varaforocomarca: '',
		sexo: false,
		bold: false,
		auditor: null
    };
}
