import { Auditor } from "./Auditor";

import { IReuniaoPessoas } from "../ReuniaoPessoas/Interfaces/interface.ReuniaoPessoas";
export interface ReuniaoPessoas
{
    id: number;
	reuniao : number;
	operador : number;
	auditor?: Auditor | null;
}

export function ReuniaoPessoasEmpty(): IReuniaoPessoas {
// 20250125
    return {
        id: 0,
		reuniao: 0,
		operador: 0,
		auditor: null
    };
}
