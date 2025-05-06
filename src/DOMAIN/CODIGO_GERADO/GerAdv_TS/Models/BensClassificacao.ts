import { Auditor } from "./Auditor";

import { IBensClassificacao } from "../BensClassificacao/Interfaces/interface.BensClassificacao";
export interface BensClassificacao
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function BensClassificacaoEmpty(): IBensClassificacao {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
