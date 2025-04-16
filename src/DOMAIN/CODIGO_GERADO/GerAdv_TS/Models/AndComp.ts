import { IAndComp } from "../AndComp/Interfaces/interface.AndComp";
export interface AndComp
{
    id: number;
	andamento : number;
	compromisso : number;
}

export function AndCompEmpty(): IAndComp {
// 20250125
    return {
        id: 0,
		andamento: 0,
		compromisso: 0,
    };
}
