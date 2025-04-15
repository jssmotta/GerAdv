import { Auditor } from "./Auditor";

import { IEMPClassRiscos } from "../EMPClassRiscos/Interfaces/interface.EMPClassRiscos";
export interface EMPClassRiscos
{
    id: number;
	nome : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function EMPClassRiscosEmpty(): IEMPClassRiscos {
// 20250125
    return {
        id: 0,
		nome: '',
		bold: false,
		auditor: null
    };
}
