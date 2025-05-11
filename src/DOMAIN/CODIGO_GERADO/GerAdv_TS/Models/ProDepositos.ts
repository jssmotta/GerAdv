import { Auditor } from "./Auditor";

import { IProDepositos } from "../ProDepositos/Interfaces/interface.ProDepositos";
export interface ProDepositos
{
    id: number;
	processo : number;
	fase : number;
	tipoprodesposito : number;
	data : string;
	valor : number;
	auditor?: Auditor | null;
}

export function ProDepositosEmpty(): IProDepositos {
// 20250125
    return {
        id: 0,
		processo: 0,
		fase: 0,
		tipoprodesposito: 0,
		data: '',
		valor: 0,
		auditor: null
    };
}
