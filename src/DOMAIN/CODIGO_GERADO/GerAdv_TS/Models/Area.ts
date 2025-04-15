import { Auditor } from "./Auditor";

import { IArea } from "../Area/Interfaces/interface.Area";
export interface Area
{
    id: number;
	descricao : string;
	top : boolean;
	auditor?: Auditor | null;
}

export function AreaEmpty(): IArea {
// 20250125
    return {
        id: 0,
		descricao: '',
		top: false,
		auditor: null
    };
}
