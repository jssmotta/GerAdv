import { IOponentesRepLegal } from '../OponentesRepLegal/Interfaces/interface.OponentesRepLegal';
export interface OponentesRepLegal
{
    id: number;
	oponente : number;
	cidade : number;
	nome : string;
	fone : string;
	sexo : boolean;
	cpf : string;
	rg : string;
	endereco : string;
	bairro : string;
	cep : string;
	fax : string;
	email : string;
	site : string;
	observacao : string;
	bold : boolean;
	nomeoponentes?: string;
	nomecidade?: string;

}


export function OponentesRepLegalEmpty(): IOponentesRepLegal {
// 20250604
    
    return {
        id: 0,
		oponente: 0,
		cidade: 0,
		nome: '',
		fone: '',
		sexo: false,
		cpf: '',
		rg: '',
		endereco: '',
		bairro: '',
		cep: '',
		fax: '',
		email: '',
		site: '',
		observacao: '',
		bold: false,
    };
}

export function OponentesRepLegalTestEmpty(): IOponentesRepLegal {
// 20250604
    
    return {
        id: 1,
		oponente: 1,
		cidade: 1,
		nome: 'X',
		fone: 'X',
		sexo: true,
		cpf: 'X',
		rg: 'X',
		endereco: 'X',
		bairro: 'X',
		cep: 'X',
		fax: 'X',
		email: 'X',
		site: 'X',
		observacao: 'X',
		bold: true,
    };
}


