import { IParteCliente } from "../ParteCliente/Interfaces/interface.ParteCliente";
export interface ParteCliente
{
    id: number;
	cliente : number;
	processo : number;
}

export function ParteClienteEmpty(): IParteCliente {
// 20250125
    return {
        id: 0,
		cliente: 0,
		processo: 0,
    };
}
