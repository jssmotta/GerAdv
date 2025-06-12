import { IAgenda2Agenda } from '../Agenda2Agenda/Interfaces/interface.Agenda2Agenda';
export interface Agenda2Agenda
{
    id: number;
	agenda : number;
	master : number;

}


export function Agenda2AgendaEmpty(): IAgenda2Agenda {
// 20250604
    
    return {
        id: 0,
		agenda: 0,
		master: 0,
    };
}

export function Agenda2AgendaTestEmpty(): IAgenda2Agenda {
// 20250604
    
    return {
        id: 1,
		agenda: 1,
		master: 1,
    };
}


