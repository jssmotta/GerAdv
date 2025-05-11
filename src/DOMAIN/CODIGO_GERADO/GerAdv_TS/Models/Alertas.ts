import { Auditor } from "./Auditor";

import { IAlertas } from "../Alertas/Interfaces/interface.Alertas";
export interface Alertas
{
    id: number;
	operador : number;
	nome : string;
	data : string;
	dataate : string;
	auditor?: Auditor | null;
}

export function AlertasEmpty(): IAlertas {
// 20250125
    return {
        id: 0,
		operador: 0,
		nome: '',
		data: '',
		dataate: '',
		auditor: null
    };
}
