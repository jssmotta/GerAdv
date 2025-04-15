import { Auditor } from "./Auditor";

import { INECompromissos } from "../NECompromissos/Interfaces/interface.NECompromissos";
export interface NECompromissos
{
    id: number;
	tipocompromisso : number;
	palavrachave : number;
	provisionar : boolean;
	textocompromisso : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function NECompromissosEmpty(): INECompromissos {
// 20250125
    return {
        id: 0,
		tipocompromisso: 0,
		palavrachave: 0,
		provisionar: false,
		textocompromisso: '',
		bold: false,
		auditor: null
    };
}
