import { Auditor } from "./Auditor";

import { IGraph } from "../Graph/Interfaces/interface.Graph";
export interface Graph
{
    id: number;
	tabela : string;
	tabelaid : number;
	imagem : Uint8Array;
	auditor?: Auditor | null;
}

export function GraphEmpty(): IGraph {
// 20250125
    return {
        id: 0,
		tabela: '',
		tabelaid: 0,
		imagem: new Uint8Array(),
		auditor: null
    };
}
