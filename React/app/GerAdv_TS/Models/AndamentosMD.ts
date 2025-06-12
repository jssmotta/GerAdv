import { IAndamentosMD } from '../AndamentosMD/Interfaces/interface.AndamentosMD';
export interface AndamentosMD
{
    id: number;
	processo : number;
	nome : string;
	andamento : number;
	pathfull : string;
	unc : string;
	nropastaprocessos?: string;

}


export function AndamentosMDEmpty(): IAndamentosMD {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		nome: '',
		andamento: 0,
		pathfull: '',
		unc: '',
    };
}

export function AndamentosMDTestEmpty(): IAndamentosMD {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		nome: 'X',
		andamento: 1,
		pathfull: 'X',
		unc: 'X',
    };
}


