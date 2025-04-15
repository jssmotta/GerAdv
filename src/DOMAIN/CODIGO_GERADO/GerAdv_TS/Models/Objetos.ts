import { Auditor } from "./Auditor";

import { IObjetos } from "../Objetos/Interfaces/interface.Objetos";
export interface Objetos
{
    id: number;
	justica : number;
	area : number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ObjetosEmpty(): IObjetos {
// 20250125
    return {
        id: 0,
		justica: 0,
		area: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
