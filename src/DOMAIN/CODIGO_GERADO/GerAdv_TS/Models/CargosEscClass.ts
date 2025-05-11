import { Auditor } from "./Auditor";

import { ICargosEscClass } from "../CargosEscClass/Interfaces/interface.CargosEscClass";
export interface CargosEscClass
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function CargosEscClassEmpty(): ICargosEscClass {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
