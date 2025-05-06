import { Auditor } from "./Auditor";

import { IOutrasPartesCliente } from "../OutrasPartesCliente/Interfaces/interface.OutrasPartesCliente";
export interface OutrasPartesCliente
{
    id: number;
	cidade : number;
	nome : string;
	terceirizado : boolean;
	clienteprincipal : number;
	tipo : boolean;
	sexo : boolean;
	dtnasc : string;
	cpf : string;
	rg : string;
	cnpj : string;
	inscest : string;
	nomefantasia : string;
	endereco : string;
	cep : string;
	bairro : string;
	fone : string;
	fax : string;
	email : string;
	site : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function OutrasPartesClienteEmpty(): IOutrasPartesCliente {
// 20250125
    return {
        id: 0,
		cidade: 0,
		nome: '',
		terceirizado: false,
		clienteprincipal: 0,
		tipo: false,
		sexo: false,
		dtnasc: '',
		cpf: '',
		rg: '',
		cnpj: '',
		inscest: '',
		nomefantasia: '',
		endereco: '',
		cep: '',
		bairro: '',
		fone: '',
		fax: '',
		email: '',
		site: '',
		class: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
