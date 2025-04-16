import { IAgendaQuem } from "../AgendaQuem/Interfaces/interface.AgendaQuem";
export interface AgendaQuem
{
    id: number;
	advogado : number;
	funcionario : number;
	preposto : number;
	idagenda : number;
}

export function AgendaQuemEmpty(): IAgendaQuem {
// 20250125
    return {
        id: 0,
		advogado: 0,
		funcionario: 0,
		preposto: 0,
		idagenda: 0,
    };
}
