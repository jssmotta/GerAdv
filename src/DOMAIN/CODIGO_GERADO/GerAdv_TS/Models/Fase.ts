import { Auditor } from "./Auditor";

import { IFase } from "../Fase/Interfaces/interface.Fase";
export interface Fase
{
    id: number;
	justica : number;
	area : number;
	descricao : string;
	auditor?: Auditor | null;
}

export function FaseEmpty(): IFase {
// 20250125
    return {
        id: 0,
		justica: 0,
		area: 0,
		descricao: '',
		auditor: null
    };
}
