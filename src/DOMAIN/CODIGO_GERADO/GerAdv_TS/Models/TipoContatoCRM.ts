import { Auditor } from "./Auditor";

import { ITipoContatoCRM } from "../TipoContatoCRM/Interfaces/interface.TipoContatoCRM";
export interface TipoContatoCRM
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function TipoContatoCRMEmpty(): ITipoContatoCRM {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
