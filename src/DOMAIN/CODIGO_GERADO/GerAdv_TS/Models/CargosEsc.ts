import { ICargosEsc } from '../CargosEsc/Interfaces/interface.CargosEsc';
export interface CargosEsc
{
    id: number;
	percentual : number;
	nome : string;
	classificacao : number;

}


export function CargosEscEmpty(): ICargosEsc {
// 20250604
    
    return {
        id: 0,
		percentual: 0,
		nome: '',
		classificacao: 0,
    };
}

export function CargosEscTestEmpty(): ICargosEsc {
// 20250604
    
    return {
        id: 1,
		percentual: 1,
		nome: 'X',
		classificacao: 1,
    };
}


