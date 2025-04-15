import { Auditor } from "./Auditor";

import { IPreClientes } from "../PreClientes/Interfaces/interface.PreClientes";
export interface PreClientes
{
    id: number;
	idrep : number;
	cidade : number;
	inativo : boolean;
	quemindicou : string;
	nome : string;
	adv : number;
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
	assistido : string;
	assrg : string;
	asscpf : string;
	assendereco : string;
	cnh : string;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function PreClientesEmpty(): IPreClientes {
// 20250125
    return {
        id: 0,
		idrep: 0,
		cidade: 0,
		inativo: false,
		quemindicou: '',
		nome: '',
		adv: 0,
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
		assistido: '',
		assrg: '',
		asscpf: '',
		assendereco: '',
		cnh: '',
		etiqueta: false,
		ani: false,
		bold: false,
		auditor: null
    };
}
