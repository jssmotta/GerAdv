import { Auditor } from "./Auditor";

import { IProTipoBaixa } from "../ProTipoBaixa/Interfaces/interface.ProTipoBaixa";
export interface ProTipoBaixa
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ProTipoBaixaEmpty(): IProTipoBaixa {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
