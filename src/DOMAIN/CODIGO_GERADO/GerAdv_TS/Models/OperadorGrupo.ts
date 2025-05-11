import { Auditor } from "./Auditor";

import { IOperadorGrupo } from "../OperadorGrupo/Interfaces/interface.OperadorGrupo";
export interface OperadorGrupo
{
    id: number;
	operador : number;
	grupo : number;
	inativo : boolean;
	auditor?: Auditor | null;
}

export function OperadorGrupoEmpty(): IOperadorGrupo {
// 20250125
    return {
        id: 0,
		operador: 0,
		grupo: 0,
		inativo: false,
		auditor: null
    };
}
