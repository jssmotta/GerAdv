import { IAreasJustica } from '../AreasJustica/Interfaces/interface.AreasJustica';
export interface AreasJustica
{
    id: number;
	area : number;
	justica : number;
	descricaoarea?: string;
	nomejustica?: string;

}


export function AreasJusticaEmpty(): IAreasJustica {
// 20250604
    
    return {
        id: 0,
		area: 0,
		justica: 0,
    };
}

export function AreasJusticaTestEmpty(): IAreasJustica {
// 20250604
    
    return {
        id: 1,
		area: 1,
		justica: 1,
    };
}


