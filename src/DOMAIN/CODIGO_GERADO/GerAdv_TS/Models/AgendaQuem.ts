import { IAgendaQuem } from '../AgendaQuem/Interfaces/interface.AgendaQuem';
export interface AgendaQuem
{
    id: number;
	advogado : number;
	funcionario : number;
	preposto : number;
	idagenda : number;
	nomeadvogados?: string;
	nomefuncionarios?: string;
	nomeprepostos?: string;

}


export function AgendaQuemEmpty(): IAgendaQuem {
// 20250604
    
    return {
        id: 0,
		advogado: 0,
		funcionario: 0,
		preposto: 0,
		idagenda: 0,
    };
}

export function AgendaQuemTestEmpty(): IAgendaQuem {
// 20250604
    
    return {
        id: 1,
		advogado: 1,
		funcionario: 1,
		preposto: 1,
		idagenda: 1,
    };
}


