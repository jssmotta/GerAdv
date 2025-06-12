import { IForo } from '../Foro/Interfaces/interface.Foro';
export interface Foro
{
    id: number;
	cidade : number;
	email : string;
	nome : string;
	unico : boolean;
	site : string;
	endereco : string;
	bairro : string;
	fone : string;
	fax : string;
	cep : string;
	obs : string;
	unicoconfirmado : boolean;
	web : string;
	etiqueta : boolean;
	bold : boolean;
	nomecidade?: string;

}


export function ForoEmpty(): IForo {
// 20250604
    
    return {
        id: 0,
		cidade: 0,
		email: '',
		nome: '',
		unico: false,
		site: '',
		endereco: '',
		bairro: '',
		fone: '',
		fax: '',
		cep: '',
		obs: '',
		unicoconfirmado: false,
		web: '',
		etiqueta: false,
		bold: false,
    };
}

export function ForoTestEmpty(): IForo {
// 20250604
    
    return {
        id: 1,
		cidade: 1,
		email: 'X',
		nome: 'X',
		unico: true,
		site: 'X',
		endereco: 'X',
		bairro: 'X',
		fone: 'X',
		fax: 'X',
		cep: 'X',
		obs: 'X',
		unicoconfirmado: true,
		web: 'X',
		etiqueta: true,
		bold: true,
    };
}


