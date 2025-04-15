import { IAgendaRepetirDias } from "../AgendaRepetirDias/Interfaces/interface.AgendaRepetirDias";
export interface AgendaRepetirDias
{
    id: number;
	horafinal : string;
	master : number;
	dia : number;
	hora : string;
}

export function AgendaRepetirDiasEmpty(): IAgendaRepetirDias {
// 20250125
    return {
        id: 0,
		horafinal: '',
		master: 0,
		dia: 0,
		hora: '',
    };
}
