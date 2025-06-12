import { IObjetos } from '../Objetos/Interfaces/interface.Objetos';
export interface Objetos
{
    id: number;
	justica : number;
	area : number;
	nome : string;
	bold : boolean;
	nomejustica?: string;
	descricaoarea?: string;

}


export function ObjetosEmpty(): IObjetos {
// 20250604
    
    return {
        id: 0,
		justica: 0,
		area: 0,
		nome: '',
		bold: false,
    };
}

export function ObjetosTestEmpty(): IObjetos {
// 20250604
    
    return {
        id: 1,
		justica: 1,
		area: 1,
		nome: 'X',
		bold: true,
    };
}


