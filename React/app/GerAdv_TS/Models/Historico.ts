import { IHistorico } from '../Historico/Interfaces/interface.Historico';
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
	nropastaprocessos?: string;
	descricaofase?: string;
	nomestatusandamento?: string;

}


export function HistoricoEmpty(): IHistorico {
// 20250604
    
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
    };
}

export function HistoricoTestEmpty(): IHistorico {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		precatoria: 1,
		apenso: 1,
		fase: 1,
		statusandamento: 1,
		extraid: 1,
		idne: 1,
		extraguid: 'X',
		liminarorigem: 1,
		naopublicavel: true,
		idinstprocesso: 1,
		data: 'X',
		observacao: 'X',
		agendado: true,
		concluido: true,
		mesmaagenda: true,
		sad: 1,
		resumido: true,
		top: true,
    };
}


