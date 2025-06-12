import { IEventoPrazoAgenda } from '../EventoPrazoAgenda/Interfaces/interface.EventoPrazoAgenda';
export interface EventoPrazoAgenda
{
    id: number;
	nome : string;
	bold : boolean;

}


export function EventoPrazoAgendaEmpty(): IEventoPrazoAgenda {
// 20250604
    
    return {
        id: 0,
		nome: '',
		bold: false,
    };
}

export function EventoPrazoAgendaTestEmpty(): IEventoPrazoAgenda {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
		bold: true,
    };
}


