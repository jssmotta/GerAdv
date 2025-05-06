import { Auditor } from "./Auditor";

import { IAtividades } from "../Atividades/Interfaces/interface.Atividades";
export interface Atividades
{
    id: number;
	descricao : string;
	auditor?: Auditor | null;
}

export function AtividadesEmpty(): IAtividades {
// 20250125
    return {
        id: 0,
		descricao: '',
		auditor: null
    };
}
