import { Auditor } from "./Auditor";

import { IGUTTipo } from "../GUTTipo/Interfaces/interface.GUTTipo";
export interface GUTTipo
{
    id: number;
	nome : string;
	ordem : number;
	auditor?: Auditor | null;
}

export function GUTTipoEmpty(): IGUTTipo {
// 20250125
    return {
        id: 0,
		nome: '',
		ordem: 0,
		auditor: null
    };
}
