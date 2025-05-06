import { Auditor } from "./Auditor";

import { IEscritorios } from "../Escritorios/Interfaces/interface.Escritorios";
export interface Escritorios
{
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
	auditor?: Auditor | null;
}

export function EscritoriosEmpty(): IEscritorios {
// 20250125
    return {
        id: 0,
		cidade: 0,
		cnpj: '',
		casa: false,
		parceria: false,
		nome: '',
		oab: '',
		endereco: '',
		bairro: '',
		cep: '',
		fone: '',
		fax: '',
		site: '',
		email: '',
		obs: '',
		advresponsavel: '',
		secretaria: '',
		inscest: '',
		correspondente: false,
		top: false,
		etiqueta: false,
		bold: false,
		auditor: null
    };
}
