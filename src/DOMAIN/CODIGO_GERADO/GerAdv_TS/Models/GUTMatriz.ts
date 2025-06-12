import { IGUTMatriz } from '../GUTMatriz/Interfaces/interface.GUTMatriz';
export interface GUTMatriz
{
    id: number;
	guttipo : number;
	descricao : string;
	valor : number;
	nomeguttipo?: string;

}


export function GUTMatrizEmpty(): IGUTMatriz {
// 20250604
    
    return {
        id: 0,
		guttipo: 0,
		descricao: '',
		valor: 0,
    };
}

export function GUTMatrizTestEmpty(): IGUTMatriz {
// 20250604
    
    return {
        id: 1,
		guttipo: 1,
		descricao: 'X',
		valor: 1,
    };
}


