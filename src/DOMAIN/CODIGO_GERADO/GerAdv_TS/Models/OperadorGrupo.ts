import { IOperadorGrupo } from '../OperadorGrupo/Interfaces/interface.OperadorGrupo';
export interface OperadorGrupo
{
    id: number;
	operador : number;
	grupo : number;
	inativo : boolean;
	nomeoperador?: string;

}


export function OperadorGrupoEmpty(): IOperadorGrupo {
// 20250604
    
    return {
        id: 0,
		operador: 0,
		grupo: 0,
		inativo: false,
    };
}

export function OperadorGrupoTestEmpty(): IOperadorGrupo {
// 20250604
    
    return {
        id: 1,
		operador: 1,
		grupo: 1,
		inativo: true,
    };
}


