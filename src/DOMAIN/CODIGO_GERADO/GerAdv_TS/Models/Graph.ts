import { IGraph } from '../Graph/Interfaces/interface.Graph';
export interface Graph
{
    id: number;
	tabela : string;
	tabelaid : number;
	imagem : Uint8Array;

}


export function GraphEmpty(): IGraph {
// 20250604
    
    return {
        id: 0,
		tabela: '',
		tabelaid: 0,
		imagem: new Uint8Array(),
    };
}

export function GraphTestEmpty(): IGraph {
// 20250604
    
    return {
        id: 1,
		tabela: 'X',
		tabelaid: 1,
		imagem: new Uint8Array(),
    };
}


