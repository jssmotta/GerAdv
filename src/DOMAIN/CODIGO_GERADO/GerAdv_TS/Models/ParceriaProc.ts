import { Auditor } from "./Auditor";

import { IParceriaProc } from "../ParceriaProc/Interfaces/interface.ParceriaProc";
export interface ParceriaProc
{
    id: number;
	advogado : number;
	processo : number;
	auditor?: Auditor | null;
}

export function ParceriaProcEmpty(): IParceriaProc {
// 20250125
    return {
        id: 0,
		advogado: 0,
		processo: 0,
		auditor: null
    };
}
