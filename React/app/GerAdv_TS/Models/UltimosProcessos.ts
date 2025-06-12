import { IUltimosProcessos } from '../UltimosProcessos/Interfaces/interface.UltimosProcessos';
export interface UltimosProcessos
{
    id: number;
	processo : number;
	quando : string;
	quem : number;
	nropastaprocessos?: string;

}


export function UltimosProcessosEmpty(): IUltimosProcessos {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		quando: '',
		quem: 0,
    };
}

export function UltimosProcessosTestEmpty(): IUltimosProcessos {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		quando: 'X',
		quem: 1,
    };
}


