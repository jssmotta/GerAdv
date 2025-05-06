import { Auditor } from "./Auditor";

import { ITipoRecurso } from "../TipoRecurso/Interfaces/interface.TipoRecurso";
export interface TipoRecurso
{
    id: number;
	justica : number;
	area : number;
	descricao : string;
	auditor?: Auditor | null;
}

export function TipoRecursoEmpty(): ITipoRecurso {
// 20250125
    return {
        id: 0,
		justica: 0,
		area: 0,
		descricao: '',
		auditor: null
    };
}
