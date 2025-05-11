import { ITipoProDesposito } from "../TipoProDesposito/Interfaces/interface.TipoProDesposito";
export interface TipoProDesposito
{
    id: number;
	nome : string;
}

export function TipoProDespositoEmpty(): ITipoProDesposito {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
