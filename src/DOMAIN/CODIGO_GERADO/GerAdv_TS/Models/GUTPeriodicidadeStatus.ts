import { Auditor } from "./Auditor";

import { IGUTPeriodicidadeStatus } from "../GUTPeriodicidadeStatus/Interfaces/interface.GUTPeriodicidadeStatus";
export interface GUTPeriodicidadeStatus
{
    id: number;
	gutatividade : number;
	datarealizado : string;
	auditor?: Auditor | null;
}

export function GUTPeriodicidadeStatusEmpty(): IGUTPeriodicidadeStatus {
// 20250125
    return {
        id: 0,
		gutatividade: 0,
		datarealizado: '',
		auditor: null
    };
}
