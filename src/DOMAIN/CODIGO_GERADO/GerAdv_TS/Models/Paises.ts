import { Auditor } from "./Auditor";

import { IPaises } from "../Paises/Interfaces/interface.Paises";
export interface Paises
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function PaisesEmpty(): IPaises {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
