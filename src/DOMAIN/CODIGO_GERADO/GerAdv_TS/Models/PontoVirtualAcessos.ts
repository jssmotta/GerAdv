import { IPontoVirtualAcessos } from "../PontoVirtualAcessos/Interfaces/interface.PontoVirtualAcessos";
export interface PontoVirtualAcessos
{
    id: number;
	operador : number;
	datahora : string;
	tipo : boolean;
	origem : string;
}

export function PontoVirtualAcessosEmpty(): IPontoVirtualAcessos {
// 20250125
    return {
        id: 0,
		operador: 0,
		datahora: '',
		tipo: false,
		origem: '',
    };
}
