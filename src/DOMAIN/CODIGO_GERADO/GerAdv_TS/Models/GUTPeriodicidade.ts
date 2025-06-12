import { IGUTPeriodicidade } from '../GUTPeriodicidade/Interfaces/interface.GUTPeriodicidade';
export interface GUTPeriodicidade
{
    id: number;
	nome : string;
	intervalodias : number;

}


export function GUTPeriodicidadeEmpty(): IGUTPeriodicidade {
// 20250604
    
    return {
        id: 0,
		nome: '',
		intervalodias: 0,
    };
}

export function GUTPeriodicidadeTestEmpty(): IGUTPeriodicidade {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		intervalodias: 1,
    };
}


