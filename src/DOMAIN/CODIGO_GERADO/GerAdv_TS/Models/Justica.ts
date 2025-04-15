import { Auditor } from "./Auditor";

import { IJustica } from "../Justica/Interfaces/interface.Justica";
export interface Justica
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function JusticaEmpty(): IJustica {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
