import { Auditor } from "./Auditor";

import { IParteClienteOutras } from "../ParteClienteOutras/Interfaces/interface.ParteClienteOutras";
export interface ParteClienteOutras
{
    id: number;
	cliente : number;
	processo : number;
	primeirareclamada : boolean;
	auditor?: Auditor | null;
}

export function ParteClienteOutrasEmpty(): IParteClienteOutras {
// 20250125
    return {
        id: 0,
		cliente: 0,
		processo: 0,
		primeirareclamada: false,
		auditor: null
    };
}
