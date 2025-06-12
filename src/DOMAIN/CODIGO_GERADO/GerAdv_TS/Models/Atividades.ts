import { IAtividades } from '../Atividades/Interfaces/interface.Atividades';
export interface Atividades
{
    id: number;
	descricao : string;

}


export function AtividadesEmpty(): IAtividades {
// 20250604
    
    return {
        id: 0,
		descricao: '',
    };
}

export function AtividadesTestEmpty(): IAtividades {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
    };
}


