import { Auditor } from "./Auditor";

import { IPrecatoria } from "../Precatoria/Interfaces/interface.Precatoria";
export interface Precatoria
{
    id: number;
	processo : number;
	dtdist : string;
	precatoriax : string;
	deprecante : string;
	deprecado : string;
	obs : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function PrecatoriaEmpty(): IPrecatoria {
// 20250125
    return {
        id: 0,
		processo: 0,
		dtdist: '',
		precatoriax: '',
		deprecante: '',
		deprecado: '',
		obs: '',
		bold: false,
		auditor: null
    };
}
