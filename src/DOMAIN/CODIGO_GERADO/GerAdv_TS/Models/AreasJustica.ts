import { IAreasJustica } from "../AreasJustica/Interfaces/interface.AreasJustica";
export interface AreasJustica
{
    id: number;
	area : number;
	justica : number;
}

export function AreasJusticaEmpty(): IAreasJustica {
// 20250125
    return {
        id: 0,
		area: 0,
		justica: 0,
    };
}
