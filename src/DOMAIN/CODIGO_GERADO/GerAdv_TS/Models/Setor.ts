import { ISetor } from '../Setor/Interfaces/interface.Setor';
export interface Setor
{
    id: number;
	descricao : string;

}


export function SetorEmpty(): ISetor {
// 20250604
    
    return {
        id: 0,
		descricao: '',
    };
}

export function SetorTestEmpty(): ISetor {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
    };
}


