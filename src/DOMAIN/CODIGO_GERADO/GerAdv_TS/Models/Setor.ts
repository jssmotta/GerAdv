import { Auditor } from "./Auditor";

import { ISetor } from "../Setor/Interfaces/interface.Setor";
export interface Setor
{
    id: number;
	descricao : string;
	auditor?: Auditor | null;
}

export function SetorEmpty(): ISetor {
// 20250125
    return {
        id: 0,
		descricao: '',
		auditor: null
    };
}
