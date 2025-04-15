import { Auditor } from "./Auditor";

import { IProResumos } from "../ProResumos/Interfaces/interface.ProResumos";
export interface ProResumos
{
    id: number;
	processo : number;
	data : string;
	resumo : string;
	tiporesumo : number;
	bold : boolean;
	auditor?: Auditor | null;
}

export function ProResumosEmpty(): IProResumos {
// 20250125
    return {
        id: 0,
		processo: 0,
		data: '',
		resumo: '',
		tiporesumo: 0,
		bold: false,
		auditor: null
    };
}
