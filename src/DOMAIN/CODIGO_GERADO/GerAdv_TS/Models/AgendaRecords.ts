import { IAgendaRecords } from "../AgendaRecords/Interfaces/interface.AgendaRecords";
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
}

export function AgendaRecordsEmpty(): IAgendaRecords {
// 20250125
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
