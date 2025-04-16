import { Auditor } from "./Auditor";

import { IFornecedores } from "../Fornecedores/Interfaces/interface.Fornecedores";
export interface Fornecedores
{
    id: number;
	cidade : number;
	grupo : number;
	nome : string;
	subgrupo : number;
	tipo : boolean;
	sexo : boolean;
	cnpj : string;
	inscest : string;
	cpf : string;
	rg : string;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	fax : string;
	email : string;
	site : string;
	obs : string;
	produtos : string;
	contatos : string;
	etiqueta : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function FornecedoresEmpty(): IFornecedores {
// 20250125
    return {
        id: 0,
		cidade: 0,
		grupo: 0,
		nome: '',
		subgrupo: 0,
		tipo: false,
		sexo: false,
		cnpj: '',
		inscest: '',
		cpf: '',
		rg: '',
		endereco: '',
		bairro: '',
		cep: '',
		fone: '',
		fax: '',
		email: '',
		site: '',
		obs: '',
		produtos: '',
		contatos: '',
		etiqueta: false,
		bold: false,
		auditor: null
    };
}
