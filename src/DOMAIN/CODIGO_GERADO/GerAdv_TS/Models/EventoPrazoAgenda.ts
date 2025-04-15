import { Auditor } from "./Auditor";

import { IEventoPrazoAgenda } from "../EventoPrazoAgenda/Interfaces/interface.EventoPrazoAgenda";
export interface EventoPrazoAgenda
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function EventoPrazoAgendaEmpty(): IEventoPrazoAgenda {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
