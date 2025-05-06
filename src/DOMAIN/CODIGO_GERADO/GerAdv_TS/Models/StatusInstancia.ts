import { Auditor } from "./Auditor";

import { IStatusInstancia } from "../StatusInstancia/Interfaces/interface.StatusInstancia";
export interface StatusInstancia
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function StatusInstanciaEmpty(): IStatusInstancia {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
