import { Auditor } from "./Auditor";

import { IOperadorGrupos } from "../OperadorGrupos/Interfaces/interface.OperadorGrupos";
export interface OperadorGrupos
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function OperadorGruposEmpty(): IOperadorGrupos {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
