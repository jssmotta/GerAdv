import { Auditor } from "./Auditor";

import { ITribunal } from "../Tribunal/Interfaces/interface.Tribunal";
export interface Tribunal
{
    id: number;
	area : number;
	justica : number;
	instancia : number;
	nome : string;
	descricao : string;
	sigla : string;
	web : string;
	etiqueta : boolean;
	bold : boolean;
	auditor?: Auditor | null;
}

export function TribunalEmpty(): ITribunal {
// 20250125
    return {
        id: 0,
		area: 0,
		justica: 0,
		instancia: 0,
		nome: '',
		descricao: '',
		sigla: '',
		web: '',
		etiqueta: false,
		bold: false,
		auditor: null
    };
}
