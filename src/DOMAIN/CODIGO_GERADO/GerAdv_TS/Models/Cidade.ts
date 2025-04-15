import { Auditor } from "./Auditor";

import { ICidade } from "../Cidade/Interfaces/interface.Cidade";
export interface Cidade
{
    id: number;
	uf : number;
	ddd : string;
	top : boolean;
	comarca : boolean;
	capital : boolean;
	nome : string;
	sigla : string;
	auditor?: Auditor | null;
}

export function CidadeEmpty(): ICidade {
// 20250125
    return {
        id: 0,
		uf: 0,
		ddd: '',
		top: false,
		comarca: false,
		capital: false,
		nome: '',
		sigla: '',
		auditor: null
    };
}
