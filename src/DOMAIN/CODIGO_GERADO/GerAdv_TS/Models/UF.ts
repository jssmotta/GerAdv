import { Auditor } from "./Auditor";

import { IUF } from "../UF/Interfaces/interface.UF";
export interface UF
{
    id: number;
	pais : number;
	ddd : string;
	iduf : string;
	top : boolean;
	descricao : string;
	auditor?: Auditor | null;
}

export function UFEmpty(): IUF {
// 20250125
    return {
        id: 0,
		pais: 0,
		ddd: '',
		iduf: '',
		top: false,
		descricao: '',
		auditor: null
    };
}
