import { ITipoStatusBiu } from "../TipoStatusBiu/Interfaces/interface.TipoStatusBiu";
export interface TipoStatusBiu
{
    id: number;
	nome : string;
}

export function TipoStatusBiuEmpty(): ITipoStatusBiu {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
