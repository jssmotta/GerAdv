import { IAgendaRelatorio } from "../AgendaRelatorio/Interfaces/interface.AgendaRelatorio";
export interface AgendaRelatorio
{
    id: number;
	processo : number;
	data : string;
	paranome : string;
	parapessoas : string;
	boxaudiencia : string;
	boxaudienciamobile : string;
	nomeadvogado : string;
	nomeforo : string;
	nomejustica : string;
	nomearea : string;
}

export function AgendaRelatorioEmpty(): IAgendaRelatorio {
// 20250125
    return {
        id: 0,
		processo: 0,
		data: '',
		paranome: '',
		parapessoas: '',
		boxaudiencia: '',
		boxaudienciamobile: '',
		nomeadvogado: '',
		nomeforo: '',
		nomejustica: '',
		nomearea: '',
    };
}
