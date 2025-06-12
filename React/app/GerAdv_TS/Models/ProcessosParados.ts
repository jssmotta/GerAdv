import { IProcessosParados } from '../ProcessosParados/Interfaces/interface.ProcessosParados';
export interface ProcessosParados
{
    id: number;
	processo : number;
	operador : number;
	semana : number;
	ano : number;
	datahora : string;
	datahistorico : string;
	datanenotas : string;
	nropastaprocessos?: string;
	nomeoperador?: string;

}


export function ProcessosParadosEmpty(): IProcessosParados {
// 20250604
    
    return {
        id: 0,
		processo: 0,
		operador: 0,
		semana: 0,
		ano: 0,
		datahora: '',
		datahistorico: '',
		datanenotas: '',
    };
}

export function ProcessosParadosTestEmpty(): IProcessosParados {
// 20250604
    
    return {
        id: 1,
		processo: 1,
		operador: 1,
		semana: 1,
		ano: 1,
		datahora: 'X',
		datahistorico: 'X',
		datanenotas: 'X',
    };
}


