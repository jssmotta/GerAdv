import { IStatusHTrab } from '../StatusHTrab/Interfaces/interface.StatusHTrab';
export interface StatusHTrab
{
    id: number;
	descricao : string;
	resid : number;

}


export function StatusHTrabEmpty(): IStatusHTrab {
// 20250604
    
    return {
        id: 0,
		descricao: '',
		resid: 0,
    };
}

export function StatusHTrabTestEmpty(): IStatusHTrab {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
		resid: 1,
    };
}


