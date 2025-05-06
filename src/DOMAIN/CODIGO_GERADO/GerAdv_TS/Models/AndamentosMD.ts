import { Auditor } from "./Auditor";

import { IAndamentosMD } from "../AndamentosMD/Interfaces/interface.AndamentosMD";
export interface AndamentosMD
{
    id: number;
	processo : number;
	nome : string;
	andamento : number;
	pathfull : string;
	unc : string;
	auditor?: Auditor | null;
}

export function AndamentosMDEmpty(): IAndamentosMD {
// 20250125
    return {
        id: 0,
		processo: 0,
		nome: '',
		andamento: 0,
		pathfull: '',
		unc: '',
		auditor: null
    };
}
