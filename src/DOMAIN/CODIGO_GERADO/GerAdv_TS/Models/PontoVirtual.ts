import { IPontoVirtual } from "../PontoVirtual/Interfaces/interface.PontoVirtual";
export interface PontoVirtual
{
    id: number;
	operador : number;
	horaentrada : string;
	horasaida : string;
	key : string;
}

export function PontoVirtualEmpty(): IPontoVirtual {
// 20250125
    return {
        id: 0,
		operador: 0,
		horaentrada: '',
		horasaida: '',
		key: '',
    };
}
