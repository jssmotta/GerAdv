import { Auditor } from "./Auditor";

import { IAgendaRepetir } from "../AgendaRepetir/Interfaces/interface.AgendaRepetir";
export interface AgendaRepetir
{
    id: number;
	advogado : number;
	cliente : number;
	funcionario : number;
	processo : number;
	datafinal : string;
	horafinal : string;
	pessoal : boolean;
	frequencia : number;
	dia : number;
	mes : number;
	hora : string;
	idquem : number;
	idquem2 : number;
	mensagem : string;
	idtipo : number;
	id1 : number;
	id2 : number;
	id3 : number;
	id4 : number;
	segunda : boolean;
	quarta : boolean;
	quinta : boolean;
	sexta : boolean;
	sabado : boolean;
	domingo : boolean;
	terca : boolean;
	auditor?: Auditor | null;
}

export function AgendaRepetirEmpty(): IAgendaRepetir {
// 20250125
    return {
        id: 0,
		advogado: 0,
		cliente: 0,
		funcionario: 0,
		processo: 0,
		datafinal: '',
		horafinal: '',
		pessoal: false,
		frequencia: 0,
		dia: 0,
		mes: 0,
		hora: '',
		idquem: 0,
		idquem2: 0,
		mensagem: '',
		idtipo: 0,
		id1: 0,
		id2: 0,
		id3: 0,
		id4: 0,
		segunda: false,
		quarta: false,
		quinta: false,
		sexta: false,
		sabado: false,
		domingo: false,
		terca: false,
		auditor: null
    };
}
