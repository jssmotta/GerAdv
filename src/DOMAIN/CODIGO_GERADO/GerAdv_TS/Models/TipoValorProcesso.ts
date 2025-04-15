import { ITipoValorProcesso } from "../TipoValorProcesso/Interfaces/interface.TipoValorProcesso";
export interface TipoValorProcesso
{
    id: number;
	descricao : string;
}

export function TipoValorProcessoEmpty(): ITipoValorProcesso {
// 20250125
    return {
        id: 0,
		descricao: '',
    };
}
