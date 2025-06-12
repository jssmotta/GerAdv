import { IPontoVirtualAcessos } from '../PontoVirtualAcessos/Interfaces/interface.PontoVirtualAcessos';
export interface PontoVirtualAcessos
{
    id: number;
	operador : number;
	datahora : string;
	tipo : boolean;
	origem : string;
	nomeoperador?: string;

}


export function PontoVirtualAcessosEmpty(): IPontoVirtualAcessos {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		datahora: '',
		tipo: false,
		origem: '',
    };
}

export function PontoVirtualAcessosTestEmpty(): IPontoVirtualAcessos {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		datahora: 'X',
		tipo: true,
		origem: 'X',
    };
}


