import { IAgendaStatus } from '../AgendaStatus/Interfaces/interface.AgendaStatus';
export interface AgendaStatus
{
    id: number;
	agenda : number;
	completed : number;

}


export function AgendaStatusEmpty(): IAgendaStatus {
// 20250604
    
    return {
        id: 0,
		agenda: 0,
		completed: 0,
    };
}

export function AgendaStatusTestEmpty(): IAgendaStatus {
// 20250604
    
    return {
        id: 1,
		agenda: 1,
		completed: 1,
    };
}


