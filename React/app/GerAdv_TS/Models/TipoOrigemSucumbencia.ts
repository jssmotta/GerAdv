import { ITipoOrigemSucumbencia } from '../TipoOrigemSucumbencia/Interfaces/interface.TipoOrigemSucumbencia';
export interface TipoOrigemSucumbencia
{
    id: number;
	nome : string;

}


export function TipoOrigemSucumbenciaEmpty(): ITipoOrigemSucumbencia {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function TipoOrigemSucumbenciaTestEmpty(): ITipoOrigemSucumbencia {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


