import { IEnderecos } from '../Enderecos/Interfaces/interface.Enderecos';
export interface Enderecos
{
    id: number;
	cidade : number;
	topindex : boolean;
	descricao : string;
	contato : string;
	dtnasc : string;
	endereco : string;
	bairro : string;
	privativo : boolean;
	addcontato : boolean;
	cep : string;
	oab : string;
	obs : string;
	fone : string;
	fax : string;
	tratamento : string;
	site : string;
	email : string;
	quem : number;
	quemindicou : string;
	reportecbonly : boolean;
	etiqueta : boolean;
	ani : boolean;
	bold : boolean;
	nomecidade?: string;

}


export function EnderecosEmpty(): IEnderecos {
// 20250604
    
    return {
        id: 0,
		cidade: 0,
		topindex: false,
		descricao: '',
		contato: '',
		dtnasc: '',
		endereco: '',
		bairro: '',
		privativo: false,
		addcontato: false,
		cep: '',
		oab: '',
		obs: '',
		fone: '',
		fax: '',
		tratamento: '',
		site: '',
		email: '',
		quem: 0,
		quemindicou: '',
		reportecbonly: false,
		etiqueta: false,
		ani: false,
		bold: false,
    };
}

export function EnderecosTestEmpty(): IEnderecos {
// 20250604
    
    return {
        id: 1,
		cidade: 1,
		topindex: true,
		descricao: 'X',
		contato: 'X',
		dtnasc: 'X',
		endereco: 'X',
		bairro: 'X',
		privativo: true,
		addcontato: true,
		cep: 'X',
		oab: 'X',
		obs: 'X',
		fone: 'X',
		fax: 'X',
		tratamento: 'X',
		site: 'X',
		email: 'X',
		quem: 1,
		quemindicou: 'X',
		reportecbonly: true,
		etiqueta: true,
		ani: true,
		bold: true,
    };
}


