import { IAlertas } from '../Alertas/Interfaces/interface.Alertas';
export interface Alertas
{
    id: number;
	operador : number;
	nome : string;
	data : string;
	dataate : string;
	nomeoperador?: string;

}


export function AlertasEmpty(): IAlertas {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		nome: '',
		data: '',
		dataate: '',
    };
}

export function AlertasTestEmpty(): IAlertas {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		nome: 'X',
		data: 'X',
		dataate: 'X',
    };
}


