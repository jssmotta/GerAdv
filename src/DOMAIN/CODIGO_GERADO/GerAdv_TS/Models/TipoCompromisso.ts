import { Auditor } from "./Auditor";

import { ITipoCompromisso } from "../TipoCompromisso/Interfaces/interface.TipoCompromisso";
export interface TipoCompromisso
{
    id: number;
	icone : number;
	descricao : string;
	financeiro : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function TipoCompromissoEmpty(): ITipoCompromisso {
// 20250125
    return {
        id: 0,
		icone: 0,
		descricao: '',
		financeiro: false,
		bold: false,
		auditor: null
    };
}
