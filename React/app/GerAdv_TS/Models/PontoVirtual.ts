import { IPontoVirtual } from '../PontoVirtual/Interfaces/interface.PontoVirtual';
export interface PontoVirtual
{
    id: number;
	operador : number;
	horaentrada : string;
	horasaida : string;
	key : string;
	nomeoperador?: string;

}


export function PontoVirtualEmpty(): IPontoVirtual {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		horaentrada: '',
		horasaida: '',
		key: '',
    };
}

export function PontoVirtualTestEmpty(): IPontoVirtual {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		horaentrada: 'X',
		horasaida: 'X',
		key: 'X',
    };
}


