import { IOponentes } from '../Oponentes/Interfaces/interface.Oponentes';
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
	nomecidade?: string;

}


export function OponentesEmpty(): IOponentes {
// 20250604
    
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
    };
}

export function OponentesTestEmpty(): IOponentes {
// 20250604
    
    return {
        id: 1,
		cidade: 1,
		empfuncao: 1,
		ctpsnumero: 'X',
		site: 'X',
		ctpsserie: 'X',
		nome: 'X',
		adv: 1,
		empcliente: 1,
		idrep: 1,
		pis: 'X',
		contato: 'X',
		cnpj: 'X',
		rg: 'X',
		juridica: true,
		tipo: true,
		sexo: true,
		cpf: 'X',
		endereco: 'X',
		fone: 'X',
		fax: 'X',
		bairro: 'X',
		cep: 'X',
		inscest: 'X',
		observacao: 'X',
		email: 'X',
		class: 'X',
		top: true,
		etiqueta: true,
		bold: true,
    };
}


