import { Auditor } from "./Auditor";

import { ICargos } from "../Cargos/Interfaces/interface.Cargos";
export interface Cargos
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function CargosEmpty(): ICargos {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
