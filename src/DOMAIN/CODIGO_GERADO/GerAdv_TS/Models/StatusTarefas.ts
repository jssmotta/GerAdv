import { Auditor } from "./Auditor";

import { IStatusTarefas } from "../StatusTarefas/Interfaces/interface.StatusTarefas";
export interface StatusTarefas
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function StatusTarefasEmpty(): IStatusTarefas {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
