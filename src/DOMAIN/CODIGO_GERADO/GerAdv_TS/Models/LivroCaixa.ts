import { Auditor } from "./Auditor";

import { ILivroCaixa } from "../LivroCaixa/Interfaces/interface.LivroCaixa";
export interface LivroCaixa
{
    id: number;
	processo : number;
	iddes : number;
	pessoal : number;
	ajuste : boolean;
	idhon : number;
	idhonparc : number;
	idhonsuc : boolean;
	data : string;
	valor : number;
	tipo : boolean;
	historico : string;
	grupo : number;
	auditor?: Auditor | null;
}

export function LivroCaixaEmpty(): ILivroCaixa {
// 20250125
    return {
        id: 0,
		processo: 0,
		iddes: 0,
		pessoal: 0,
		ajuste: false,
		idhon: 0,
		idhonparc: 0,
		idhonsuc: false,
		data: '',
		valor: 0,
		tipo: false,
		historico: '',
		grupo: 0,
		auditor: null
    };
}
