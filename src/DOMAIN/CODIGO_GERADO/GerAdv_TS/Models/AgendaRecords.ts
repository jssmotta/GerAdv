import { IAgendaRecords } from '../AgendaRecords/Interfaces/interface.AgendaRecords';
export interface AgendaRecords
{
    id: number;
	agenda : number;
	clientessocios : number;
	colaborador : number;
	foro : number;
	julgador : number;
	perito : number;
	aviso1 : boolean;
	aviso2 : boolean;
	aviso3 : boolean;
	crmaviso1 : number;
	crmaviso2 : number;
	crmaviso3 : number;
	dataaviso1 : string;
	dataaviso2 : string;
	dataaviso3 : string;
	nomeclientessocios?: string;
	nomecolaboradores?: string;
	nomeforo?: string;

}


export function AgendaRecordsEmpty(): IAgendaRecords {
// 20250604
    
    return {
        id: 0,
		agenda: 0,
		clientessocios: 0,
		colaborador: 0,
		foro: 0,
		julgador: 0,
		perito: 0,
		aviso1: false,
		aviso2: false,
		aviso3: false,
		crmaviso1: 0,
		crmaviso2: 0,
		crmaviso3: 0,
		dataaviso1: '',
		dataaviso2: '',
		dataaviso3: '',
    };
}

export function AgendaRecordsTestEmpty(): IAgendaRecords {
// 20250604
    
    return {
        id: 1,
		agenda: 1,
		clientessocios: 1,
		colaborador: 1,
		foro: 1,
		julgador: 1,
		perito: 1,
		aviso1: true,
		aviso2: true,
		aviso3: true,
		crmaviso1: 1,
		crmaviso2: 1,
		crmaviso3: 1,
		dataaviso1: 'X',
		dataaviso2: 'X',
		dataaviso3: 'X',
    };
}


