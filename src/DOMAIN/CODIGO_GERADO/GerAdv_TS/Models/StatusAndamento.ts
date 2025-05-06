import { Auditor } from "./Auditor";

import { IStatusAndamento } from "../StatusAndamento/Interfaces/interface.StatusAndamento";
export interface StatusAndamento
{
    id: number;
	nome : string;
	icone : number;
	bold : boolean;
	auditor?: Auditor | null;
}

export function StatusAndamentoEmpty(): IStatusAndamento {
// 20250125
    return {
        id: 0,
		nome: '',
		icone: 0,
		bold: false,
		auditor: null
    };
}
