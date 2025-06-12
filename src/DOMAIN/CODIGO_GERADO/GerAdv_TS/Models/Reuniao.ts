import { IReuniao } from '../Reuniao/Interfaces/interface.Reuniao';
export interface Reuniao
{
    id: number;
	cliente : number;
	idagenda : number;
	data : string;
	pauta : string;
	ata : string;
	horainicial : string;
	horafinal : string;
	externa : boolean;
	horasaida : string;
	horaretorno : string;
	principaisdecisoes : string;
	bold : boolean;
	nomeclientes?: string;

}


export function ReuniaoEmpty(): IReuniao {
// 20250604
    
    return {
        id: 0,
		cliente: 0,
		idagenda: 0,
		data: '',
		pauta: '',
		ata: '',
		horainicial: '',
		horafinal: '',
		externa: false,
		horasaida: '',
		horaretorno: '',
		principaisdecisoes: '',
		bold: false,
    };
}

export function ReuniaoTestEmpty(): IReuniao {
// 20250604
    
    return {
        id: 1,
		cliente: 1,
		idagenda: 1,
		data: 'X',
		pauta: 'X',
		ata: 'X',
		horainicial: 'X',
		horafinal: 'X',
		externa: true,
		horasaida: 'X',
		horaretorno: 'X',
		principaisdecisoes: 'X',
		bold: true,
    };
}


