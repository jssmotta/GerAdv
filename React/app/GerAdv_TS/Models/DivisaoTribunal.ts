import { IDivisaoTribunal } from '../DivisaoTribunal/Interfaces/interface.DivisaoTribunal';
export interface DivisaoTribunal
{
    id: number;
	justica : number;
	area : number;
	cidade : number;
	foro : number;
	tribunal : number;
	numcodigo : number;
	nomeespecial : string;
	codigodiv : string;
	endereco : string;
	fone : string;
	fax : string;
	cep : string;
	obs : string;
	email : string;
	andar : string;
	etiqueta : boolean;
	bold : boolean;
	nomejustica?: string;
	descricaoarea?: string;
	nomecidade?: string;
	nomeforo?: string;
	nometribunal?: string;

}


export function DivisaoTribunalEmpty(): IDivisaoTribunal {
// 20250604
    
    return {
        id: 0,
		justica: 0,
		area: 0,
		cidade: 0,
		foro: 0,
		tribunal: 0,
		numcodigo: 0,
		nomeespecial: '',
		codigodiv: '',
		endereco: '',
		fone: '',
		fax: '',
		cep: '',
		obs: '',
		email: '',
		andar: '',
		etiqueta: false,
		bold: false,
    };
}

export function DivisaoTribunalTestEmpty(): IDivisaoTribunal {
// 20250604
    
    return {
        id: 1,
		justica: 1,
		area: 1,
		cidade: 1,
		foro: 1,
		tribunal: 1,
		numcodigo: 1,
		nomeespecial: 'X',
		codigodiv: 'X',
		endereco: 'X',
		fone: 'X',
		fax: 'X',
		cep: 'X',
		obs: 'X',
		email: 'X',
		andar: 'X',
		etiqueta: true,
		bold: true,
    };
}


