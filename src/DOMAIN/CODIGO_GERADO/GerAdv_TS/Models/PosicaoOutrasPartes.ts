import { Auditor } from "./Auditor";

import { IPosicaoOutrasPartes } from "../PosicaoOutrasPartes/Interfaces/interface.PosicaoOutrasPartes";
export interface PosicaoOutrasPartes
{
    id: number;
	descricao : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function PosicaoOutrasPartesEmpty(): IPosicaoOutrasPartes {
// 20250125
    return {
        id: 0,
		descricao: '',
		bold: false,
		auditor: null
    };
}
