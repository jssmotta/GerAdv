import { IEndTit } from "../EndTit/Interfaces/interface.EndTit";
export interface EndTit
{
    id: number;
	endereco : number;
	titulo : number;
}

export function EndTitEmpty(): IEndTit {
// 20250125
    return {
        id: 0,
		endereco: 0,
		titulo: 0,
    };
}
