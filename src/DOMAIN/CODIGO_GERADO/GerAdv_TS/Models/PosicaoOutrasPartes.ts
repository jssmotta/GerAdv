import { IPosicaoOutrasPartes } from '../PosicaoOutrasPartes/Interfaces/interface.PosicaoOutrasPartes';
export interface PosicaoOutrasPartes
{
    id: number;
	descricao : string;
	bold : boolean;

}


export function PosicaoOutrasPartesEmpty(): IPosicaoOutrasPartes {
// 20250604
    
    return {
        id: 0,
		descricao: '',
		bold: false,
    };
}

export function PosicaoOutrasPartesTestEmpty(): IPosicaoOutrasPartes {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
		bold: true,
    };
}


