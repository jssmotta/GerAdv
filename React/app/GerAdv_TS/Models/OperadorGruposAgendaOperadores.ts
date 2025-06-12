import { IOperadorGruposAgendaOperadores } from '../OperadorGruposAgendaOperadores/Interfaces/interface.OperadorGruposAgendaOperadores';
export interface OperadorGruposAgendaOperadores
{
    id: number;
	operadorgruposagenda : number;
	operador : number;
	nomeoperadorgruposagenda?: string;
	nomeoperador?: string;

}


export function OperadorGruposAgendaOperadoresEmpty(): IOperadorGruposAgendaOperadores {
// 20250604
    
    return {
        id: 0,
		operadorgruposagenda: 0,
		operador: 0,
    };
}

export function OperadorGruposAgendaOperadoresTestEmpty(): IOperadorGruposAgendaOperadores {
// 20250604
    
    return {
        id: 1,
		operadorgruposagenda: 1,
		operador: 1,
    };
}


