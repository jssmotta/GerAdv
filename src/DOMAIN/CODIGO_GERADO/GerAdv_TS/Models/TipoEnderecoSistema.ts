import { Auditor } from "./Auditor";

import { ITipoEnderecoSistema } from "../TipoEnderecoSistema/Interfaces/interface.TipoEnderecoSistema";
export interface TipoEnderecoSistema
{
    id: number;
	nome : string;
	auditor?: Auditor | null;
}

export function TipoEnderecoSistemaEmpty(): ITipoEnderecoSistema {
// 20250125
    return {
        id: 0,
		nome: '',
		auditor: null
    };
}
