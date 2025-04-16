import { Auditor } from "./Auditor";

import { IProCDA } from "../ProCDA/Interfaces/interface.ProCDA";
export interface ProCDA
{
    id: number;
	processo : number;
	nome : string;
	nrointerno : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ProCDAEmpty(): IProCDA {
// 20250125
    return {
        id: 0,
		processo: 0,
		nome: '',
		nrointerno: '',
		bold: false,
		auditor: null
    };
}
