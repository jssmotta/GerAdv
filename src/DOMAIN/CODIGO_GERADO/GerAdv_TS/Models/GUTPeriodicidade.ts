import { Auditor } from "./Auditor";

import { IGUTPeriodicidade } from "../GUTPeriodicidade/Interfaces/interface.GUTPeriodicidade";
export interface GUTPeriodicidade
{
    id: number;
	nome : string;
	intervalodias : number;
	auditor?: Auditor | null;
}

export function GUTPeriodicidadeEmpty(): IGUTPeriodicidade {
// 20250125
    return {
        id: 0,
		nome: '',
		intervalodias: 0,
		auditor: null
    };
}
