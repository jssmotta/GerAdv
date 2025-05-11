import { Auditor } from "./Auditor";

import { ITipoEndereco } from "../TipoEndereco/Interfaces/interface.TipoEndereco";
export interface TipoEndereco
{
    id: number;
	descricao : string;
	auditor?: Auditor | null;
}

export function TipoEnderecoEmpty(): ITipoEndereco {
// 20250125
    return {
        id: 0,
		descricao: '',
		auditor: null
    };
}
