import { IGUTMatriz } from "../GUTMatriz/Interfaces/interface.GUTMatriz";
export interface GUTMatriz
{
    id: number;
	guttipo : number;
	descricao : string;
	valor : number;
}

export function GUTMatrizEmpty(): IGUTMatriz {
// 20250125
    return {
        id: 0,
		guttipo: 0,
		descricao: '',
		valor: 0,
    };
}
