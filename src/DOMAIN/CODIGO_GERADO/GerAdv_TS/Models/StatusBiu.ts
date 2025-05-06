import { IStatusBiu } from "../StatusBiu/Interfaces/interface.StatusBiu";
export interface StatusBiu
{
    id: number;
	tipostatusbiu : number;
	operador : number;
	nome : string;
	icone : number;
}

export function StatusBiuEmpty(): IStatusBiu {
// 20250125
    return {
        id: 0,
		tipostatusbiu: 0,
		operador: 0,
		nome: '',
		icone: 0,
    };
}
