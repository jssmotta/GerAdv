import { IAcao } from '../Acao/Interfaces/interface.Acao';
export interface Acao
{
    id: number;
	justica : number;
	area : number;
	descricao : string;
	nomejustica?: string;
	descricaoarea?: string;

}


export function AcaoEmpty(): IAcao {
// 20250604
    
    return {
        id: 0,
		justica: 0,
		area: 0,
		descricao: '',
    };
}

export function AcaoTestEmpty(): IAcao {
// 20250604
    
    return {
        id: 1,
		justica: 1,
		area: 1,
		descricao: 'X',
    };
}


