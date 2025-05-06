import { Auditor } from "./Auditor";

import { IRito } from "../Rito/Interfaces/interface.Rito";
export interface Rito
{
    id: number;
	descricao : string;
	top : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function RitoEmpty(): IRito {
// 20250125
    return {
        id: 0,
		descricao: '',
		top: false,
		bold: false,
		auditor: null
    };
}
