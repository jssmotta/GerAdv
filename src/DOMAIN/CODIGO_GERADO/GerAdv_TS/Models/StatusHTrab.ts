import { IStatusHTrab } from "../StatusHTrab/Interfaces/interface.StatusHTrab";
export interface StatusHTrab
{
    id: number;
	descricao : string;
	resid : number;
}

export function StatusHTrabEmpty(): IStatusHTrab {
// 20250125
    return {
        id: 0,
		descricao: '',
		resid: 0,
    };
}
