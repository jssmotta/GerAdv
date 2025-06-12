import { IFornecedores } from '../Fornecedores/Interfaces/interface.Fornecedores';
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
	nomecidade?: string;

}


export function FornecedoresEmpty(): IFornecedores {
// 20250604
    
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
    };
}

export function FornecedoresTestEmpty(): IFornecedores {
// 20250604
    
    return {
        id: 1,
		cidade: 1,
		grupo: 1,
		nome: 'X',
		subgrupo: 1,
		tipo: true,
		sexo: true,
		cnpj: 'X',
		inscest: 'X',
		cpf: 'X',
		rg: 'X',
		endereco: 'X',
		bairro: 'X',
		cep: 'X',
		fone: 'X',
		fax: 'X',
		email: 'X',
		site: 'X',
		obs: 'X',
		produtos: 'X',
		contatos: 'X',
		etiqueta: true,
		bold: true,
    };
}


