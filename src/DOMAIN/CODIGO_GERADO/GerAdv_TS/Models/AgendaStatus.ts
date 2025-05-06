import { Auditor } from "./Auditor";

import { IAgendaStatus } from "../AgendaStatus/Interfaces/interface.AgendaStatus";
export interface AgendaStatus
{
    id: number;
	agenda : number;
	completed : number;
	auditor?: Auditor | null;
}

export function AgendaStatusEmpty(): IAgendaStatus {
// 20250125
    return {
        id: 0,
		agenda: 0,
		completed: 0,
		auditor: null
    };
}
