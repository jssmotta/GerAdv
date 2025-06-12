import { ILivroCaixaClientes } from '../LivroCaixaClientes/Interfaces/interface.LivroCaixaClientes';
export interface LivroCaixaClientes
{
    id: number;
	livrocaixa : number;
	cliente : number;
	lancado : boolean;
	nomeclientes?: string;

}


export function LivroCaixaClientesEmpty(): ILivroCaixaClientes {
// 20250604
    
    return {
        id: 0,
		livrocaixa: 0,
		cliente: 0,
		lancado: false,
    };
}

export function LivroCaixaClientesTestEmpty(): ILivroCaixaClientes {
// 20250604
    
    return {
        id: 1,
		livrocaixa: 1,
		cliente: 1,
		lancado: true,
    };
}


