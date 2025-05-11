import { Auditor } from "./Auditor";

import { IHistorico } from "../Historico/Interfaces/interface.Historico";
export interface Historico
{
    id: number;
	processo : number;
	precatoria : number;
	apenso : number;
	fase : number;
	statusandamento : number;
	extraid : number;
	idne : number;
	extraguid : string;
	liminarorigem : number;
	naopublicavel : boolean;
	idinstprocesso : number;
	data : string;
	observacao : string;
	agendado : boolean;
	concluido : boolean;
	mesmaagenda : boolean;
	sad : number;
	resumido : boolean;
	top : boolean;
	auditor?: Auditor | null;
}

export function HistoricoEmpty(): IHistorico {
// 20250125
    return {
        id: 0,
		processo: 0,
		precatoria: 0,
		apenso: 0,
		fase: 0,
		statusandamento: 0,
		extraid: 0,
		idne: 0,
		extraguid: '',
		liminarorigem: 0,
		naopublicavel: false,
		idinstprocesso: 0,
		data: '',
		observacao: '',
		agendado: false,
		concluido: false,
		mesmaagenda: false,
		sad: 0,
		resumido: false,
		top: false,
		auditor: null
    };
}
