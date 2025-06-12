import { IPaises } from '../Paises/Interfaces/interface.Paises';
export interface Paises
{
    id: number;
	nome : string;

}


export function PaisesEmpty(): IPaises {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function PaisesTestEmpty(): IPaises {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


