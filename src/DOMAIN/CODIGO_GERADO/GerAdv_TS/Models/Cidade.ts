import { ICidade } from '../Cidade/Interfaces/interface.Cidade';
export interface Cidade
{
    id: number;
	uf : number;
	ddd : string;
	top : boolean;
	comarca : boolean;
	capital : boolean;
	nome : string;
	sigla : string;
	iduf?: string;

}


export function CidadeEmpty(): ICidade {
// 20250604
    
    return {
        id: 0,
		uf: 0,
		ddd: '',
		top: false,
		comarca: false,
		capital: false,
		nome: '',
		sigla: '',
    };
}

export function CidadeTestEmpty(): ICidade {
// 20250604
    
    return {
        id: 1,
		uf: 1,
		ddd: 'X',
		top: true,
		comarca: true,
		capital: true,
		nome: 'X',
		sigla: 'X',
    };
}


