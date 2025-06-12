import { IEndTit } from '../EndTit/Interfaces/interface.EndTit';
export interface EndTit
{
    id: number;
	endereco : number;
	titulo : number;

}


export function EndTitEmpty(): IEndTit {
// 20250604
    
    return {
        id: 0,
		endereco: 0,
		titulo: 0,
    };
}

export function EndTitTestEmpty(): IEndTit {
// 20250604
    
    return {
        id: 1,
		endereco: 1,
		titulo: 1,
    };
}


