import { Auditor } from "./Auditor";

import { ISituacao } from "../Situacao/Interfaces/interface.Situacao";
export interface Situacao
{
    id: number;
	parte_int : string;
	parte_opo : string;
	top : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function SituacaoEmpty(): ISituacao {
// 20250125
    return {
        id: 0,
		parte_int: '',
		parte_opo: '',
		top: false,
		bold: false,
		auditor: null
    };
}
