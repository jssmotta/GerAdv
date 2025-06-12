import { IClientesSocios } from '../ClientesSocios/Interfaces/interface.ClientesSocios';
export interface ClientesSocios
{
    id: number;
	cliente : number;
	cidade : number;
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
	cidadesocio : number;
	rgdataexp : string;
	socioempresaadminsomente : boolean;
	tipo : boolean;
	fax : string;
	class : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	nomeclientes?: string;
	nomecidade?: string;

}


export function ClientesSociosEmpty(): IClientesSocios {
// 20250604
    
    return {
        id: 0,
		cliente: 0,
		cidade: 0,
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
		cidadesocio: 0,
		rgdataexp: '',
		socioempresaadminsomente: false,
		tipo: false,
		fax: '',
		class: '',
		etiqueta: false,
		ani: false,
		bold: false,
    };
}

export function ClientesSociosTestEmpty(): IClientesSocios {
// 20250604
    
    return {
        id: 1,
		cliente: 1,
		cidade: 1,
		somenterepresentante: true,
		idade: 1,
		isrepresentantelegal: true,
		qualificacao: 'X',
		sexo: true,
		dtnasc: 'X',
		nome: 'X',
		site: 'X',
		representantelegal: 'X',
		endereco: 'X',
		bairro: 'X',
		cep: 'X',
		rg: 'X',
		cpf: 'X',
		fone: 'X',
		participacao: 'X',
		cargo: 'X',
		email: 'X',
		obs: 'X',
		cnh: 'X',
		datacontrato: 'X',
		cnpj: 'X',
		inscest: 'X',
		socioempresaadminnome: 'X',
		enderecosocio: 'X',
		bairrosocio: 'X',
		cepsocio: 'X',
		cidadesocio: 1,
		rgdataexp: 'X',
		socioempresaadminsomente: true,
		tipo: true,
		fax: 'X',
		class: 'X',
		etiqueta: true,
		ani: true,
		bold: true,
    };
}


