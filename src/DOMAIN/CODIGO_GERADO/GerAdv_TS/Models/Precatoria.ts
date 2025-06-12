import { IPrecatoria } from '../Precatoria/Interfaces/interface.Precatoria';
export interface Precatoria
{
    id: number;
	processo : number;
	dtdist : string;
	precatoriax : string;
	deprecante : string;
	deprecado : string;
	obs : string;
	bold : boolean;
	nropastaprocessos?: string;

}


export function PrecatoriaEmpty(): IPrecatoria {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		dtdist: '',
		precatoriax: '',
		deprecante: '',
		deprecado: '',
		obs: '',
		bold: false,
    };
}

export function PrecatoriaTestEmpty(): IPrecatoria {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		dtdist: 'X',
		precatoriax: 'X',
		deprecante: 'X',
		deprecado: 'X',
		obs: 'X',
		bold: true,
    };
}


