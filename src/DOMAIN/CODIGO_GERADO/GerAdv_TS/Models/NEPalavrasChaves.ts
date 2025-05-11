import { Auditor } from "./Auditor";

import { INEPalavrasChaves } from "../NEPalavrasChaves/Interfaces/interface.NEPalavrasChaves";
export interface NEPalavrasChaves
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function NEPalavrasChavesEmpty(): INEPalavrasChaves {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
