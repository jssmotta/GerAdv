import { ICargos } from '../Cargos/Interfaces/interface.Cargos';
export interface Cargos
{
    id: number;
	nome : string;

}


export function CargosEmpty(): ICargos {
// 20250604
    
    return {
        id: 0,
		nome: '',
    };
}

export function CargosTestEmpty(): ICargos {
// 20250604
    
    return {
        id: 1,
		nome: 'X',
    };
}


