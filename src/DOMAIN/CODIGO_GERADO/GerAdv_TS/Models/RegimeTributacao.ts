import { Auditor } from "./Auditor";

import { IRegimeTributacao } from "../RegimeTributacao/Interfaces/interface.RegimeTributacao";
export interface RegimeTributacao
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function RegimeTributacaoEmpty(): IRegimeTributacao {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
