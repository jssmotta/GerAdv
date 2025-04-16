import { Auditor } from "./Auditor";

import { INENotas } from "../NENotas/Interfaces/interface.NENotas";
export interface NENotas
{
    id: number;
	apenso : number;
	precatoria : number;
	instancia : number;
	processo : number;
	movpro : boolean;
	nome : string;
	notaexpedida : boolean;
	revisada : boolean;
	palavrachave : number;
	data : string;
	notapublicada : string;
	auditor?: Auditor | null;
}

export function NENotasEmpty(): INENotas {
// 20250125
    return {
        id: 0,
		apenso: 0,
		precatoria: 0,
		instancia: 0,
		processo: 0,
		movpro: false,
		nome: '',
		notaexpedida: false,
		revisada: false,
		palavrachave: 0,
		data: '',
		notapublicada: '',
		auditor: null
    };
}
