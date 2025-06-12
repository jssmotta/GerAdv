import { IArea } from '../Area/Interfaces/interface.Area';
export interface Area
{
    id: number;
	descricao : string;
	top : boolean;

}


export function AreaEmpty(): IArea {
// 20250604
    
    return {
        id: 0,
		descricao: '',
		top: false,
    };
}

export function AreaTestEmpty(): IArea {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
		top: true,
    };
}


