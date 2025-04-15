import { Auditor } from "./Auditor";

import { IOponentes } from "../Oponentes/Interfaces/interface.Oponentes";
export interface Oponentes
{
    id: number;
	cidade : number;
	empfuncao : number;
	ctpsnumero : string;
	site : string;
	ctpsserie : string;
	nome : string;
	adv : number;
	empcliente : number;
	idrep : number;
	pis : string;
	contato : string;
	cnpj : string;
	rg : string;
	juridica : boolean;
	tipo : boolean;
	sexo : boolean;
	cpf : string;
	endereco : string;
	fone : string;
	fax : string;
	bairro : string;
	cep : string;
	inscest : string;
	observacao : string;
	email : string;
	class : string;
	top : boolean;
	etiqueta : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function OponentesEmpty(): IOponentes {
// 20250125
    return {
        id: 0,
		cidade: 0,
		empfuncao: 0,
		ctpsnumero: '',
		site: '',
		ctpsserie: '',
		nome: '',
		adv: 0,
		empcliente: 0,
		idrep: 0,
		pis: '',
		contato: '',
		cnpj: '',
		rg: '',
		juridica: false,
		tipo: false,
		sexo: false,
		cpf: '',
		endereco: '',
		fone: '',
		fax: '',
		bairro: '',
		cep: '',
		inscest: '',
		observacao: '',
		email: '',
		class: '',
		top: false,
		etiqueta: false,
		bold: false,
		auditor: null
    };
}
