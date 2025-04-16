import { Auditor } from "./Auditor";

import { IReuniao } from "../Reuniao/Interfaces/interface.Reuniao";
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
	auditor?: Auditor | null;
}

export function ReuniaoEmpty(): IReuniao {
// 20250125
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
		auditor: null
    };
}
