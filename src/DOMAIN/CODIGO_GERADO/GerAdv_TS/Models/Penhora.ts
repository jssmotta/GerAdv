import { Auditor } from "./Auditor";

import { IPenhora } from "../Penhora/Interfaces/interface.Penhora";
export interface Penhora
{
    id: number;
	processo : number;
	penhorastatus : number;
	nome : string;
	descricao : string;
	datapenhora : string;
	master : number;
	auditor?: Auditor | null;
}

export function PenhoraEmpty(): IPenhora {
// 20250125
    return {
        id: 0,
		processo: 0,
		penhorastatus: 0,
		nome: '',
		descricao: '',
		datapenhora: '',
		master: 0,
		auditor: null
    };
}
