import { IAgendaSemana } from "../AgendaSemana/Interfaces/interface.AgendaSemana";
export interface AgendaSemana
{
    id: number;
	funcionario : number;
	advogado : number;
	tipocompromisso : number;
	cliente : number;
	paranome : string;
	data : string;
	hora : string;
	compromisso : string;
	concluido : boolean;
	liberado : boolean;
	importante : boolean;
	horafinal : string;
	nome : string;
	nomecliente : string;
	tipo : string;
}

export function AgendaSemanaEmpty(): IAgendaSemana {
// 20250125
    return {
        id: 0,
		funcionario: 0,
		advogado: 0,
		tipocompromisso: 0,
		cliente: 0,
		paranome: '',
		data: '',
		hora: '',
		compromisso: '',
		concluido: false,
		liberado: false,
		importante: false,
		horafinal: '',
		nome: '',
		nomecliente: '',
		tipo: '',
    };
}
