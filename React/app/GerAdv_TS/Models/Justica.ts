import { IJustica } from '../Justica/Interfaces/interface.Justica';
export interface Justica
{
    id: number;
	nome : string;
	bold : boolean;

}


export function JusticaEmpty(): IJustica {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function JusticaTestEmpty(): IJustica {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


