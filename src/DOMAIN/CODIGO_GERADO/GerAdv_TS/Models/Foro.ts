import { Auditor } from "./Auditor";

import { IForo } from "../Foro/Interfaces/interface.Foro";
export interface Foro
{
    id: number;
	cidade : number;
	email : string;
	nome : string;
	unico : boolean;
	site : string;
	endereco : string;
	bairro : string;
	fone : string;
	fax : string;
	cep : string;
	obs : string;
	unicoconfirmado : boolean;
	web : string;
	etiqueta : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ForoEmpty(): IForo {
// 20250125
    return {
        id: 0,
		cidade: 0,
		email: '',
		nome: '',
		unico: false,
		site: '',
		endereco: '',
		bairro: '',
		fone: '',
		fax: '',
		cep: '',
		obs: '',
		unicoconfirmado: false,
		web: '',
		etiqueta: false,
		bold: false,
		auditor: null
    };
}
