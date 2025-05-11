import { Auditor } from "./Auditor";

import { ITiposAcao } from "../TiposAcao/Interfaces/interface.TiposAcao";
export interface TiposAcao
{
    id: number;
	nome : string;
	inativo : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function TiposAcaoEmpty(): ITiposAcao {
// 20250125
    return {
        id: 0,
		nome: '',
		inativo: false,
		bold: false,
		auditor: null
    };
}
