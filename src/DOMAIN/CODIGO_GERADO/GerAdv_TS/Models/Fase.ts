import { IFase } from '../Fase/Interfaces/interface.Fase';
export interface Fase
{
    id: number;
	justica : number;
	area : number;
	descricao : string;
	nomejustica?: string;
	descricaoarea?: string;

}


export function FaseEmpty(): IFase {
// 20250604
    
    return {
        id: 0,
		justica: 0,
		area: 0,
		descricao: '',
    };
}

export function FaseTestEmpty(): IFase {
// 20250604
    
    return {
        id: 1,
		justica: 1,
		area: 1,
		descricao: 'X',
    };
}


