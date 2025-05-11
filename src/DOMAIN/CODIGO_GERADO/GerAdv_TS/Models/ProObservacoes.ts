import { Auditor } from "./Auditor";

import { IProObservacoes } from "../ProObservacoes/Interfaces/interface.ProObservacoes";
export interface ProObservacoes
{
    id: number;
	processo : number;
	nome : string;
	observacoes : string;
	data : string;
	auditor?: Auditor | null;
}

export function ProObservacoesEmpty(): IProObservacoes {
// 20250125
    return {
        id: 0,
		processo: 0,
		nome: '',
		observacoes: '',
		data: '',
		auditor: null
    };
}
