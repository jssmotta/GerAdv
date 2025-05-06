import { Auditor } from "./Auditor";

import { IProDespesas } from "../ProDespesas/Interfaces/interface.ProDespesas";
export interface ProDespesas
{
    id: number;
	cliente : number;
	processo : number;
	ligacaoid : number;
	corrigido : boolean;
	data : string;
	valororiginal : number;
	quitado : number;
	datacorrecao : string;
	valor : number;
	tipo : boolean;
	historico : string;
	livrocaixa : boolean;
	auditor?: Auditor | null;
}

export function ProDespesasEmpty(): IProDespesas {
// 20250125
    return {
        id: 0,
		cliente: 0,
		processo: 0,
		ligacaoid: 0,
		corrigido: false,
		data: '',
		valororiginal: 0,
		quitado: 0,
		datacorrecao: '',
		valor: 0,
		tipo: false,
		historico: '',
		livrocaixa: false,
		auditor: null
    };
}
