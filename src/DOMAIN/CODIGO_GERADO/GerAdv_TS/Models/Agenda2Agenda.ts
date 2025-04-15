import { Auditor } from "./Auditor";

import { IAgenda2Agenda } from "../Agenda2Agenda/Interfaces/interface.Agenda2Agenda";
export interface Agenda2Agenda
{
    id: number;
	agenda : number;
	master : number;
	auditor?: Auditor | null;
}

export function Agenda2AgendaEmpty(): IAgenda2Agenda {
// 20250125
    return {
        id: 0,
		agenda: 0,
		master: 0,
		auditor: null
    };
}
