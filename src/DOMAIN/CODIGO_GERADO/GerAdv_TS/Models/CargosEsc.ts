import { Auditor } from "./Auditor";

import { ICargosEsc } from "../CargosEsc/Interfaces/interface.CargosEsc";
export interface CargosEsc
{
    id: number;
	percentual : number;
	nome : string;
	classificacao : number;
	auditor?: Auditor | null;
}

export function CargosEscEmpty(): ICargosEsc {
// 20250125
    return {
        id: 0,
		percentual: 0,
		nome: '',
		classificacao: 0,
		auditor: null
    };
}
