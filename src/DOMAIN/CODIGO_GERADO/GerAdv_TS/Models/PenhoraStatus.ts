import { Auditor } from "./Auditor";

import { IPenhoraStatus } from "../PenhoraStatus/Interfaces/interface.PenhoraStatus";
export interface PenhoraStatus
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function PenhoraStatusEmpty(): IPenhoraStatus {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
