import { IAgendaRepetirDias } from '../AgendaRepetirDias/Interfaces/interface.AgendaRepetirDias';
export interface AgendaRepetirDias
{
    id: number;
	horafinal : string;
	master : number;
	dia : number;
	hora : string;

}


export function AgendaRepetirDiasEmpty(): IAgendaRepetirDias {
// 20250604
    
    return {
        id: 0,
		horafinal: '',
		master: 0,
		dia: 0,
		hora: '',
    };
}

export function AgendaRepetirDiasTestEmpty(): IAgendaRepetirDias {
// 20250604
    
    return {
        id: 1,
		horafinal: 'X',
		master: 1,
		dia: 1,
		hora: 'X',
    };
}


