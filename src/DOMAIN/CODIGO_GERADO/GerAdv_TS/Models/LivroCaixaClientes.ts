import { Auditor } from "./Auditor";

import { ILivroCaixaClientes } from "../LivroCaixaClientes/Interfaces/interface.LivroCaixaClientes";
export interface LivroCaixaClientes
{
    id: number;
	livrocaixa : number;
	cliente : number;
	lancado : boolean;
	auditor?: Auditor | null;
}

export function LivroCaixaClientesEmpty(): ILivroCaixaClientes {
// 20250125
    return {
        id: 0,
		livrocaixa: 0,
		cliente: 0,
		lancado: false,
		auditor: null
    };
}
