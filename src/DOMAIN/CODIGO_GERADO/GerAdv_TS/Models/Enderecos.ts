import { Auditor } from "./Auditor";

import { IEnderecos } from "../Enderecos/Interfaces/interface.Enderecos";
export interface Enderecos
{
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
	auditor?: Auditor | null;
}

export function EnderecosEmpty(): IEnderecos {
// 20250125
    return {
        id: 0,
		cidade: 0,
		topindex: false,
		descricao: '',
		contato: '',
		dtnasc: '',
		endereco: '',
		bairro: '',
		privativo: false,
		addcontato: false,
		cep: '',
		oab: '',
		obs: '',
		fone: '',
		fax: '',
		tratamento: '',
		site: '',
		email: '',
		quem: 0,
		quemindicou: '',
		reportecbonly: false,
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
