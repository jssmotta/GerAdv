import { Auditor } from "./Auditor";

import { IClientesSocios } from "../ClientesSocios/Interfaces/interface.ClientesSocios";
export interface ClientesSocios
{
    id: number;
	cliente : number;
	cidade : number;
	cidadesocio : number;
	somenterepresentante : boolean;
	idade : number;
	isrepresentantelegal : boolean;
	qualificacao : string;
	sexo : boolean;
	dtnasc : string;
	nome : string;
	site : string;
	representantelegal : string;
	endereco : string;
	bairro : string;
	cep : string;
	rg : string;
	cpf : string;
	fone : string;
	participacao : string;
	cargo : string;
	email : string;
	obs : string;
	cnh : string;
	datacontrato : string;
	cnpj : string;
	inscest : string;
	socioempresaadminnome : string;
	enderecosocio : string;
	bairrosocio : string;
	cepsocio : string;
	rgdataexp : string;
	socioempresaadminsomente : boolean;
	tipo : boolean;
	fax : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ClientesSociosEmpty(): IClientesSocios {
// 20250125
    return {
        id: 0,
		cliente: 0,
		cidade: 0,
		cidadesocio: 0,
		somenterepresentante: false,
		idade: 0,
		isrepresentantelegal: false,
		qualificacao: '',
		sexo: false,
		dtnasc: '',
		nome: '',
		site: '',
		representantelegal: '',
		endereco: '',
		bairro: '',
		cep: '',
		rg: '',
		cpf: '',
		fone: '',
		participacao: '',
		cargo: '',
		email: '',
		obs: '',
		cnh: '',
		datacontrato: '',
		cnpj: '',
		inscest: '',
		socioempresaadminnome: '',
		enderecosocio: '',
		bairrosocio: '',
		cepsocio: '',
		rgdataexp: '',
		socioempresaadminsomente: false,
		tipo: false,
		fax: '',
		class: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
