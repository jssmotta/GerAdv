import { Auditor } from "./Auditor";

import { IOponentesRepLegal } from "../OponentesRepLegal/Interfaces/interface.OponentesRepLegal";
export interface OponentesRepLegal
{
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

export function OponentesRepLegalEmpty(): IOponentesRepLegal {
// 20250125
    return {
        id: 0,
		oponente: 0,
		cidade: 0,
		nome: '',
		fone: '',
		sexo: false,
		cpf: '',
		rg: '',
		endereco: '',
		bairro: '',
		cep: '',
		fax: '',
		email: '',
		site: '',
		observacao: '',
		bold: false,
		auditor: null
    };
}
