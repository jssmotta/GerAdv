import { IFuncao } from '../Funcao/Interfaces/interface.Funcao';
export interface Funcao
{
    id: number;
	descricao : string;

}


export function FuncaoEmpty(): IFuncao {
// 20250604
    
    return {
        id: 0,
		descricao: '',
    };
}

export function FuncaoTestEmpty(): IFuncao {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
    };
}


