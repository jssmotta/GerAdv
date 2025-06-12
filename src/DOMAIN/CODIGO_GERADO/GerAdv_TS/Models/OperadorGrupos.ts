import { IOperadorGrupos } from '../OperadorGrupos/Interfaces/interface.OperadorGrupos';
export interface OperadorGrupos
{
    id: number;
	nome : string;

}


export function OperadorGruposEmpty(): IOperadorGrupos {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function OperadorGruposTestEmpty(): IOperadorGrupos {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


