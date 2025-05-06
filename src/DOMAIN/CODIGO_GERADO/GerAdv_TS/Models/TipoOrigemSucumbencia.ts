import { ITipoOrigemSucumbencia } from "../TipoOrigemSucumbencia/Interfaces/interface.TipoOrigemSucumbencia";
export interface TipoOrigemSucumbencia
{
    id: number;
	nome : string;
}

export function TipoOrigemSucumbenciaEmpty(): ITipoOrigemSucumbencia {
// 20250125
    return {
        id: 0,
		nome: '',
    };
}
