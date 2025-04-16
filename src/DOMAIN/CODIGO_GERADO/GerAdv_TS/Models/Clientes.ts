import { Auditor } from "./Auditor";

import { IClientes } from "../Clientes/Interfaces/interface.Clientes";
export interface Clientes
{
    id: number;
	cidade : number;
	regimetributacao : number;
	enquadramentoempresa : number;
	empresa : number;
	icone : string;
	nomemae : string;
	rgdataexp : string;
	inativo : boolean;
	quemindicou : string;
	sendemail : boolean;
	nome : string;
	adv : number;
	idrep : number;
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
	obito : boolean;
	nomepai : string;
	rgoexpeditor : string;
	reportecbonly : boolean;
	probono : boolean;
	cnh : string;
	pessoacontato : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ClientesEmpty(): IClientes {
// 20250125
    return {
        id: 0,
		cidade: 0,
		regimetributacao: 0,
		enquadramentoempresa: 0,
		empresa: 0,
		icone: '',
		nomemae: '',
		rgdataexp: '',
		inativo: false,
		quemindicou: '',
		sendemail: false,
		nome: '',
		adv: 0,
		idrep: 0,
		juridica: false,
		nomefantasia: '',
		class: '',
		tipo: false,
		dtnasc: '',
		inscest: '',
		qualificacao: '',
		sexo: false,
		idade: 0,
		cnpj: '',
		cpf: '',
		rg: '',
		tipocaptacao: false,
		observacao: '',
		endereco: '',
		bairro: '',
		cep: '',
		fax: '',
		fone: '',
		data: '',
		homepage: '',
		email: '',
		obito: false,
		nomepai: '',
		rgoexpeditor: '',
		reportecbonly: false,
		probono: false,
		cnh: '',
		pessoacontato: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
