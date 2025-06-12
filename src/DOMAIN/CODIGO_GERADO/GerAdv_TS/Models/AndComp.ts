import { IAndComp } from '../AndComp/Interfaces/interface.AndComp';
export interface AndComp
{
    id: number;
	andamento : number;
	compromisso : number;

}


export function AndCompEmpty(): IAndComp {
// 20250604
    
    return {
        id: 0,
		andamento: 0,
		compromisso: 0,
    };
}

export function AndCompTestEmpty(): IAndComp {
// 20250604
    
    return {
        id: 1,
		andamento: 1,
		compromisso: 1,
    };
}


