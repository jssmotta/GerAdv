import { IOperadorGruposAgenda } from '../OperadorGruposAgenda/Interfaces/interface.OperadorGruposAgenda';
export interface OperadorGruposAgenda
{
    id: number;
	operador : number;
	sqlwhere : string;
	nome : string;
	nomeoperador?: string;

}


export function OperadorGruposAgendaEmpty(): IOperadorGruposAgenda {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		sqlwhere: '',
		nome: '',
    };
}

export function OperadorGruposAgendaTestEmpty(): IOperadorGruposAgenda {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		sqlwhere: 'X',
		nome: 'X',
    };
}


