import { IStatusBiu } from '../StatusBiu/Interfaces/interface.StatusBiu';
export interface StatusBiu
{
    id: number;
	tipostatusbiu : number;
	operador : number;
	nome : string;
	icone : number;
	nometipostatusbiu?: string;
	nomeoperador?: string;

}


export function StatusBiuEmpty(): IStatusBiu {
// 20250604
    
    return {
        id: 0,
		tipostatusbiu: 0,
		operador: 0,
		nome: '',
		icone: 0,
    };
}

export function StatusBiuTestEmpty(): IStatusBiu {
// 20250604
    
    return {
        id: 1,
		tipostatusbiu: 1,
		operador: 1,
		nome: 'X',
		icone: 1,
    };
}


