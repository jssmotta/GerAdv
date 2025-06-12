import { IAgendaRelatorio } from '../AgendaRelatorio/Interfaces/interface.AgendaRelatorio';
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
	nropastaprocessos?: string;

}


export function AgendaRelatorioEmpty(): IAgendaRelatorio {
// 20250604
    
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

export function AgendaRelatorioTestEmpty(): IAgendaRelatorio {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		data: 'X',
		paranome: 'X',
		parapessoas: 'X',
		boxaudiencia: 'X',
		boxaudienciamobile: 'X',
		nomeadvogado: 'X',
		nomeforo: 'X',
		nomejustica: 'X',
		nomearea: 'X',
    };
}


