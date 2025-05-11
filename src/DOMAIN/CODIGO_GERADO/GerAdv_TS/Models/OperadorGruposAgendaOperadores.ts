import { Auditor } from "./Auditor";

import { IOperadorGruposAgendaOperadores } from "../OperadorGruposAgendaOperadores/Interfaces/interface.OperadorGruposAgendaOperadores";
export interface OperadorGruposAgendaOperadores
{
    id: number;
	operadorgruposagenda : number;
	operador : number;
	auditor?: Auditor | null;
}

export function OperadorGruposAgendaOperadoresEmpty(): IOperadorGruposAgendaOperadores {
// 20250125
    return {
        id: 0,
		operadorgruposagenda: 0,
		operador: 0,
		auditor: null
    };
}
