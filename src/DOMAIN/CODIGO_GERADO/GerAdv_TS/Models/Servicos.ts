import { Auditor } from "./Auditor";

import { IServicos } from "../Servicos/Interfaces/interface.Servicos";
export interface Servicos
{
    id: number;
	cobrar : boolean;
	descricao : string;
	basico : boolean;
	auditor?: Auditor | null;
}

export function ServicosEmpty(): IServicos {
// 20250125
    return {
        id: 0,
		cobrar: false,
		descricao: '',
		basico: false,
		auditor: null
    };
}
