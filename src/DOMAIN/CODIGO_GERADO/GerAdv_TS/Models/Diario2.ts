import { Auditor } from "./Auditor";

import { IDiario2 } from "../Diario2/Interfaces/interface.Diario2";
export interface Diario2
{
    id: number;
	operador : number;
	cliente : number;
	data : string;
	hora : string;
	nome : string;
	ocorrencia : string;
	bold : boolean;
	auditor?: Auditor | null;
}

export function Diario2Empty(): IDiario2 {
// 20250125
    return {
        id: 0,
		operador: 0,
		cliente: 0,
		data: '',
		hora: '',
		nome: '',
		ocorrencia: '',
		bold: false,
		auditor: null
    };
}
