import { Auditor } from "./Auditor";

import { IGUTAtividades } from "../GUTAtividades/Interfaces/interface.GUTAtividades";
export interface GUTAtividades
{
    id: number;
	gutperiodicidade : number;
	operador : number;
	nome : string;
	observacao : string;
	gutgrupo : number;
	concluido : boolean;
	dataconcluido : string;
	diasparainiciar : number;
	minutospararealizar : number;
	auditor?: Auditor | null;
}

export function GUTAtividadesEmpty(): IGUTAtividades {
// 20250125
    return {
        id: 0,
		gutperiodicidade: 0,
		operador: 0,
		nome: '',
		observacao: '',
		gutgrupo: 0,
		concluido: false,
		dataconcluido: '',
		diasparainiciar: 0,
		minutospararealizar: 0,
		auditor: null
    };
}
