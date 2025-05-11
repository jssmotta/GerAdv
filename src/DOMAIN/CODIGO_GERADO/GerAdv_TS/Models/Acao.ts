import { Auditor } from "./Auditor";

import { IAcao } from "../Acao/Interfaces/interface.Acao";
export interface Acao
{
    id: number;
	justica : number;
	area : number;
	descricao : string;
	auditor?: Auditor | null;
}

export function AcaoEmpty(): IAcao {
// 20250125
    return {
        id: 0,
		justica: 0,
		area: 0,
		descricao: '',
		auditor: null
    };
}
