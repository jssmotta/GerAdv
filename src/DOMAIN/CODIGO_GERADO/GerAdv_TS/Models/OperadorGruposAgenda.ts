import { Auditor } from "./Auditor";

import { IOperadorGruposAgenda } from "../OperadorGruposAgenda/Interfaces/interface.OperadorGruposAgenda";
export interface OperadorGruposAgenda
{
    id: number;
	operador : number;
	sqlwhere : string;
	nome : string;
	auditor?: Auditor | null;
}

export function OperadorGruposAgendaEmpty(): IOperadorGruposAgenda {
// 20250125
    return {
        id: 0,
		operador: 0,
		sqlwhere: '',
		nome: '',
		auditor: null
    };
}
