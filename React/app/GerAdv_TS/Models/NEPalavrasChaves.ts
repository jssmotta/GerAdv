import { INEPalavrasChaves } from '../NEPalavrasChaves/Interfaces/interface.NEPalavrasChaves';
export interface NEPalavrasChaves
{
    id: number;
	nome : string;
	bold : boolean;

}


export function NEPalavrasChavesEmpty(): INEPalavrasChaves {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function NEPalavrasChavesTestEmpty(): INEPalavrasChaves {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


