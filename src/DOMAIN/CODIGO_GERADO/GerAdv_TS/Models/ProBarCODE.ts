import { Auditor } from "./Auditor";

import { IProBarCODE } from "../ProBarCODE/Interfaces/interface.ProBarCODE";
export interface ProBarCODE
{
    id: number;
	processo : number;
	barcode : string;
	auditor?: Auditor | null;
}

export function ProBarCODEEmpty(): IProBarCODE {
// 20250125
    return {
        id: 0,
		processo: 0,
		barcode: '',
		auditor: null
    };
}
