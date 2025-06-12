import { ITipoValorProcesso } from '../TipoValorProcesso/Interfaces/interface.TipoValorProcesso';
export interface TipoValorProcesso
{
    id: number;
	descricao : string;

}


export function TipoValorProcessoEmpty(): ITipoValorProcesso {
// 20250604
    
    return {
        id: 0,
		descricao: '',
    };
}

export function TipoValorProcessoTestEmpty(): ITipoValorProcesso {
// 20250604
    
    return {
        id: 1,
		descricao: 'X',
    };
}


