import { IRito } from '../Rito/Interfaces/interface.Rito';
export interface Rito
{
    id: number;
	descricao : string;
	top : boolean;
	bold : boolean;

}


export function RitoEmpty(): IRito {
// 20250604
    
    return {
        id: 0,
		descricao: '',
		top: false,
		bold: false,
    };
}

export function RitoTestEmpty(): IRito {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
		top: true,
		bold: true,
    };
}


