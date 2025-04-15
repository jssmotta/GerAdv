import { Auditor } from "./Auditor";

import { IFuncao } from "../Funcao/Interfaces/interface.Funcao";
export interface Funcao
{
    id: number;
	descricao : string;
	auditor?: Auditor | null;
}

export function FuncaoEmpty(): IFuncao {
// 20250125
    return {
        id: 0,
		descricao: '',
		auditor: null
    };
}
